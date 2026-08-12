using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMdmSolution.Analysis;

[ApiController]
[Route("api/analysis")]
public sealed class AnalysisController(AnalysisService service) : ControllerBase
{
    [HttpPost("{businessObjectName}/runs")]
    public async Task<ActionResult<BusinessObjectRunDto>> Run(string businessObjectName, CancellationToken cancellationToken)
        => Ok(await service.RunAsync(businessObjectName, cancellationToken));

    [HttpGet("{businessObjectName}/runs")]
    public async Task<ActionResult<IReadOnlyList<BusinessObjectRunDto>>> GetRuns(string businessObjectName, CancellationToken cancellationToken)
        => Ok(await service.GetRunsAsync(businessObjectName, cancellationToken));

    [HttpGet("runs/{runId:guid}/profiling-summary")]
    public async Task<ActionResult<IReadOnlyList<DataProfilingSummary>>> GetProfilingSummaries(Guid runId, CancellationToken cancellationToken)
        => Ok(await service.GetProfilingSummariesAsync(runId, cancellationToken));

    [HttpGet("runs/{runId:guid}/profiling-drilldown/{summaryId:guid}")]
    public async Task<ActionResult<IReadOnlyList<DataProfilingDrilldown>>> GetProfilingDrilldowns(Guid runId, Guid summaryId, CancellationToken cancellationToken)
        => Ok(await service.GetProfilingDrilldownsAsync(runId, summaryId, cancellationToken));

    [HttpGet("runs/{runId:guid}/rule-results")]
    public async Task<ActionResult<IReadOnlyList<DataQualityRuleResult>>> GetRuleResults(Guid runId, CancellationToken cancellationToken)
        => Ok(await service.GetRuleResultsAsync(runId, cancellationToken));

    [HttpGet("runs/{runId:guid}/rule-drilldown/{resultId:guid}")]
    public async Task<ActionResult<IReadOnlyList<DataQualityDrilldown>>> GetRuleDrilldowns(Guid runId, Guid resultId, CancellationToken cancellationToken)
        => Ok(await service.GetRuleDrilldownsAsync(runId, resultId, cancellationToken));
}