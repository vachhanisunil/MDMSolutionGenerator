namespace EnterpriseMdmSolution.DTOs;

public sealed class CustomerAttachmentDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string DocumentType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public string StoragePath { get; set; } = string.Empty;
    public DateTime UploadedOn { get; set; }
}

public sealed class CreateCustomerAttachmentDto
{
    public int CustomerId { get; set; }
    public string DocumentType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public string StoragePath { get; set; } = string.Empty;
    public DateTime UploadedOn { get; set; }
}

public sealed class UpdateCustomerAttachmentDto
{
    public int CustomerId { get; set; }
    public string DocumentType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public string StoragePath { get; set; } = string.Empty;
    public DateTime UploadedOn { get; set; }
}

public sealed class SearchCustomerAttachmentDto : EnterpriseMdmSolution.Services.SearchRequest
{
}