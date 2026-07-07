namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs;

public sealed class UpdateVendorCertificateDto
{
    public int VendorId { get; init; }
    public string CertificateType { get; init; } = string.Empty;
    public string CertificateName { get; init; } = string.Empty;
    public string? CertificateNumber { get; init; }
    public string? IssuingAuthority { get; init; }
    public DateTime? ExpiryDate { get; init; }
    public string? StoragePath { get; init; }
}
