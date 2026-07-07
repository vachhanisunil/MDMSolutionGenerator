namespace EnterpriseMdmSolution.Core.Entities;

public class Vendor : BaseEntity
{
    public int Id { get; set; }
    public string VendorNumber { get; set; } = string.Empty;
    public string VendorName { get; set; } = string.Empty;
    public string VendorType { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int CountryId { get; set; }
    public int CurrencyId { get; set; }
    public int? PaymentTermId { get; set; }
    public string? SupplierCategory { get; set; }
    public string? DunsNumber { get; set; }
    public string? OnboardingStatus { get; set; }
    public DateTime? OnboardingDate { get; set; }
    public bool IsActive { get; set; }
    public ICollection<MaterialVendor> MaterialVendors { get; set; } = [];
    public Country? Country { get; set; }
    public Currency? Currency { get; set; }
    public PaymentTerm? PaymentTerm { get; set; }
    public ICollection<VendorAddress> VendorAddresses { get; set; } = [];
    public ICollection<VendorContact> VendorContacts { get; set; } = [];
    public ICollection<VendorBankAccount> VendorBankAccounts { get; set; } = [];
    public ICollection<VendorTax> VendorTaxs { get; set; } = [];
    public ICollection<VendorPurchasingOrganization> VendorPurchasingOrganizations { get; set; } = [];
    public ICollection<VendorCompliance> VendorCompliances { get; set; } = [];
    public ICollection<VendorEvaluation> VendorEvaluations { get; set; } = [];
    public ICollection<VendorCertificate> VendorCertificates { get; set; } = [];
}
