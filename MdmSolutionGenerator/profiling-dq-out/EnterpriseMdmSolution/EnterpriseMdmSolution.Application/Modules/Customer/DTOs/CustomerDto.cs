namespace EnterpriseMdmSolution.Application.Modules.Customer.DTOs;

public sealed class CustomerDto
{
    public int Id { get; init; }
    public string CustomerNumber { get; init; } = string.Empty;
    public string CustomerName { get; init; } = string.Empty;
    public string CustomerType { get; init; } = string.Empty;
    public string? Email { get; init; }
    public string? Phone { get; init; }
    public int CountryId { get; init; }
    public int CurrencyId { get; init; }
    public string? IndustryCode { get; init; }
    public string? RiskCategory { get; init; }
    public string? RegistrationNumber { get; init; }
    public DateTime? OnboardingDate { get; init; }
    public bool IsActive { get; init; }
    public List<EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs.CustomerAddressDto> CustomerAddresses { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs.CustomerContactDto> CustomerContacts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs.CustomerBankAccountDto> CustomerBankAccounts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs.CustomerSalesAreaDto> CustomerSalesAreas { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs.CustomerTaxDto> CustomerTaxs { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs.CustomerClassificationDto> CustomerClassifications { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs.CustomerCreditProfileDto> CustomerCreditProfiles { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs.CustomerPartnerFunctionDto> CustomerPartnerFunctions { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs.CustomerAttachmentDto> CustomerAttachments { get; init; } = [];
}
