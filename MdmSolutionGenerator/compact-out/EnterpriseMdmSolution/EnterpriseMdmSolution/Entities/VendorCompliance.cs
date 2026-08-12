using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class VendorCompliance : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int VendorId { get; set; }
    [Required]
    [MaxLength(50)]
    public string ComplianceType { get; set; } = string.Empty;
    [Required]
    [MaxLength(30)]
    public string ComplianceStatus { get; set; } = string.Empty;
    [MaxLength(100)]
    public string? CertificateNumber { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    [MaxLength(100)]
    public string? ReviewOwner { get; set; }
    public Vendor? Vendor { get; set; }
}
