namespace EnterpriseMdmSolution.DTOs;

public sealed class CustomerDto
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
}

public sealed class CreateCustomerDto
{
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
}

public sealed class UpdateCustomerDto
{
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
}

public sealed class SearchCustomerDto : EnterpriseMdmSolution.Services.SearchRequest
{
}