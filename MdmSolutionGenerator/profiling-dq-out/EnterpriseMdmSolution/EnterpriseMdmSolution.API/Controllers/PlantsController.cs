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
}