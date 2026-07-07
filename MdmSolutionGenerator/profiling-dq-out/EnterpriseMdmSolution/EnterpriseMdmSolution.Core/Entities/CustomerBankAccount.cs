namespace EnterpriseMdmSolution.Core.Entities;

public class CustomerBankAccount : BaseEntity
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
    public Customer? Customer { get; set; }
    public Currency? Currency { get; set; }
    public Country? Country { get; set; }
}
