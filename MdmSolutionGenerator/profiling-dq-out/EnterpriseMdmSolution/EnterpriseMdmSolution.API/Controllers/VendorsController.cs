using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/vendors")]
public sealed class VendorsController(IMediator mediator, IServiceScopeFactory serviceScopeFactory) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetVendorByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorsQuery(new SearchVendorDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchVendorDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<VendorDto>> Create(CreateVendorDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateVendorCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VendorDto>> Update(int id, UpdateVendorDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateVendorCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteVendorCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("bulk-create")]
    public async Task<ActionResult<BulkVendorJobDto>> BulkCreate(BulkCreateVendorDto input, CancellationToken cancellationToken)
    {
        var job = await mediator.Send(new BulkCreateVendorCommand(input), cancellationToken);
        QueueBulkJob(job.JobId);
        return AcceptedAtAction(nameof(GetBulkJob), new { jobId = job.JobId }, job);
    }

    [HttpPost("bulk-upsert")]
    public async Task<ActionResult<BulkVendorJobDto>> BulkUpsert(BulkUpsertVendorDto input, CancellationToken cancellationToken)
    {
        var job = await mediator.Send(new BulkUpsertVendorCommand(input), cancellationToken);
        QueueBulkJob(job.JobId);
        return AcceptedAtAction(nameof(GetBulkJob), new { jobId = job.JobId }, job);
    }

    [HttpPost("bulk-delete")]
    public async Task<ActionResult<BulkVendorJobDto>> BulkDelete(BulkDeleteVendorDto input, CancellationToken cancellationToken)
    {
        var job = await mediator.Send(new BulkDeleteVendorCommand(input), cancellationToken);
        QueueBulkJob(job.JobId);
        return AcceptedAtAction(nameof(GetBulkJob), new { jobId = job.JobId }, job);
    }

    [HttpGet("bulk-jobs/{jobId:guid}")]
    public async Task<ActionResult<BulkVendorJobDto>> GetBulkJob(Guid jobId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetBulkVendorJobQuery(jobId), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    private void QueueBulkJob(Guid jobId)
    {
        _ = Task.Run(async () =>
        {
            await using var scope = serviceScopeFactory.CreateAsyncScope();
            var scopedMediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            await scopedMediator.Send(new ExecuteBulkVendorJobCommand(jobId), CancellationToken.None);
        }, CancellationToken.None);
    }
}