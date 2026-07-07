using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materials")]
public sealed class MaterialsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<MaterialDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMaterialByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialsQuery(new SearchMaterialDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchMaterialDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<MaterialDto>> Create(CreateMaterialDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateMaterialCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MaterialDto>> Update(int id, UpdateMaterialDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateMaterialCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteMaterialCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}