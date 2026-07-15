namespace EnterpriseMdmSolution.Core.DataQuality;

public sealed class DataQualityDuplicateDrilldown : EnterpriseMdmSolution.Core.Entities.BaseEntity
{
    public Guid DuplicateDrilldownId { get; set; }
    public Guid RunId { get; set; }
    public Guid ResultId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string RuleCode { get; set; } = string.Empty;
    public string RuleName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string SourceRootRecordId { get; set; } = string.Empty;
    public string SourceRecordId { get; set; } = string.Empty;
    public string SourceDisplayValue { get; set; } = string.Empty;
    public string DuplicateRootRecordId { get; set; } = string.Empty;
    public string DuplicateRecordId { get; set; } = string.Empty;
    public string DuplicateDisplayValue { get; set; } = string.Empty;
    public decimal MatchScore { get; set; }
    public string MatchStatus { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string MatchedFieldJson { get; set; } = string.Empty;
    public string SourceRecordSnapshotJson { get; set; } = string.Empty;
    public string DuplicateRecordSnapshotJson { get; set; } = string.Empty;
    public new DateTimeOffset CreatedOn { get; set; }
}