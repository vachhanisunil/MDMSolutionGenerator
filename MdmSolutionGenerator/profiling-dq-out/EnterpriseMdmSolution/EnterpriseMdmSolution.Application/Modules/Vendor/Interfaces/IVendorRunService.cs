using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Interfaces;

public interface IVendorRunService
{
    Task<Guid> QueueAnalysisRunAsync(string runType, string triggeredBy, CancellationToken cancellationToken = default);
    Task ExecuteAnalysisRunAsync(Guid runId, CancellationToken cancellationToken = default);
    Task ExecuteProfilingAsync(Guid runId, CancellationToken cancellationToken = default);
    Task ExecuteDataQualityAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<VendorRunDto>> GetRunsAsync(CancellationToken cancellationToken = default);
    Task<VendorRunDto?> GetRunAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<VendorProfilingSummaryDto>> GetProfilingSummaryAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<VendorProfilingDrilldownDto>> GetProfilingDrilldownAsync(Guid runId, Guid summaryId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<VendorRuleSummaryDto>> GetRuleSummaryAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<VendorRuleDrilldownDto>> GetRuleDrilldownAsync(Guid runId, Guid resultId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<VendorDuplicateDrilldownDto>> GetDuplicateDrilldownAsync(Guid runId, Guid resultId, CancellationToken cancellationToken = default);
}