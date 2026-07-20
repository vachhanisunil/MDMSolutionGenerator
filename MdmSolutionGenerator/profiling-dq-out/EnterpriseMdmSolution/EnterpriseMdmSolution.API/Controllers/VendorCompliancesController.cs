using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/vendorcompliances")]
public sealed class VendorCompliancesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorComplianceDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetVendorComplianceByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorCompliancesQuery(new SearchVendorComplianceDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchVendorComplianceDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorCompliancesQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<VendorComplianceDto>> Create(CreateVendorComplianceDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateVendorComplianceCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VendorComplianceDto>> Update(int id, UpdateVendorComplianceDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateVendorComplianceCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteVendorComplianceCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

}