using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/vendorpurchasingorganizations")]
public sealed class VendorPurchasingOrganizationsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorPurchasingOrganizationDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetVendorPurchasingOrganizationByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorPurchasingOrganizationsQuery(new SearchVendorPurchasingOrganizationDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchVendorPurchasingOrganizationDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorPurchasingOrganizationsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<VendorPurchasingOrganizationDto>> Create(CreateVendorPurchasingOrganizationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateVendorPurchasingOrganizationCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VendorPurchasingOrganizationDto>> Update(int id, UpdateVendorPurchasingOrganizationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateVendorPurchasingOrganizationCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteVendorPurchasingOrganizationCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

}