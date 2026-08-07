namespace CustomerNdjsonGenerator.Api.Models;

public sealed class CustomerNdjsonGenerationResult
{
    public long RecordCount { get; init; }
    public string FileName { get; init; } = string.Empty;
    public string FilePath { get; init; } = string.Empty;
    public long FileSizeBytes { get; init; }
    public DateTimeOffset GeneratedOnUtc { get; init; }
}
