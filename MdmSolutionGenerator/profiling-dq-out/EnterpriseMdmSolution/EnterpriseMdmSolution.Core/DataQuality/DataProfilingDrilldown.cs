namespace EnterpriseMdmSolution.Core.DataQuality;

public sealed class DataProfilingDrilldown : EnterpriseMdmSolution.Core.Entities.BaseEntity
{
    public Guid DrilldownId { get; set; }
    public Guid RunId { get; set; }
    public Guid SummaryId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? RootRecordId { get; set; }
    public string? RecordId { get; set; }
    public string? ColumnName { get; set; }
    public string SummaryCode { get; set; } = string.Empty;
    public string SummaryType { get; set; } = string.Empty;
    public string? FieldValue { get; set; }
    public string Message { get; set; } = string.Empty;
    public string RecordSnapshotJson { get; set; } = string.Empty;
    public string SnapshotJson { get; set; } = string.Empty;
    public new DateTimeOffset CreatedOn { get; set; }
}