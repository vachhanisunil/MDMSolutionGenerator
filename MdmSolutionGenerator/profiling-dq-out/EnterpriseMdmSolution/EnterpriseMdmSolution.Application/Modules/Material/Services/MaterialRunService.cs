using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Interfaces;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Material.Services;

public sealed class MaterialRunService(
    IRepository<BusinessObjectRun> runRepository,
    IRepository<DataProfilingSummary> profilingSummaryRepository,
    IRepository<DataProfilingDrilldown> profilingDrilldownRepository,
    IRepository<DataQualityRuleResult> ruleResultRepository,
    IRepository<DataQualityDrilldown> ruleDrilldownRepository,
    IRepository<DataQualityDuplicateDrilldown> duplicateDrilldownRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.Material> materialRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.MaterialPlant> materialPlantRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.MaterialPrice> materialPriceRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.MaterialStorage> materialStorageRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.MaterialClassification> materialClassificationRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.MaterialVendor> materialVendorRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.MaterialUOM> materialUOMRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection> materialQualityInspectionRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.MaterialForecast> materialForecastRepository,
    IRepository<EnterpriseMdmSolution.Core.Entities.MaterialBarcode> materialBarcodeRepository,
    EnterpriseMdmSolution.Application.Modules.Material.DataQuality.Services.MaterialProfiler profiler,
    EnterpriseMdmSolution.Application.Modules.Material.DataQuality.Services.MaterialDataQualityRuleExecutor ruleExecutor)
    : IMaterialRunService
{
    private readonly IRepository<BusinessObjectRun> _runRepository = runRepository;
    private readonly IRepository<DataProfilingSummary> _profilingSummaryRepository = profilingSummaryRepository;
    private readonly IRepository<DataProfilingDrilldown> _profilingDrilldownRepository = profilingDrilldownRepository;
    private readonly IRepository<DataQualityRuleResult> _ruleResultRepository = ruleResultRepository;
    private readonly IRepository<DataQualityDrilldown> _ruleDrilldownRepository = ruleDrilldownRepository;
    private readonly IRepository<DataQualityDuplicateDrilldown> _duplicateDrilldownRepository = duplicateDrilldownRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.Material> _materialRepository = materialRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.MaterialPlant> _materialPlantRepository = materialPlantRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.MaterialPrice> _materialPriceRepository = materialPriceRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.MaterialStorage> _materialStorageRepository = materialStorageRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.MaterialClassification> _materialClassificationRepository = materialClassificationRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.MaterialVendor> _materialVendorRepository = materialVendorRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.MaterialUOM> _materialUOMRepository = materialUOMRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection> _materialQualityInspectionRepository = materialQualityInspectionRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.MaterialForecast> _materialForecastRepository = materialForecastRepository;
    private readonly IRepository<EnterpriseMdmSolution.Core.Entities.MaterialBarcode> _materialBarcodeRepository = materialBarcodeRepository;
    private readonly EnterpriseMdmSolution.Application.Modules.Material.DataQuality.Services.MaterialProfiler _profiler = profiler;
    private readonly EnterpriseMdmSolution.Application.Modules.Material.DataQuality.Services.MaterialDataQualityRuleExecutor _ruleExecutor = ruleExecutor;

    public async Task<Guid> QueueAnalysisRunAsync(string runType, string triggeredBy, CancellationToken cancellationToken = default)
    {
        var run = new BusinessObjectRun
        {
            RunId = Guid.NewGuid(),
            BusinessObjectName = "Material",
            RootEntityName = "Material",
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

            var rootRecords = await _materialRepository.ListAsync(cancellationToken);
            var ruleResults = (await _ruleResultRepository.ListAsync(cancellationToken)).Where(x => x.RunId == runId && x.BusinessObjectName == "Material").ToList();
            run.TotalRootRecords = rootRecords.Count;
            run.OverallScore = ruleResults.Count == 0 ? 100m : Math.Round(ruleResults.Average(x => x.Score), 2);
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

    public async Task<IReadOnlyList<MaterialRunDto>> GetRunsAsync(CancellationToken cancellationToken = default)
        => (await _runRepository.ListAsync(cancellationToken))
            .Where(x => x.BusinessObjectName == "Material")
            .Select(MapRun)
            .ToList();

    public async Task<MaterialRunDto?> GetRunAsync(Guid runId, CancellationToken cancellationToken = default)
    {
        var run = await _runRepository.GetByIdAsync(runId, cancellationToken);
        return run is null || run.BusinessObjectName != "Material" ? null : MapRun(run);
    }

    public async Task<IReadOnlyList<MaterialProfilingSummaryDto>> GetProfilingSummaryAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _profilingSummaryRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "Material")
            .Select(x => new MaterialProfilingSummaryDto
            {
                SummaryId = x.SummaryId,
                RunId = x.RunId,
                EntityName = x.EntityName,
                FieldName = x.FieldName ?? x.ColumnName,
                MetricName = string.IsNullOrWhiteSpace(x.MetricName) ? x.Label : x.MetricName,
                MetricType = string.IsNullOrWhiteSpace(x.MetricType) ? x.SummaryType : x.MetricType,
                NumericValue = x.NumericValue ?? x.MetricValue,
                TextValue = x.TextValue,
                Score = x.Score
            })
            .ToList();

    public async Task<IReadOnlyList<MaterialProfilingDrilldownDto>> GetProfilingDrilldownAsync(Guid runId, Guid summaryId, CancellationToken cancellationToken = default)
        => (await _profilingDrilldownRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "Material" && x.SummaryId == summaryId)
            .Select(x => new MaterialProfilingDrilldownDto
            {
                DrilldownId = x.DrilldownId,
                RunId = x.RunId,
                SummaryId = x.SummaryId,
                EntityName = x.EntityName,
                RootRecordId = x.RootRecordId,
                RecordId = x.RecordId,
                SnapshotJson = string.IsNullOrWhiteSpace(x.SnapshotJson) ? x.RecordSnapshotJson : x.SnapshotJson
            })
            .ToList();

    public async Task<IReadOnlyList<MaterialRuleSummaryDto>> GetRuleSummaryAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _ruleResultRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "Material")
            .Select(x => new MaterialRuleSummaryDto
            {
                RuleSummaryId = x.ResultId,
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

    public async Task<IReadOnlyList<MaterialRuleDrilldownDto>> GetRuleDrilldownAsync(Guid runId, Guid resultId, CancellationToken cancellationToken = default)
        => (await _ruleDrilldownRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "Material" && (x.ResultId == resultId || x.RuleSummaryId == resultId))
            .Select(x => new MaterialRuleDrilldownDto
            {
                DrilldownId = x.DrilldownId,
                RunId = x.RunId,
                RuleSummaryId = x.ResultId ?? x.RuleSummaryId,
                EntityName = x.EntityName,
                RootRecordId = x.RootRecordId,
                RecordId = x.RecordId,
                FieldName = x.FieldName,
                Message = x.Message,
                Severity = x.Severity,
                Status = x.Status,
                SnapshotJson = string.IsNullOrWhiteSpace(x.SnapshotJson) ? x.RecordSnapshotJson : x.SnapshotJson
            })
            .ToList();

    public async Task<IReadOnlyList<MaterialDuplicateDrilldownDto>> GetDuplicateDrilldownAsync(Guid runId, Guid resultId, CancellationToken cancellationToken = default)
        => (await _duplicateDrilldownRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "Material" && x.ResultId == resultId)
            .Select(x => new MaterialDuplicateDrilldownDto
            {
                DuplicateDrilldownId = x.DuplicateDrilldownId,
                RunId = x.RunId,
                ResultId = x.ResultId,
                RuleCode = x.RuleCode,
                RuleName = x.RuleName,
                EntityName = x.EntityName,
                SourceRootRecordId = x.SourceRootRecordId,
                SourceRecordId = x.SourceRecordId,
                SourceDisplayValue = x.SourceDisplayValue,
                DuplicateRootRecordId = x.DuplicateRootRecordId,
                DuplicateRecordId = x.DuplicateRecordId,
                DuplicateDisplayValue = x.DuplicateDisplayValue,
                MatchScore = x.MatchScore,
                MatchStatus = x.MatchStatus,
                Severity = x.Severity,
                Message = x.Message,
                MatchedFieldJson = x.MatchedFieldJson,
                SourceRecordSnapshotJson = x.SourceRecordSnapshotJson,
                DuplicateRecordSnapshotJson = x.DuplicateRecordSnapshotJson
            })
            .ToList();

    private static MaterialRunDto MapRun(BusinessObjectRun run)
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