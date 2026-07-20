using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/purchasingorganizations")]
public sealed class PurchasingOrganizationsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<PurchasingOrganizationDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetPurchasingOrganizationByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchPurchasingOrganizationsQuery(new SearchPurchasingOrganizationDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchPurchasingOrganizationDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchPurchasingOrganizationsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<PurchasingOrganizationDto>> Create(CreatePurchasingOrganizationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreatePurchasingOrganizationCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PurchasingOrganizationDto>> Update(int id, UpdatePurchasingOrganizationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdatePurchasingOrganizationCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeletePurchasingOrganizationCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("bulk-create")]
    public async Task<ActionResult<BulkPurchasingOrganizationOperationResultDto>> BulkCreate(BulkCreatePurchasingOrganizationDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkCreatePurchasingOrganizationCommand(input), cancellationToken));

    [HttpPost("bulk-upsert")]
    public async Task<ActionResult<BulkPurchasingOrganizationOperationResultDto>> BulkUpsert(BulkUpsertPurchasingOrganizationDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpsertPurchasingOrganizationCommand(input), cancellationToken));

    [HttpPost("bulk-delete")]
    public async Task<ActionResult<BulkPurchasingOrganizationOperationResultDto>> BulkDelete(BulkDeletePurchasingOrganizationDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkDeletePurchasingOrganizationCommand(input), cancellationToken));
}