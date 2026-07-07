using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Application.Modules.Customer.Interfaces;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Services;

public sealed class CustomerRunService(
    IRepository<BusinessObjectRun> runRepository,
    IRepository<DataProfilingSummary> profilingSummaryRepository,
    IRepository<DataProfilingDrilldown> profilingDrilldownRepository,
    IRepository<DataQualityRuleSummary> ruleSummaryRepository,
    IRepository<DataQualityDrilldown> ruleDrilldownRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.Customer> customerRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.CustomerAddress> customerAddressRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.CustomerContact> customerContactRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.CustomerBankAccount> customerBankAccountRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.CustomerSalesArea> customerSalesAreaRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.CustomerTax> customerTaxRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.CustomerClassification> customerClassificationRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile> customerCreditProfileRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction> customerPartnerFunctionRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.CustomerAttachment> customerAttachmentRepository,
    EnterpriseMdmSolution.Application.Modules.Customer.DataQuality.Services.CustomerProfiler profiler,
    EnterpriseMdmSolution.Application.Modules.Customer.DataQuality.Services.CustomerDataQualityRuleExecutor ruleExecutor)
    : ICustomerRunService
{
    private readonly IRepository<BusinessObjectRun> _runRepository = runRepository;
    private readonly IRepository<DataProfilingSummary> _profilingSummaryRepository = profilingSummaryRepository;
    private readonly IRepository<DataProfilingDrilldown> _profilingDrilldownRepository = profilingDrilldownRepository;
    private readonly IRepository<DataQualityRuleSummary> _ruleSummaryRepository = ruleSummaryRepository;
    private readonly IRepository<DataQualityDrilldown> _ruleDrilldownRepository = ruleDrilldownRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.Customer> _customerRepository = customerRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.CustomerAddress> _customerAddressRepository = customerAddressRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.CustomerContact> _customerContactRepository = customerContactRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.CustomerBankAccount> _customerBankAccountRepository = customerBankAccountRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.CustomerSalesArea> _customerSalesAreaRepository = customerSalesAreaRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.CustomerTax> _customerTaxRepository = customerTaxRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.CustomerClassification> _customerClassificationRepository = customerClassificationRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile> _customerCreditProfileRepository = customerCreditProfileRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction> _customerPartnerFunctionRepository = customerPartnerFunctionRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.CustomerAttachment> _customerAttachmentRepository = customerAttachmentRepository;
    private readonly EnterpriseMdmSolution.Application.Modules.Customer.DataQuality.Services.CustomerProfiler _profiler = profiler;
    private readonly EnterpriseMdmSolution.Application.Modules.Customer.DataQuality.Services.CustomerDataQualityRuleExecutor _ruleExecutor = ruleExecutor;

    public async Task<Guid> QueueAnalysisRunAsync(string runType, string triggeredBy, CancellationToken cancellationToken = default)
    {
        var run = new BusinessObjectRun
        {
            RunId = Guid.NewGuid(),
            BusinessObjectName = "Customer",
            RootEntityName = "Customer",
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

            var rootRecords = await _customerRepository.ListAsync(cancellationToken);
            var ruleSummaries = (await _ruleSummaryRepository.ListAsync(cancellationToken)).Where(x => x.RunId == runId && x.RuleCode.StartsWith("Customer.", StringComparison.Ordinal)).ToList();
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

    public async Task<IReadOnlyList<CustomerRunDto>> GetRunsAsync(CancellationToken cancellationToken = default)
        => (await _runRepository.ListAsync(cancellationToken))
            .Where(x => x.BusinessObjectName == "Customer")
            .Select(MapRun)
            .ToList();

    public async Task<CustomerRunDto?> GetRunAsync(Guid runId, CancellationToken cancellationToken = default)
    {
        var run = await _runRepository.GetByIdAsync(runId, cancellationToken);
        return run is null || run.BusinessObjectName != "Customer" ? null : MapRun(run);
    }

    public async Task<IReadOnlyList<CustomerProfilingSummaryDto>> GetProfilingSummaryAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _profilingSummaryRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "Customer")
            .Select(x => new CustomerProfilingSummaryDto
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

    public async Task<IReadOnlyList<CustomerProfilingDrilldownDto>> GetProfilingDrilldownAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _profilingDrilldownRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "Customer")
            .Select(x => new CustomerProfilingDrilldownDto
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

    public async Task<IReadOnlyList<CustomerRuleSummaryDto>> GetRuleSummaryAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _ruleSummaryRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.RuleCode.StartsWith("Customer.", StringComparison.Ordinal))
            .Select(x => new CustomerRuleSummaryDto
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

    public async Task<IReadOnlyList<CustomerRuleDrilldownDto>> GetRuleDrilldownAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _ruleDrilldownRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "Customer")
            .Select(x => new CustomerRuleDrilldownDto
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

    private static CustomerRunDto MapRun(BusinessObjectRun run)
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