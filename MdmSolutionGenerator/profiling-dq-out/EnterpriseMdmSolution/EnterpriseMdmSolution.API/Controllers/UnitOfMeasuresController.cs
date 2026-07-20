using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/unitofmeasures")]
public sealed class UnitOfMeasuresController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<UnitOfMeasureDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetUnitOfMeasureByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchUnitOfMeasuresQuery(new SearchUnitOfMeasureDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchUnitOfMeasureDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchUnitOfMeasuresQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<UnitOfMeasureDto>> Create(CreateUnitOfMeasureDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateUnitOfMeasureCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UnitOfMeasureDto>> Update(int id, UpdateUnitOfMeasureDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateUnitOfMeasureCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteUnitOfMeasureCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("bulk-create")]
    public async Task<ActionResult<BulkUnitOfMeasureOperationResultDto>> BulkCreate(BulkCreateUnitOfMeasureDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkCreateUnitOfMeasureCommand(input), cancellationToken));

    [HttpPost("bulk-upsert")]
    public async Task<ActionResult<BulkUnitOfMeasureOperationResultDto>> BulkUpsert(BulkUpsertUnitOfMeasureDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpsertUnitOfMeasureCommand(input), cancellationToken));

    [HttpPost("bulk-delete")]
    public async Task<ActionResult<BulkUnitOfMeasureOperationResultDto>> BulkDelete(BulkDeleteUnitOfMeasureDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkDeleteUnitOfMeasureCommand(input), cancellationToken));
}