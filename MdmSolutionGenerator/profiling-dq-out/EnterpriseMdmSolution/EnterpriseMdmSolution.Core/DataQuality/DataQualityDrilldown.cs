namespace EnterpriseMdmSolution.Core.DataQuality;

public sealed class DataQualityDrilldown : EnterpriseMdmSolution.Core.Entities.BaseEntity
{
    public Guid DrilldownId { get; set; }
    public Guid RunId { get; set; }
    public Guid RuleSummaryId { get; set; }
    public Guid? ResultId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? RootRecordId { get; set; }
    public string? RecordId { get; set; }
    public string RuleCode { get; set; } = string.Empty;
    public string? FieldName { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? FieldValue { get; set; }
    public string RecordSnapshotJson { get; set; } = string.Empty;
    public string SnapshotJson { get; set; } = string.Empty;
    public new DateTimeOffset CreatedOn { get; set; }
}