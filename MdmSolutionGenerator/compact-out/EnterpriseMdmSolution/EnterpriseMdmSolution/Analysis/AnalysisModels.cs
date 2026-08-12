namespace EnterpriseMdmSolution.Analysis;

public sealed class BusinessObjectRun
{
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string Status { get; set; } = "Queued";
    public DateTimeOffset StartedOn { get; set; }
    public DateTimeOffset? CompletedOn { get; set; }
}

public sealed class DataProfilingSummary
{
    public Guid SummaryId { get; set; }
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? FieldName { get; set; }
    public string MetricName { get; set; } = string.Empty;
    public string MetricType { get; set; } = string.Empty;
    public decimal NumericValue { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}

public sealed class DataProfilingDrilldown
{
    public Guid DrilldownId { get; set; }
    public Guid RunId { get; set; }
    public Guid SummaryId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? FieldName { get; set; }
    public string RecordId { get; set; } = string.Empty;
    public string? Message { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}

public sealed class DataQualityRuleResult
{
    public Guid ResultId { get; set; }
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string RuleCode { get; set; } = string.Empty;
    public string RuleName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int AffectedCount { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}

public sealed class DataQualityDrilldown
{
    public Guid DrilldownId { get; set; }
    public Guid RunId { get; set; }
    public Guid ResultId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string RuleCode { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string RecordId { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTimeOffset CreatedOn { get; set; }
}