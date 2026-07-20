namespace EnterpriseMdmSolution.Core.DataQuality;

public sealed class BulkOperationItem : EnterpriseMdmSolution.Core.Entities.BaseEntity
{
    public Guid ItemId { get; set; }
    public Guid JobId { get; set; }
    public int SequenceNumber { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? RecordId { get; set; }
    public string? ErrorMessage { get; set; }
    public string InputSnapshotJson { get; set; } = string.Empty;
    public string ResultSnapshotJson { get; set; } = string.Empty;
}