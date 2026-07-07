using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/vendoraddresses")]
public sealed class VendorAddressesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorAddressDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetVendorAddressByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorAddressesQuery(new SearchVendorAddressDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchVendorAddressDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorAddressesQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<VendorAddressDto>> Create(CreateVendorAddressDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateVendorAddressCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VendorAddressDto>> Update(int id, UpdateVendorAddressDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateVendorAddressCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteVendorAddressCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}