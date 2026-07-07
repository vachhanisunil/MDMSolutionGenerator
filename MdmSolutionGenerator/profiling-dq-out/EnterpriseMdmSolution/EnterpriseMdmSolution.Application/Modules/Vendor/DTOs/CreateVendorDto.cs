namespace EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;

public sealed class CreateVendorDto
{
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
    public List<EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs.CreateVendorAddressDto> VendorAddresses { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs.CreateVendorContactDto> VendorContacts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs.CreateVendorBankAccountDto> VendorBankAccounts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs.CreateVendorTaxDto> VendorTaxs { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.DTOs.CreateVendorPurchasingOrganizationDto> VendorPurchasingOrganizations { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs.CreateVendorComplianceDto> VendorCompliances { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs.CreateVendorEvaluationDto> VendorEvaluations { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs.CreateVendorCertificateDto> VendorCertificates { get; init; } = [];
}
