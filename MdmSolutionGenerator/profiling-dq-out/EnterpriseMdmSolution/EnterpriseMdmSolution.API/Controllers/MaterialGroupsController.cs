using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materialgroups")]
public sealed class MaterialGroupsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<MaterialGroupDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMaterialGroupByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialGroupsQuery(new SearchMaterialGroupDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchMaterialGroupDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialGroupsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<MaterialGroupDto>> Create(CreateMaterialGroupDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateMaterialGroupCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MaterialGroupDto>> Update(int id, UpdateMaterialGroupDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateMaterialGroupCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteMaterialGroupCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("bulk-create")]
    public async Task<ActionResult<BulkMaterialGroupOperationResultDto>> BulkCreate(BulkCreateMaterialGroupDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkCreateMaterialGroupCommand(input), cancellationToken));

    [HttpPost("bulk-upsert")]
    public async Task<ActionResult<BulkMaterialGroupOperationResultDto>> BulkUpsert(BulkUpsertMaterialGroupDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpsertMaterialGroupCommand(input), cancellationToken));

    [HttpPost("bulk-delete")]
    public async Task<ActionResult<BulkMaterialGroupOperationResultDto>> BulkDelete(BulkDeleteMaterialGroupDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkDeleteMaterialGroupCommand(input), cancellationToken));
}