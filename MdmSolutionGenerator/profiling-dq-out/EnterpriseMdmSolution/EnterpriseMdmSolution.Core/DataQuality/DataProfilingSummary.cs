namespace EnterpriseMdmSolution.Core.DataQuality;

public sealed class DataProfilingSummary : EnterpriseMdmSolution.Core.Entities.BaseEntity
{
    public Guid SummaryId { get; set; }
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? FieldName { get; set; }
    public string? ColumnName { get; set; }
    public string SummaryCode { get; set; } = string.Empty;
    public string SummaryType { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string? Severity { get; set; }
    public string MetricName { get; set; } = string.Empty;
    public string MetricType { get; set; } = string.Empty;
    public decimal MetricValue { get; set; }
    public int AffectedCount { get; set; }
    public bool HasDrilldown { get; set; }
    public string? DrilldownKey { get; set; }
    public decimal? NumericValue { get; set; }
    public string? TextValue { get; set; }
    public decimal? Score { get; set; }
    public new DateTimeOffset CreatedOn { get; set; }
}