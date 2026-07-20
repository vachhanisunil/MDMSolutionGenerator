using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materialqualityinspections")]
public sealed class MaterialQualityInspectionsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<MaterialQualityInspectionDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMaterialQualityInspectionByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialQualityInspectionsQuery(new SearchMaterialQualityInspectionDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchMaterialQualityInspectionDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialQualityInspectionsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<MaterialQualityInspectionDto>> Create(CreateMaterialQualityInspectionDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateMaterialQualityInspectionCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MaterialQualityInspectionDto>> Update(int id, UpdateMaterialQualityInspectionDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateMaterialQualityInspectionCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteMaterialQualityInspectionCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

}