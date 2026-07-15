using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materials")]
public sealed class MaterialAnalysisController(IMediator mediator, IServiceScopeFactory serviceScopeFactory) : ControllerBase
{
    [HttpPost("analysis/run")]
    public async Task<ActionResult<RunMaterialAnalysisResponseDto>> RunAnalysis(RunMaterialAnalysisRequestDto input, CancellationToken cancellationToken)
    {
        var runId = await mediator.Send(new RunMaterialAnalysisCommand(input.RunType, input.TriggeredBy), cancellationToken);
        _ = Task.Run(async () =>
        {
            await using var scope = serviceScopeFactory.CreateAsyncScope();
            var scopedMediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            await scopedMediator.Send(new ExecuteMaterialAnalysisRunCommand(runId), CancellationToken.None);
        }, CancellationToken.None);

        return Accepted(new RunMaterialAnalysisResponseDto { RunId = runId, Status = "Queued" });
    }

    [HttpGet("runs")]
    public async Task<ActionResult<IReadOnlyList<MaterialRunDto>>> GetRuns(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetMaterialRunsQuery(), cancellationToken));

    [HttpGet("runs/{runId:guid}")]
    public async Task<ActionResult<MaterialRunDto>> GetRun(Guid runId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMaterialRunQuery(runId), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet("runs/{runId:guid}/profiling-summary")]
    public async Task<ActionResult<IReadOnlyList<MaterialProfilingSummaryDto>>> GetProfilingSummary(Guid runId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetMaterialProfilingSummaryQuery(runId), cancellationToken));

    [HttpGet("runs/{runId:guid}/profiling-drilldown/{summaryId:guid}")]
    public async Task<ActionResult<IReadOnlyList<MaterialProfilingDrilldownDto>>> GetProfilingDrilldown(Guid runId, Guid summaryId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetMaterialProfilingDrilldownQuery(runId, summaryId), cancellationToken));

    [HttpGet("runs/{runId:guid}/rule-summary")]
    public async Task<ActionResult<IReadOnlyList<MaterialRuleSummaryDto>>> GetRuleSummary(Guid runId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetMaterialRuleSummaryQuery(runId), cancellationToken));

    [HttpGet("runs/{runId:guid}/rule-drilldown/{resultId:guid}")]
    public async Task<ActionResult<IReadOnlyList<MaterialRuleDrilldownDto>>> GetRuleDrilldown(Guid runId, Guid resultId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetMaterialRuleDrilldownQuery(runId, resultId), cancellationToken));

    [HttpGet("runs/{runId:guid}/duplicate-drilldown/{resultId:guid}")]
    public async Task<ActionResult<IReadOnlyList<MaterialDuplicateDrilldownDto>>> GetDuplicateDrilldown(Guid runId, Guid resultId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetMaterialDuplicateDrilldownQuery(runId, resultId), cancellationToken));
}