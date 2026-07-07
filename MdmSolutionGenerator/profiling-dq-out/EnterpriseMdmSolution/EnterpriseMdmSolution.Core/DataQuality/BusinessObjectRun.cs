namespace EnterpriseMdmSolution.Core.DataQuality;

public sealed class BusinessObjectRun : EnterpriseMdmSolution.Core.Entities.BaseEntity
{
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string RootEntityName { get; set; } = string.Empty;
    public string RunType { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset StartedOn { get; set; }
    public DateTimeOffset? CompletedOn { get; set; }
    public string TriggeredBy { get; set; } = string.Empty;
    public int TotalRootRecords { get; set; }
    public decimal? OverallScore { get; set; }
    public string? ErrorMessage { get; set; }
}