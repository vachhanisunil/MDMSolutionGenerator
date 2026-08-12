using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class CustomerAttachment : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    [Required]
    [MaxLength(50)]
    public string DocumentType { get; set; } = string.Empty;
    [Required]
    [MaxLength(200)]
    public string FileName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string? ContentType { get; set; }
    [Required]
    [MaxLength(500)]
    public string StoragePath { get; set; } = string.Empty;
    public DateTime UploadedOn { get; set; }
    public Customer? Customer { get; set; }
}
