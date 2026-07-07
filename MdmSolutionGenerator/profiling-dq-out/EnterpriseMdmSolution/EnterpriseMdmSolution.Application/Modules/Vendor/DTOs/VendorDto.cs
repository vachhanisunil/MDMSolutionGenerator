namespace EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;

public sealed class VendorDto
{
    public int Id { get; init; }
    public string VendorNumber { get; init; } = string.Empty;
    public string VendorName { get; init; } = string.Empty;
    public string VendorType { get; init; } = string.Empty;
    public string? Email { get; init; }
    public string? Phone { get; init; }
    public int CountryId { get; init; }
    public int CurrencyId { get; init; }
    public int? PaymentTermId { get; init; }
    public string? SupplierCategory { get; init; }
    public string? DunsNumber { get; init; }
    public string? OnboardingStatus { get; init; }
    public DateTime? OnboardingDate { get; init; }
    public bool IsActive { get; init; }
    public List<EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs.VendorAddressDto> VendorAddresses { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs.VendorContactDto> VendorContacts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs.VendorBankAccountDto> VendorBankAccounts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs.VendorTaxDto> VendorTaxs { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.DTOs.VendorPurchasingOrganizationDto> VendorPurchasingOrganizations { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs.VendorComplianceDto> VendorCompliances { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs.VendorEvaluationDto> VendorEvaluations { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs.VendorCertificateDto> VendorCertificates { get; init; } = [];
}
