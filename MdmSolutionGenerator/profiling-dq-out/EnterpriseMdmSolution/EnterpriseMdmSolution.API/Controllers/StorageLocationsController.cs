using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/storagelocations")]
public sealed class StorageLocationsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<StorageLocationDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetStorageLocationByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchStorageLocationsQuery(new SearchStorageLocationDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchStorageLocationDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchStorageLocationsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<StorageLocationDto>> Create(CreateStorageLocationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateStorageLocationCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<StorageLocationDto>> Update(int id, UpdateStorageLocationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateStorageLocationCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteStorageLocationCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}