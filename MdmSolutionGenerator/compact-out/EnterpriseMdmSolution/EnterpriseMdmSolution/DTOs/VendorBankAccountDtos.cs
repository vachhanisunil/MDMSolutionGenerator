namespace EnterpriseMdmSolution.DTOs;

public sealed class VendorBankAccountDto
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string? IfscCode { get; set; }
    public string? SwiftCode { get; set; }
    public int CurrencyId { get; set; }
    public string? AccountHolderName { get; set; }
    public int? BankCountryId { get; set; }
    public bool IsDefault { get; set; }
}

public sealed class CreateVendorBankAccountDto
{
    public int VendorId { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string? IfscCode { get; set; }
    public string? SwiftCode { get; set; }
    public int CurrencyId { get; set; }
    public string? AccountHolderName { get; set; }
    public int? BankCountryId { get; set; }
    public bool IsDefault { get; set; }
}

public sealed class UpdateVendorBankAccountDto
{
    public int VendorId { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string? IfscCode { get; set; }
    public string? SwiftCode { get; set; }
    public int CurrencyId { get; set; }
    public string? AccountHolderName { get; set; }
    public int? BankCountryId { get; set; }
    public bool IsDefault { get; set; }
}

public sealed class SearchVendorBankAccountDto : EnterpriseMdmSolution.Services.SearchRequest
{
}