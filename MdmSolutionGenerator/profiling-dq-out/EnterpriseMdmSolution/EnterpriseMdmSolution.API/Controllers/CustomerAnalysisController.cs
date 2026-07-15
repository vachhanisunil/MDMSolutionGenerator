using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Application.Modules.Customer.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/customers")]
public sealed class CustomerAnalysisController(IMediator mediator, IServiceScopeFactory serviceScopeFactory) : ControllerBase
{
    [HttpPost("analysis/run")]
    public async Task<ActionResult<RunCustomerAnalysisResponseDto>> RunAnalysis(RunCustomerAnalysisRequestDto input, CancellationToken cancellationToken)
    {
        var runId = await mediator.Send(new RunCustomerAnalysisCommand(input.RunType, input.TriggeredBy), cancellationToken);
        _ = Task.Run(async () =>
        {
            await using var scope = serviceScopeFactory.CreateAsyncScope();
            var scopedMediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            await scopedMediator.Send(new ExecuteCustomerAnalysisRunCommand(runId), CancellationToken.None);
        }, CancellationToken.None);

        return Accepted(new RunCustomerAnalysisResponseDto { RunId = runId, Status = "Queued" });
    }

    [HttpGet("runs")]
    public async Task<ActionResult<IReadOnlyList<CustomerRunDto>>> GetRuns(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetCustomerRunsQuery(), cancellationToken));

    [HttpGet("runs/{runId:guid}")]
    public async Task<ActionResult<CustomerRunDto>> GetRun(Guid runId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCustomerRunQuery(runId), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet("runs/{runId:guid}/profiling-summary")]
    public async Task<ActionResult<IReadOnlyList<CustomerProfilingSummaryDto>>> GetProfilingSummary(Guid runId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetCustomerProfilingSummaryQuery(runId), cancellationToken));

    [HttpGet("runs/{runId:guid}/profiling-drilldown/{summaryId:guid}")]
    public async Task<ActionResult<IReadOnlyList<CustomerProfilingDrilldownDto>>> GetProfilingDrilldown(Guid runId, Guid summaryId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetCustomerProfilingDrilldownQuery(runId, summaryId), cancellationToken));

    [HttpGet("runs/{runId:guid}/rule-summary")]
    public async Task<ActionResult<IReadOnlyList<CustomerRuleSummaryDto>>> GetRuleSummary(Guid runId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetCustomerRuleSummaryQuery(runId), cancellationToken));

    [HttpGet("runs/{runId:guid}/rule-drilldown/{resultId:guid}")]
    public async Task<ActionResult<IReadOnlyList<CustomerRuleDrilldownDto>>> GetRuleDrilldown(Guid runId, Guid resultId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetCustomerRuleDrilldownQuery(runId, resultId), cancellationToken));

    [HttpGet("runs/{runId:guid}/duplicate-drilldown/{resultId:guid}")]
    public async Task<ActionResult<IReadOnlyList<CustomerDuplicateDrilldownDto>>> GetDuplicateDrilldown(Guid runId, Guid resultId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetCustomerDuplicateDrilldownQuery(runId, resultId), cancellationToken));
}