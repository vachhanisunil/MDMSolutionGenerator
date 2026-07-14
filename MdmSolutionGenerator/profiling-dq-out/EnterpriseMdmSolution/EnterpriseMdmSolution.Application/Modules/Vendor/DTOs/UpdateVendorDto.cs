namespace EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;

public sealed class UpdateVendorDto
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
    public List<EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs.UpdateVendorAddressDto> VendorAddresses { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs.UpdateVendorContactDto> VendorContacts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs.UpdateVendorBankAccountDto> VendorBankAccounts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs.UpdateVendorTaxDto> VendorTaxs { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.DTOs.UpdateVendorPurchasingOrganizationDto> VendorPurchasingOrganizations { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs.UpdateVendorComplianceDto> VendorCompliances { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs.UpdateVendorEvaluationDto> VendorEvaluations { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs.UpdateVendorCertificateDto> VendorCertificates { get; init; } = [];

    public int Id { get; init; }
}
