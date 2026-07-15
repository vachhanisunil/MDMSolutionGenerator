namespace EnterpriseMdmSolution.Core.DataQuality;

public sealed class DuplicateCandidateRow
{
    public string SourceRootRecordId { get; set; } = string.Empty;
    public string SourceRecordId { get; set; } = string.Empty;
    public string SourceDisplayValue { get; set; } = string.Empty;
    public string DuplicateRootRecordId { get; set; } = string.Empty;
    public string DuplicateRecordId { get; set; } = string.Empty;
    public string DuplicateDisplayValue { get; set; } = string.Empty;
    public decimal MatchScore { get; set; }
    public string MatchedFieldJson { get; set; } = string.Empty;
    public string SourceRecordSnapshotJson { get; set; } = string.Empty;
    public string DuplicateRecordSnapshotJson { get; set; } = string.Empty;
}