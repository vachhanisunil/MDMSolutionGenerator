using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class Vendor : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string VendorNumber { get; set; } = string.Empty;
    [Required]
    [MaxLength(200)]
    public string VendorName { get; set; } = string.Empty;
    [Required]
    [MaxLength(30)]
    public string VendorType { get; set; } = string.Empty;
    [MaxLength(250)]
    public string? Email { get; set; }
    [MaxLength(30)]
    public string? Phone { get; set; }
    public int CountryId { get; set; }
    public int CurrencyId { get; set; }
    public int? PaymentTermId { get; set; }
    [MaxLength(50)]
    public string? SupplierCategory { get; set; }
    [MaxLength(30)]
    public string? DunsNumber { get; set; }
    [MaxLength(30)]
    public string? OnboardingStatus { get; set; }
    public DateTime? OnboardingDate { get; set; }
    public bool IsActive { get; set; }
    public Country? Country { get; set; }
    public Currency? Currency { get; set; }
    public PaymentTerm? PaymentTerm { get; set; }
    public ICollection<MaterialVendor> MaterialVendors { get; set; } = [];
    public ICollection<VendorAddress> VendorAddresses { get; set; } = [];
    public ICollection<VendorContact> VendorContacts { get; set; } = [];
    public ICollection<VendorBankAccount> VendorBankAccounts { get; set; } = [];
    public ICollection<VendorTax> VendorTaxs { get; set; } = [];
    public ICollection<VendorPurchasingOrganization> VendorPurchasingOrganizations { get; set; } = [];
    public ICollection<VendorCompliance> VendorCompliances { get; set; } = [];
    public ICollection<VendorEvaluation> VendorEvaluations { get; set; } = [];
    public ICollection<VendorCertificate> VendorCertificates { get; set; } = [];
}
