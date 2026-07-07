using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.VendorContact.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorContact.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/vendorcontacts")]
public sealed class VendorContactsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorContactDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetVendorContactByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorContactsQuery(new SearchVendorContactDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchVendorContactDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorContactsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<VendorContactDto>> Create(CreateVendorContactDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateVendorContactCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VendorContactDto>> Update(int id, UpdateVendorContactDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateVendorContactCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteVendorContactCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}