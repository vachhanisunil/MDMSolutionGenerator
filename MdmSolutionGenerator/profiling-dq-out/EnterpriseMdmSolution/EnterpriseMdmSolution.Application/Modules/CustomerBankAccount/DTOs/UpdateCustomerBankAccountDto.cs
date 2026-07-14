namespace EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs;

public sealed class UpdateCustomerBankAccountDto
{
    public int CustomerId { get; init; }
    public string BankName { get; init; } = string.Empty;
    public string AccountNumber { get; init; } = string.Empty;
    public string? IfscCode { get; init; }
    public string? SwiftCode { get; init; }
    public int CurrencyId { get; init; }
    public string? AccountHolderName { get; init; }
    public int? BankCountryId { get; init; }
    public bool IsDefault { get; init; }

    public int Id { get; init; }
}
