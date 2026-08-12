namespace EnterpriseMdmSolution.DTOs;

public sealed class VendorDto
{
    public int Id { get; set; }
    public string VendorNumber { get; set; } = string.Empty;
    public string VendorName { get; set; } = string.Empty;
    public string VendorType { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int CountryId { get; set; }
    public int CurrencyId { get; set; }
    public int? PaymentTermId { get; set; }
    public string? SupplierCategory { get; set; }
    public string? DunsNumber { get; set; }
    public string? OnboardingStatus { get; set; }
    public DateTime? OnboardingDate { get; set; }
    public bool IsActive { get; set; }
}

public sealed class CreateVendorDto
{
    public string VendorNumber { get; set; } = string.Empty;
    public string VendorName { get; set; } = string.Empty;
    public string VendorType { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int CountryId { get; set; }
    public int CurrencyId { get; set; }
    public int? PaymentTermId { get; set; }
    public string? SupplierCategory { get; set; }
    public string? DunsNumber { get; set; }
    public string? OnboardingStatus { get; set; }
    public DateTime? OnboardingDate { get; set; }
    public bool IsActive { get; set; }
}

public sealed class UpdateVendorDto
{
    public string VendorNumber { get; set; } = string.Empty;
    public string VendorName { get; set; } = string.Empty;
    public string VendorType { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int CountryId { get; set; }
    public int CurrencyId { get; set; }
    public int? PaymentTermId { get; set; }
    public string? SupplierCategory { get; set; }
    public string? DunsNumber { get; set; }
    public string? OnboardingStatus { get; set; }
    public DateTime? OnboardingDate { get; set; }
    public bool IsActive { get; set; }
}

public sealed class SearchVendorDto : EnterpriseMdmSolution.Services.SearchRequest
{
}