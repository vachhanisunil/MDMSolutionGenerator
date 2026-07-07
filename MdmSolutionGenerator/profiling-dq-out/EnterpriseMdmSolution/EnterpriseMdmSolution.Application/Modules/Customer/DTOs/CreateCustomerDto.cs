namespace EnterpriseMdmSolution.Application.Modules.Customer.DTOs;

public sealed class CreateCustomerDto
{
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
    public List<EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs.CreateCustomerAddressDto> CustomerAddresses { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs.CreateCustomerContactDto> CustomerContacts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs.CreateCustomerBankAccountDto> CustomerBankAccounts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs.CreateCustomerSalesAreaDto> CustomerSalesAreas { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs.CreateCustomerTaxDto> CustomerTaxs { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs.CreateCustomerClassificationDto> CustomerClassifications { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs.CreateCustomerCreditProfileDto> CustomerCreditProfiles { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs.CreateCustomerPartnerFunctionDto> CustomerPartnerFunctions { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs.CreateCustomerAttachmentDto> CustomerAttachments { get; init; } = [];
}
