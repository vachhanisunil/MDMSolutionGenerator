using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class VendorCertificate : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int VendorId { get; set; }
    [Required]
    [MaxLength(50)]
    public string CertificateType { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    public string CertificateName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string? CertificateNumber { get; set; }
    [MaxLength(150)]
    public string? IssuingAuthority { get; set; }
    public DateTime? ExpiryDate { get; set; }
    [MaxLength(500)]
    public string? StoragePath { get; set; }
    public Vendor? Vendor { get; set; }
}
