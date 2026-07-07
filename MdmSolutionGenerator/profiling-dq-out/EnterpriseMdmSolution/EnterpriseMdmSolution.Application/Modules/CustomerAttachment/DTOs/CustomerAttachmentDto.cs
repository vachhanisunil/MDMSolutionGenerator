namespace EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs;

public sealed class CustomerAttachmentDto
{
    public int Id { get; init; }
    public int CustomerId { get; init; }
    public string DocumentType { get; init; } = string.Empty;
    public string FileName { get; init; } = string.Empty;
    public string? ContentType { get; init; }
    public string StoragePath { get; init; } = string.Empty;
    public DateTime UploadedOn { get; init; }
}
