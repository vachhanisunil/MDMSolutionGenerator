namespace EnterpriseMdmSolution.Core.Entities;

public class VendorCompliance : BaseEntity
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public string ComplianceType { get; set; } = string.Empty;
    public string ComplianceStatus { get; set; } = string.Empty;
    public string? CertificateNumber { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public string? ReviewOwner { get; set; }
    public Vendor? Vendor { get; set; }
}
