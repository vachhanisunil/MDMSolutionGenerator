using EnterpriseMdmSolution.Application.Modules.Material.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Material.Interfaces;

public interface IMaterialRunService
{
    Task<Guid> QueueAnalysisRunAsync(string runType, string triggeredBy, CancellationToken cancellationToken = default);
    Task ExecuteAnalysisRunAsync(Guid runId, CancellationToken cancellationToken = default);
    Task ExecuteProfilingAsync(Guid runId, CancellationToken cancellationToken = default);
    Task ExecuteDataQualityAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<MaterialRunDto>> GetRunsAsync(CancellationToken cancellationToken = default);
    Task<MaterialRunDto?> GetRunAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<MaterialProfilingSummaryDto>> GetProfilingSummaryAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<MaterialProfilingDrilldownDto>> GetProfilingDrilldownAsync(Guid runId, Guid summaryId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<MaterialRuleSummaryDto>> GetRuleSummaryAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<MaterialRuleDrilldownDto>> GetRuleDrilldownAsync(Guid runId, Guid resultId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<MaterialDuplicateDrilldownDto>> GetDuplicateDrilldownAsync(Guid runId, Guid resultId, CancellationToken cancellationToken = default);
}