using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materialstorages")]
public sealed class MaterialStoragesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<MaterialStorageDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMaterialStorageByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialStoragesQuery(new SearchMaterialStorageDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchMaterialStorageDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialStoragesQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<MaterialStorageDto>> Create(CreateMaterialStorageDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateMaterialStorageCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MaterialStorageDto>> Update(int id, UpdateMaterialStorageDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateMaterialStorageCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteMaterialStorageCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}