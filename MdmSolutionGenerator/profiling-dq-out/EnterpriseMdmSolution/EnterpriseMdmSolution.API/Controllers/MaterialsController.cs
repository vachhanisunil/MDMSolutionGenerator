using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materials")]
public sealed class MaterialsController(IMediator mediator, IServiceScopeFactory serviceScopeFactory) : ControllerBase
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

    [HttpPost("bulk-create")]
    public async Task<ActionResult<BulkMaterialJobDto>> BulkCreate(BulkCreateMaterialDto input, CancellationToken cancellationToken)
    {
        var job = await mediator.Send(new BulkCreateMaterialCommand(input), cancellationToken);
        QueueBulkJob(job.JobId);
        return AcceptedAtAction(nameof(GetBulkJob), new { jobId = job.JobId }, job);
    }

    [HttpPost("bulk-upsert")]
    public async Task<ActionResult<BulkMaterialJobDto>> BulkUpsert(BulkUpsertMaterialDto input, CancellationToken cancellationToken)
    {
        var job = await mediator.Send(new BulkUpsertMaterialCommand(input), cancellationToken);
        QueueBulkJob(job.JobId);
        return AcceptedAtAction(nameof(GetBulkJob), new { jobId = job.JobId }, job);
    }

    [HttpPost("bulk-delete")]
    public async Task<ActionResult<BulkMaterialJobDto>> BulkDelete(BulkDeleteMaterialDto input, CancellationToken cancellationToken)
    {
        var job = await mediator.Send(new BulkDeleteMaterialCommand(input), cancellationToken);
        QueueBulkJob(job.JobId);
        return AcceptedAtAction(nameof(GetBulkJob), new { jobId = job.JobId }, job);
    }

    [HttpGet("bulk-jobs/{jobId:guid}")]
    public async Task<ActionResult<BulkMaterialJobDto>> GetBulkJob(Guid jobId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetBulkMaterialJobQuery(jobId), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    private void QueueBulkJob(Guid jobId)
    {
        _ = Task.Run(async () =>
        {
            await using var scope = serviceScopeFactory.CreateAsyncScope();
            var scopedMediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            await scopedMediator.Send(new ExecuteBulkMaterialJobCommand(jobId), CancellationToken.None);
        }, CancellationToken.None);
    }
}