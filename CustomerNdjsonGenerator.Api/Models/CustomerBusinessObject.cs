namespace CustomerNdjsonGenerator.Api.Models;

public sealed class CustomerBusinessObject
{
    public string CustomerNumber { get; init; } = string.Empty;
    public string CustomerName { get; init; } = string.Empty;
    public string CustomerType { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public int CountryId { get; init; }
    public int CurrencyId { get; init; }
    public string IndustryCode { get; init; } = string.Empty;
    public string RiskCategory { get; init; } = string.Empty;
    public string RegistrationNumber { get; init; } = string.Empty;
    public DateTime OnboardingDate { get; init; }
    public bool IsActive { get; init; }
    public List<CustomerAddress> CustomerAddresses { get; init; } = [];
    public List<CustomerContact> CustomerContacts { get; init; } = [];
    public List<CustomerBankAccount> CustomerBankAccounts { get; init; } = [];
    public List<CustomerSalesArea> CustomerSalesAreas { get; init; } = [];
    public List<CustomerTax> CustomerTaxs { get; init; } = [];
    public List<CustomerClassification> CustomerClassifications { get; init; } = [];
    public List<CustomerCreditProfile> CustomerCreditProfiles { get; init; } = [];
    public List<CustomerPartnerFunction> CustomerPartnerFunctions { get; init; } = [];
    public List<CustomerAttachment> CustomerAttachments { get; init; } = [];
}

public sealed class CustomerAddress
{
    public int CustomerId { get; init; }
    public string AddressType { get; init; } = string.Empty;
    public string AddressLine1 { get; init; } = string.Empty;
    public string AddressLine2 { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;
    public string PostalCode { get; init; } = string.Empty;
    public int CountryId { get; init; }
    public string Region { get; init; } = string.Empty;
    public decimal Latitude { get; init; }
    public decimal Longitude { get; init; }
    public bool IsDefault { get; init; }
}

public sealed class CustomerContact
{
    public int CustomerId { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string MobilePhone { get; init; } = string.Empty;
    public string Designation { get; init; } = string.Empty;
    public string Department { get; init; } = string.Empty;
    public string PreferredLanguage { get; init; } = string.Empty;
    public bool IsPrimary { get; init; }
}

public sealed class CustomerBankAccount
{
    public int CustomerId { get; init; }
    public string BankName { get; init; } = string.Empty;
    public string AccountNumber { get; init; } = string.Empty;
    public string IfscCode { get; init; } = string.Empty;
    public string SwiftCode { get; init; } = string.Empty;
    public int CurrencyId { get; init; }
    public string AccountHolderName { get; init; } = string.Empty;
    public int BankCountryId { get; init; }
    public bool IsDefault { get; init; }
}

public sealed class CustomerSalesArea
{
    public int CustomerId { get; init; }
    public int SalesOrganizationId { get; init; }
    public string DistributionChannel { get; init; } = string.Empty;
    public string Division { get; init; } = string.Empty;
    public int PaymentTermId { get; init; }
    public decimal CreditLimit { get; init; }
    public string CustomerGroup { get; init; } = string.Empty;
    public string SalesOffice { get; init; } = string.Empty;
    public string SalesDistrict { get; init; } = string.Empty;
}

public sealed class CustomerTax
{
    public int CustomerId { get; init; }
    public string TaxType { get; init; } = string.Empty;
    public string TaxNumber { get; init; } = string.Empty;
    public int CountryId { get; init; }
    public DateTime ValidFrom { get; init; }
    public DateTime ValidTo { get; init; }
    public bool IsExempt { get; init; }
}

public sealed class CustomerClassification
{
    public int CustomerId { get; init; }
    public string ClassificationType { get; init; } = string.Empty;
    public string ClassificationValue { get; init; } = string.Empty;
    public string ClassificationGroup { get; init; } = string.Empty;
}

public sealed class CustomerCreditProfile
{
    public int CustomerId { get; init; }
    public string CreditControlArea { get; init; } = string.Empty;
    public decimal CreditLimit { get; init; }
    public decimal CreditExposure { get; init; }
    public string CreditRiskClass { get; init; } = string.Empty;
    public DateTime ReviewDate { get; init; }
    public bool IsBlocked { get; init; }
}

public sealed class CustomerPartnerFunction
{
    public int CustomerId { get; init; }
    public string PartnerFunctionCode { get; init; } = string.Empty;
    public int? PartnerCustomerId { get; init; }
    public string Description { get; init; } = string.Empty;
    public bool IsDefault { get; init; }
}

public sealed class CustomerAttachment
{
    public int CustomerId { get; init; }
    public string DocumentType { get; init; } = string.Empty;
    public string FileName { get; init; } = string.Empty;
    public string ContentType { get; init; } = string.Empty;
    public string StoragePath { get; init; } = string.Empty;
    public DateTime UploadedOn { get; init; }
}
