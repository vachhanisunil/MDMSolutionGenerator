namespace EnterpriseMdmSolution.Core.Entities;

public class Customer : BaseEntity
{
    public int Id { get; set; }
    public string CustomerNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerType { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int CountryId { get; set; }
    public int CurrencyId { get; set; }
    public string? IndustryCode { get; set; }
    public string? RiskCategory { get; set; }
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
