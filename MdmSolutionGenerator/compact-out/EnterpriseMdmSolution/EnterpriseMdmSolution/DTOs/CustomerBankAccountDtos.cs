namespace EnterpriseMdmSolution.DTOs;

public sealed class CustomerBankAccountDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string? IfscCode { get; set; }
    public string? SwiftCode { get; set; }
    public int CurrencyId { get; set; }
    public string? AccountHolderName { get; set; }
    public int? BankCountryId { get; set; }
    public bool IsDefault { get; set; }
}

public sealed class CreateCustomerBankAccountDto
{
    public int CustomerId { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string? IfscCode { get; set; }
    public string? SwiftCode { get; set; }
    public int CurrencyId { get; set; }
    public string? AccountHolderName { get; set; }
    public int? BankCountryId { get; set; }
    public bool IsDefault { get; set; }
}

public sealed class UpdateCustomerBankAccountDto
{
    public int CustomerId { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string? IfscCode { get; set; }
    public string? SwiftCode { get; set; }
    public int CurrencyId { get; set; }
    public string? AccountHolderName { get; set; }
    public int? BankCountryId { get; set; }
    public bool IsDefault { get; set; }
}

public sealed class SearchCustomerBankAccountDto : EnterpriseMdmSolution.Services.SearchRequest
{
}