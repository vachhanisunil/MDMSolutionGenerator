using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/vendors")]
public sealed class VendorAnalysisController(IMediator mediator, IServiceScopeFactory serviceScopeFactory) : ControllerBase
{
    [HttpPost("analysis/run")]
    public async Task<ActionResult<RunVendorAnalysisResponseDto>> RunAnalysis(RunVendorAnalysisRequestDto input, CancellationToken cancellationToken)
    {
        var runId = await mediator.Send(new RunVendorAnalysisCommand(input.RunType, input.TriggeredBy), cancellationToken);
        _ = Task.Run(async () =>
        {
            await using var scope = serviceScopeFactory.CreateAsyncScope();
            var scopedMediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            await scopedMediator.Send(new ExecuteVendorAnalysisRunCommand(runId), CancellationToken.None);
        }, CancellationToken.None);

        return Accepted(new RunVendorAnalysisResponseDto { RunId = runId, Status = "Queued" });
    }

    [HttpGet("runs")]
    public async Task<ActionResult<IReadOnlyList<VendorRunDto>>> GetRuns(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetVendorRunsQuery(), cancellationToken));

    [HttpGet("runs/{runId:guid}")]
    public async Task<ActionResult<VendorRunDto>> GetRun(Guid runId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetVendorRunQuery(runId), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet("runs/{runId:guid}/profiling-summary")]
    public async Task<ActionResult<IReadOnlyList<VendorProfilingSummaryDto>>> GetProfilingSummary(Guid runId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetVendorProfilingSummaryQuery(runId), cancellationToken));

    [HttpGet("runs/{runId:guid}/profiling-drilldown/{summaryId:guid}")]
    public async Task<ActionResult<IReadOnlyList<VendorProfilingDrilldownDto>>> GetProfilingDrilldown(Guid runId, Guid summaryId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetVendorProfilingDrilldownQuery(runId, summaryId), cancellationToken));

    [HttpGet("runs/{runId:guid}/rule-summary")]
    public async Task<ActionResult<IReadOnlyList<VendorRuleSummaryDto>>> GetRuleSummary(Guid runId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetVendorRuleSummaryQuery(runId), cancellationToken));

    [HttpGet("runs/{runId:guid}/rule-drilldown/{resultId:guid}")]
    public async Task<ActionResult<IReadOnlyList<VendorRuleDrilldownDto>>> GetRuleDrilldown(Guid runId, Guid resultId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetVendorRuleDrilldownQuery(runId, resultId), cancellationToken));

    [HttpGet("runs/{runId:guid}/duplicate-drilldown/{resultId:guid}")]
    public async Task<ActionResult<IReadOnlyList<VendorDuplicateDrilldownDto>>> GetDuplicateDrilldown(Guid runId, Guid resultId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetVendorDuplicateDrilldownQuery(runId, resultId), cancellationToken));
}