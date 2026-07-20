namespace EnterpriseMdmSolution.Core.DataQuality;

public sealed class BulkOperationJob : EnterpriseMdmSolution.Core.Entities.BaseEntity
{
    public Guid JobId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string Operation { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int RequestedCount { get; set; }
    public int CreatedCount { get; set; }
    public int UpdatedCount { get; set; }
    public int DeletedCount { get; set; }
    public int FailedCount { get; set; }
    public DateTimeOffset QueuedOn { get; set; }
    public DateTimeOffset? StartedOn { get; set; }
    public DateTimeOffset? CompletedOn { get; set; }
    public string TriggeredBy { get; set; } = string.Empty;
    public string InputSnapshotJson { get; set; } = string.Empty;
    public string? ErrorMessage { get; set; }
}