using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materialclassifications")]
public sealed class MaterialClassificationsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<MaterialClassificationDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMaterialClassificationByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialClassificationsQuery(new SearchMaterialClassificationDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchMaterialClassificationDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialClassificationsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<MaterialClassificationDto>> Create(CreateMaterialClassificationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateMaterialClassificationCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MaterialClassificationDto>> Update(int id, UpdateMaterialClassificationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateMaterialClassificationCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteMaterialClassificationCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}