using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materialplants")]
public sealed class MaterialPlantsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<MaterialPlantDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMaterialPlantByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialPlantsQuery(new SearchMaterialPlantDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchMaterialPlantDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialPlantsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<MaterialPlantDto>> Create(CreateMaterialPlantDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateMaterialPlantCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MaterialPlantDto>> Update(int id, UpdateMaterialPlantDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateMaterialPlantCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteMaterialPlantCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

}