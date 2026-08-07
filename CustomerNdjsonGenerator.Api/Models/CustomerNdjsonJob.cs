namespace CustomerNdjsonGenerator.Api.Models;

public sealed class CustomerNdjsonJob
{
    public Guid JobId { get; init; } = Guid.NewGuid();
    public CustomerNdjsonGenerationRequest Request { get; init; } = new();
    public CustomerNdjsonJobStatus Status { get; set; } = CustomerNdjsonJobStatus.Queued;
    public long GeneratedCount { get; set; }
    public string? FileName { get; set; }
    public string? FilePath { get; set; }
    public long? FileSizeBytes { get; set; }
    public string? ErrorMessage { get; set; }
    public DateTimeOffset CreatedOnUtc { get; init; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? StartedOnUtc { get; set; }
    public DateTimeOffset? CompletedOnUtc { get; set; }
}
