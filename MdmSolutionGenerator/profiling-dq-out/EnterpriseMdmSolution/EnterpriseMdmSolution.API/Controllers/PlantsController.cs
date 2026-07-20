using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.Plant.Commands;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;
using EnterpriseMdmSolution.Application.Modules.Plant.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/plants")]
public sealed class PlantsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<PlantDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetPlantByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchPlantsQuery(new SearchPlantDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchPlantDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchPlantsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<PlantDto>> Create(CreatePlantDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreatePlantCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlantDto>> Update(int id, UpdatePlantDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdatePlantCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeletePlantCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("bulk-create")]
    public async Task<ActionResult<BulkPlantOperationResultDto>> BulkCreate(BulkCreatePlantDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkCreatePlantCommand(input), cancellationToken));

    [HttpPut("bulk-update")]
    public async Task<ActionResult<BulkPlantOperationResultDto>> BulkUpdate(BulkUpdatePlantDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpdatePlantCommand(input), cancellationToken));

    [HttpPost("bulk-upsert")]
    public async Task<ActionResult<BulkPlantOperationResultDto>> BulkUpsert(BulkUpsertPlantDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpsertPlantCommand(input), cancellationToken));

    [HttpPost("bulk-delete")]
    public async Task<ActionResult<BulkPlantOperationResultDto>> BulkDelete(BulkDeletePlantDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkDeletePlantCommand(input), cancellationToken));
}