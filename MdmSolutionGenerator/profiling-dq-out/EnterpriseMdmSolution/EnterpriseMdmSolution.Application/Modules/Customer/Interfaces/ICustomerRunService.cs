using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Interfaces;

public interface ICustomerRunService
{
    Task<Guid> QueueAnalysisRunAsync(string runType, string triggeredBy, CancellationToken cancellationToken = default);
    Task ExecuteAnalysisRunAsync(Guid runId, CancellationToken cancellationToken = default);
    Task ExecuteProfilingAsync(Guid runId, CancellationToken cancellationToken = default);
    Task ExecuteDataQualityAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CustomerRunDto>> GetRunsAsync(CancellationToken cancellationToken = default);
    Task<CustomerRunDto?> GetRunAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CustomerProfilingSummaryDto>> GetProfilingSummaryAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CustomerProfilingDrilldownDto>> GetProfilingDrilldownAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CustomerRuleSummaryDto>> GetRuleSummaryAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CustomerRuleDrilldownDto>> GetRuleDrilldownAsync(Guid runId, CancellationToken cancellationToken = default);
}