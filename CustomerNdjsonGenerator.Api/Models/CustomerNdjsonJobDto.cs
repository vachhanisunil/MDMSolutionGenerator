namespace CustomerNdjsonGenerator.Api.Models;

public sealed class CustomerNdjsonJobDto
{
    public Guid JobId { get; init; }
    public CustomerNdjsonJobStatus Status { get; init; }
    public long RecordCount { get; init; }
    public long GeneratedCount { get; init; }
    public decimal ProgressPercent { get; init; }
    public string? FileName { get; init; }
    public string? FilePath { get; init; }
    public long? FileSizeBytes { get; init; }
    public string? ErrorMessage { get; init; }
    public DateTimeOffset CreatedOnUtc { get; init; }
    public DateTimeOffset? StartedOnUtc { get; init; }
    public DateTimeOffset? CompletedOnUtc { get; init; }
    public string StatusUrl { get; init; } = string.Empty;
    public string? DownloadUrl { get; init; }
}
