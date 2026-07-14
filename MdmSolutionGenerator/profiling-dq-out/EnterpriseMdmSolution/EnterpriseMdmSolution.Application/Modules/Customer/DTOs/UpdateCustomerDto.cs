namespace EnterpriseMdmSolution.Application.Modules.Customer.DTOs;

public sealed class UpdateCustomerDto
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
    public List<EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs.UpdateCustomerAddressDto> CustomerAddresses { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs.UpdateCustomerContactDto> CustomerContacts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs.UpdateCustomerBankAccountDto> CustomerBankAccounts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs.UpdateCustomerSalesAreaDto> CustomerSalesAreas { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs.UpdateCustomerTaxDto> CustomerTaxs { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs.UpdateCustomerClassificationDto> CustomerClassifications { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs.UpdateCustomerCreditProfileDto> CustomerCreditProfiles { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs.UpdateCustomerPartnerFunctionDto> CustomerPartnerFunctions { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs.UpdateCustomerAttachmentDto> CustomerAttachments { get; init; } = [];

    public int Id { get; init; }
}
