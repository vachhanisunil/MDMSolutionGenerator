using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.VendorTax.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorTax.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/vendortaxs")]
public sealed class VendorTaxsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorTaxDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetVendorTaxByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorTaxsQuery(new SearchVendorTaxDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchVendorTaxDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorTaxsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<VendorTaxDto>> Create(CreateVendorTaxDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateVendorTaxCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VendorTaxDto>> Update(int id, UpdateVendorTaxDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateVendorTaxCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteVendorTaxCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

}