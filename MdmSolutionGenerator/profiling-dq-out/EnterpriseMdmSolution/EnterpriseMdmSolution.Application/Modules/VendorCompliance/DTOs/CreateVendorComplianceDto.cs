namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs;

public sealed class CreateVendorComplianceDto
{
    public int VendorId { get; init; }
    public string ComplianceType { get; init; } = string.Empty;
    public string ComplianceStatus { get; init; } = string.Empty;
    public string? CertificateNumber { get; init; }
    public DateTime? ValidFrom { get; init; }
    public DateTime? ValidTo { get; init; }
    public string? ReviewOwner { get; init; }
}
