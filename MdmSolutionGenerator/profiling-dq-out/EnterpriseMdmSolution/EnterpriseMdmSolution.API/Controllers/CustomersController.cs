using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Application.Modules.Customer.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/customers")]
public sealed class CustomersController(IMediator mediator, IServiceScopeFactory serviceScopeFactory) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCustomerByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomersQuery(new SearchCustomerDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchCustomerDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomersQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> Create(CreateCustomerDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCustomerCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerDto>> Update(int id, UpdateCustomerDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCustomerCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCustomerCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("bulk-create")]
    public async Task<ActionResult<BulkCustomerJobDto>> BulkCreate(BulkCreateCustomerDto input, CancellationToken cancellationToken)
    {
        var job = await mediator.Send(new BulkCreateCustomerCommand(input), cancellationToken);
        QueueBulkJob(job.JobId);
        return AcceptedAtAction(nameof(GetBulkJob), new { jobId = job.JobId }, job);
    }

    [HttpPost("bulk-upsert")]
    public async Task<ActionResult<BulkCustomerJobDto>> BulkUpsert(BulkUpsertCustomerDto input, CancellationToken cancellationToken)
    {
        var job = await mediator.Send(new BulkUpsertCustomerCommand(input), cancellationToken);
        QueueBulkJob(job.JobId);
        return AcceptedAtAction(nameof(GetBulkJob), new { jobId = job.JobId }, job);
    }

    [HttpPost("bulk-delete")]
    public async Task<ActionResult<BulkCustomerJobDto>> BulkDelete(BulkDeleteCustomerDto input, CancellationToken cancellationToken)
    {
        var job = await mediator.Send(new BulkDeleteCustomerCommand(input), cancellationToken);
        QueueBulkJob(job.JobId);
        return AcceptedAtAction(nameof(GetBulkJob), new { jobId = job.JobId }, job);
    }

    [HttpGet("bulk-jobs/{jobId:guid}")]
    public async Task<ActionResult<BulkCustomerJobDto>> GetBulkJob(Guid jobId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetBulkCustomerJobQuery(jobId), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    private void QueueBulkJob(Guid jobId)
    {
        _ = Task.Run(async () =>
        {
            await using var scope = serviceScopeFactory.CreateAsyncScope();
            var scopedMediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            await scopedMediator.Send(new ExecuteBulkCustomerJobCommand(jobId), CancellationToken.None);
        }, CancellationToken.None);
    }
}