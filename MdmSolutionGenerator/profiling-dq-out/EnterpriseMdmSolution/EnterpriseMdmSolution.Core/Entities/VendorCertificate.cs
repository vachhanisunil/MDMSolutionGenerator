namespace EnterpriseMdmSolution.Core.Entities;

public class VendorCertificate : BaseEntity
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public string CertificateType { get; set; } = string.Empty;
    public string CertificateName { get; set; } = string.Empty;
    public string? CertificateNumber { get; set; }
    public string? IssuingAuthority { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? StoragePath { get; set; }
    public Vendor? Vendor { get; set; }
}
