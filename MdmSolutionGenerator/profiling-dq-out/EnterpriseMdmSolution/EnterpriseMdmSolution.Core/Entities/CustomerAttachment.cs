namespace EnterpriseMdmSolution.Core.Entities;

public class CustomerAttachment : BaseEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string DocumentType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public string StoragePath { get; set; } = string.Empty;
    public DateTime UploadedOn { get; set; }
    public Customer? Customer { get; set; }
}
