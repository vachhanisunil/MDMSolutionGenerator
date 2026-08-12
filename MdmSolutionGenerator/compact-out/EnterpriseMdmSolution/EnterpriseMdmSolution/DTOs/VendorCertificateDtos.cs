namespace EnterpriseMdmSolution.DTOs;

public sealed class VendorCertificateDto
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public string CertificateType { get; set; } = string.Empty;
    public string CertificateName { get; set; } = string.Empty;
    public string? CertificateNumber { get; set; }
    public string? IssuingAuthority { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? StoragePath { get; set; }
}

public sealed class CreateVendorCertificateDto
{
    public int VendorId { get; set; }
    public string CertificateType { get; set; } = string.Empty;
    public string CertificateName { get; set; } = string.Empty;
    public string? CertificateNumber { get; set; }
    public string? IssuingAuthority { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? StoragePath { get; set; }
}

public sealed class UpdateVendorCertificateDto
{
    public int VendorId { get; set; }
    public string CertificateType { get; set; } = string.Empty;
    public string CertificateName { get; set; } = string.Empty;
    public string? CertificateNumber { get; set; }
    public string? IssuingAuthority { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? StoragePath { get; set; }
}

public sealed class SearchVendorCertificateDto : EnterpriseMdmSolution.Services.SearchRequest
{
}