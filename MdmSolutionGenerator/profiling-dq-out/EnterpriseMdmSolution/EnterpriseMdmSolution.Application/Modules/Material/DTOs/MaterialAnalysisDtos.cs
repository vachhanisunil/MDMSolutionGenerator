namespace EnterpriseMdmSolution.Application.Modules.Material.DTOs;

public sealed class RunMaterialAnalysisRequestDto
{
    public string RunType { get; init; } = "Analysis";
    public string TriggeredBy { get; init; } = "system";
}

public sealed class RunMaterialAnalysisResponseDto
{
    public Guid RunId { get; init; }
    public string Status { get; init; } = string.Empty;
}

public sealed class MaterialRunDto
{
    public Guid RunId { get; init; }
    public string BusinessObjectName { get; init; } = string.Empty;
    public string RootEntityName { get; init; } = string.Empty;
    public string RunType { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public DateTimeOffset StartedOn { get; init; }
    public DateTimeOffset? CompletedOn { get; init; }
    public string TriggeredBy { get; init; } = string.Empty;
    public int TotalRootRecords { get; init; }
    public decimal? OverallScore { get; init; }
    public string? ErrorMessage { get; init; }
}

public sealed class MaterialProfilingSummaryDto
{
    public Guid SummaryId { get; init; }
    public Guid RunId { get; init; }
    public string EntityName { get; init; } = string.Empty;
    public string? FieldName { get; init; }
    public string MetricName { get; init; } = string.Empty;
    public string MetricType { get; init; } = string.Empty;
    public decimal? NumericValue { get; init; }
    public string? TextValue { get; init; }
    public decimal? Score { get; init; }
}

public sealed class MaterialProfilingDrilldownDto
{
    public Guid DrilldownId { get; init; }
    public Guid RunId { get; init; }
    public Guid SummaryId { get; init; }
    public string EntityName { get; init; } = string.Empty;
    public string? RootRecordId { get; init; }
    public string? RecordId { get; init; }
    public string SnapshotJson { get; init; } = string.Empty;
}

public sealed class MaterialRuleSummaryDto
{
    public Guid RuleSummaryId { get; init; }
    public Guid RunId { get; init; }
    public string RuleCode { get; init; } = string.Empty;
    public string RuleName { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public string Severity { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public int AffectedCount { get; init; }
    public decimal Score { get; init; }
}

public sealed class MaterialRuleDrilldownDto
{
    public Guid DrilldownId { get; init; }
    public Guid RunId { get; init; }
    public Guid RuleSummaryId { get; init; }
    public string EntityName { get; init; } = string.Empty;
    public string? RootRecordId { get; init; }
    public string? RecordId { get; init; }
    public string? FieldName { get; init; }
    public string Message { get; init; } = string.Empty;
    public string Severity { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public string SnapshotJson { get; init; } = string.Empty;
}

public sealed class MaterialDuplicateDrilldownDto
{
    public Guid DuplicateDrilldownId { get; init; }
    public Guid RunId { get; init; }
    public Guid ResultId { get; init; }
    public string RuleCode { get; init; } = string.Empty;
    public string RuleName { get; init; } = string.Empty;
    public string EntityName { get; init; } = string.Empty;
    public string SourceRootRecordId { get; init; } = string.Empty;
    public string SourceRecordId { get; init; } = string.Empty;
    public string SourceDisplayValue { get; init; } = string.Empty;
    public string DuplicateRootRecordId { get; init; } = string.Empty;
    public string DuplicateRecordId { get; init; } = string.Empty;
    public string DuplicateDisplayValue { get; init; } = string.Empty;
    public decimal MatchScore { get; init; }
    public string MatchStatus { get; init; } = string.Empty;
    public string Severity { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public string MatchedFieldJson { get; init; } = string.Empty;
    public string SourceRecordSnapshotJson { get; init; } = string.Empty;
    public string DuplicateRecordSnapshotJson { get; init; } = string.Empty;
}