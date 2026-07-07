using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Interfaces;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Services;

public sealed class VendorRunService(
    IRepository<BusinessObjectRun> runRepository,
    IRepository<DataProfilingSummary> profilingSummaryRepository,
    IRepository<DataProfilingDrilldown> profilingDrilldownRepository,
    IRepository<DataQualityRuleSummary> ruleSummaryRepository,
    IRepository<DataQualityDrilldown> ruleDrilldownRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.Vendor> vendorRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.VendorAddress> vendorAddressRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.VendorContact> vendorContactRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.VendorBankAccount> vendorBankAccountRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.VendorTax> vendorTaxRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization> vendorPurchasingOrganizationRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.VendorCompliance> vendorComplianceRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.VendorEvaluation> vendorEvaluationRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.VendorCertificate> vendorCertificateRepository,
    EnterpriseMdmSolution.Application.Modules.Vendor.DataQuality.Services.VendorProfiler profiler,
    EnterpriseMdmSolution.Application.Modules.Vendor.DataQuality.Services.VendorDataQualityRuleExecutor ruleExecutor)
    : IVendorRunService
{
    private readonly IRepository<BusinessObjectRun> _runRepository = runRepository;
    private readonly IRepository<DataProfilingSummary> _profilingSummaryRepository = profilingSummaryRepository;
    private readonly IRepository<DataProfilingDrilldown> _profilingDrilldownRepository = profilingDrilldownRepository;
    private readonly IRepository<DataQualityRuleSummary> _ruleSummaryRepository = ruleSummaryRepository;
    private readonly IRepository<DataQualityDrilldown> _ruleDrilldownRepository = ruleDrilldownRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.Vendor> _vendorRepository = vendorRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.VendorAddress> _vendorAddressRepository = vendorAddressRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.VendorContact> _vendorContactRepository = vendorContactRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.VendorBankAccount> _vendorBankAccountRepository = vendorBankAccountRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.VendorTax> _vendorTaxRepository = vendorTaxRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization> _vendorPurchasingOrganizationRepository = vendorPurchasingOrganizationRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.VendorCompliance> _vendorComplianceRepository = vendorComplianceRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.VendorEvaluation> _vendorEvaluationRepository = vendorEvaluationRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.VendorCertificate> _vendorCertificateRepository = vendorCertificateRepository;
    private readonly EnterpriseMdmSolution.Application.Modules.Vendor.DataQuality.Services.VendorProfiler _profiler = profiler;
    private readonly EnterpriseMdmSolution.Application.Modules.Vendor.DataQuality.Services.VendorDataQualityRuleExecutor _ruleExecutor = ruleExecutor;

    public async Task<Guid> QueueAnalysisRunAsync(string runType, string triggeredBy, CancellationToken cancellationToken = default)
    {
        var run = new BusinessObjectRun
        {
            RunId = Guid.NewGuid(),
            BusinessObjectName = "Vendor",
            RootEntityName = "Vendor",
            RunType = string.IsNullOrWhiteSpace(runType) ? "Analysis" : runType,
            Status = "Queued",
            StartedOn = DateTimeOffset.UtcNow,
            TriggeredBy = string.IsNullOrWhiteSpace(triggeredBy) ? "system" : triggeredBy
        };

        await _runRepository.AddAsync(run, cancellationToken);
        await _runRepository.SaveChangesAsync(cancellationToken);
        return run.RunId;
    }

    public async Task ExecuteAnalysisRunAsync(Guid runId, CancellationToken cancellationToken = default)
    {
        var run = await _runRepository.GetByIdAsync(runId, cancellationToken);
        if (run is null)
        {
            return;
        }

        try
        {
            run.Status = "Running";
            _runRepository.Update(run);
            await _runRepository.SaveChangesAsync(cancellationToken);

            await ExecuteProfilingAsync(runId, cancellationToken);
            await ExecuteDataQualityAsync(runId, cancellationToken);

            var rootRecords = await _vendorRepository.ListAsync(cancellationToken);
            var ruleSummaries = (await _ruleSummaryRepository.ListAsync(cancellationToken)).Where(x => x.RunId == runId && x.RuleCode.StartsWith("Vendor.", StringComparison.Ordinal)).ToList();
            run.TotalRootRecords = rootRecords.Count;
            run.OverallScore = ruleSummaries.Count == 0 ? 100m : Math.Round(ruleSummaries.Average(x => x.Score), 2);
            run.Status = "Completed";
            run.CompletedOn = DateTimeOffset.UtcNow;
            _runRepository.Update(run);
            await _runRepository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            run.Status = "Failed";
            run.ErrorMessage = exception.Message;
            run.CompletedOn = DateTimeOffset.UtcNow;
            _runRepository.Update(run);
            await _runRepository.SaveChangesAsync(CancellationToken.None);
        }
    }

    public async Task ExecuteProfilingAsync(Guid runId, CancellationToken cancellationToken = default)
        => await _profiler.ExecuteAsync(runId, cancellationToken);

    public async Task ExecuteDataQualityAsync(Guid runId, CancellationToken cancellationToken = default)
        => await _ruleExecutor.ExecuteAsync(runId, cancellationToken);

    public async Task<IReadOnlyList<VendorRunDto>> GetRunsAsync(CancellationToken cancellationToken = default)
        => (await _runRepository.ListAsync(cancellationToken))
            .Where(x => x.BusinessObjectName == "Vendor")
            .Select(MapRun)
            .ToList();

    public async Task<VendorRunDto?> GetRunAsync(Guid runId, CancellationToken cancellationToken = default)
    {
        var run = await _runRepository.GetByIdAsync(runId, cancellationToken);
        return run is null || run.BusinessObjectName != "Vendor" ? null : MapRun(run);
    }

    public async Task<IReadOnlyList<VendorProfilingSummaryDto>> GetProfilingSummaryAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _profilingSummaryRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "Vendor")
            .Select(x => new VendorProfilingSummaryDto
            {
                SummaryId = x.SummaryId,
                RunId = x.RunId,
                EntityName = x.EntityName,
                FieldName = x.FieldName,
                MetricName = x.MetricName,
                MetricType = x.MetricType,
                NumericValue = x.NumericValue,
                TextValue = x.TextValue,
                Score = x.Score
            })
            .ToList();

    public async Task<IReadOnlyList<VendorProfilingDrilldownDto>> GetProfilingDrilldownAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _profilingDrilldownRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "Vendor")
            .Select(x => new VendorProfilingDrilldownDto
            {
                DrilldownId = x.DrilldownId,
                RunId = x.RunId,
                SummaryId = x.SummaryId,
                EntityName = x.EntityName,
                RootRecordId = x.RootRecordId,
                RecordId = x.RecordId,
                SnapshotJson = x.SnapshotJson
            })
            .ToList();

    public async Task<IReadOnlyList<VendorRuleSummaryDto>> GetRuleSummaryAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _ruleSummaryRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.RuleCode.StartsWith("Vendor.", StringComparison.Ordinal))
            .Select(x => new VendorRuleSummaryDto
            {
                RuleSummaryId = x.RuleSummaryId,
                RunId = x.RunId,
                RuleCode = x.RuleCode,
                RuleName = x.RuleName,
                Category = x.Category,
                Severity = x.Severity,
                Status = x.Status,
                AffectedCount = x.AffectedCount,
                Score = x.Score
            })
            .ToList();

    public async Task<IReadOnlyList<VendorRuleDrilldownDto>> GetRuleDrilldownAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _ruleDrilldownRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "Vendor")
            .Select(x => new VendorRuleDrilldownDto
            {
                DrilldownId = x.DrilldownId,
                RunId = x.RunId,
                RuleSummaryId = x.RuleSummaryId,
                EntityName = x.EntityName,
                RootRecordId = x.RootRecordId,
                RecordId = x.RecordId,
                FieldName = x.FieldName,
                Message = x.Message,
                Severity = x.Severity,
                Status = x.Status,
                SnapshotJson = x.SnapshotJson
            })
            .ToList();

    private static VendorRunDto MapRun(BusinessObjectRun run)
        => new()
        {
            RunId = run.RunId,
            BusinessObjectName = run.BusinessObjectName,
            RootEntityName = run.RootEntityName,
            RunType = run.RunType,
            Status = run.Status,
            StartedOn = run.StartedOn,
            CompletedOn = run.CompletedOn,
            TriggeredBy = run.TriggeredBy,
            TotalRootRecords = run.TotalRootRecords,
            OverallScore = run.OverallScore,
            ErrorMessage = run.ErrorMessage
        };
}