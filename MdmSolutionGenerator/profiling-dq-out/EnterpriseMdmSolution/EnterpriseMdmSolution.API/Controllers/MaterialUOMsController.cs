using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materialuoms")]
public sealed class MaterialUOMsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<MaterialUOMDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMaterialUOMByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialUOMsQuery(new SearchMaterialUOMDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchMaterialUOMDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialUOMsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<MaterialUOMDto>> Create(CreateMaterialUOMDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateMaterialUOMCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MaterialUOMDto>> Update(int id, UpdateMaterialUOMDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateMaterialUOMCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteMaterialUOMCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

}