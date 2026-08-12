using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class Customer : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string CustomerNumber { get; set; } = string.Empty;
    [Required]
    [MaxLength(200)]
    public string CustomerName { get; set; } = string.Empty;
    [Required]
    [MaxLength(30)]
    public string CustomerType { get; set; } = string.Empty;
    [MaxLength(250)]
    public string? Email { get; set; }
    [MaxLength(30)]
    public string? Phone { get; set; }
    public int CountryId { get; set; }
    public int CurrencyId { get; set; }
    [MaxLength(30)]
    public string? IndustryCode { get; set; }
    [MaxLength(30)]
    public string? RiskCategory { get; set; }
    [MaxLength(50)]
    public string? RegistrationNumber { get; set; }
    public DateTime? OnboardingDate { get; set; }
    public bool IsActive { get; set; }
    public Country? Country { get; set; }
    public Currency? Currency { get; set; }
    public ICollection<CustomerAddress> CustomerAddresses { get; set; } = [];
    public ICollection<CustomerContact> CustomerContacts { get; set; } = [];
    public ICollection<CustomerBankAccount> CustomerBankAccounts { get; set; } = [];
    public ICollection<CustomerSalesArea> CustomerSalesAreas { get; set; } = [];
    public ICollection<CustomerTax> CustomerTaxs { get; set; } = [];
    public ICollection<CustomerClassification> CustomerClassifications { get; set; } = [];
    public ICollection<CustomerCreditProfile> CustomerCreditProfiles { get; set; } = [];
    public ICollection<CustomerPartnerFunction> CustomerPartnerFunctions { get; set; } = [];
    public ICollection<CustomerAttachment> CustomerAttachments { get; set; } = [];
}
