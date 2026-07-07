using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/salesorganizations")]
public sealed class SalesOrganizationsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<SalesOrganizationDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetSalesOrganizationByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchSalesOrganizationsQuery(new SearchSalesOrganizationDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchSalesOrganizationDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchSalesOrganizationsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<SalesOrganizationDto>> Create(CreateSalesOrganizationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateSalesOrganizationCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SalesOrganizationDto>> Update(int id, UpdateSalesOrganizationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateSalesOrganizationCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteSalesOrganizationCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}