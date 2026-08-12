namespace EnterpriseMdmSolution.DTOs;

public sealed class CustomerCreditProfileDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CreditControlArea { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public decimal? CreditExposure { get; set; }
    public string? CreditRiskClass { get; set; }
    public DateTime? ReviewDate { get; set; }
    public bool IsBlocked { get; set; }
}

public sealed class CreateCustomerCreditProfileDto
{
    public int CustomerId { get; set; }
    public string CreditControlArea { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public decimal? CreditExposure { get; set; }
    public string? CreditRiskClass { get; set; }
    public DateTime? ReviewDate { get; set; }
    public bool IsBlocked { get; set; }
}

public sealed class UpdateCustomerCreditProfileDto
{
    public int CustomerId { get; set; }
    public string CreditControlArea { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public decimal? CreditExposure { get; set; }
    public string? CreditRiskClass { get; set; }
    public DateTime? ReviewDate { get; set; }
    public bool IsBlocked { get; set; }
}

public sealed class SearchCustomerCreditProfileDto : EnterpriseMdmSolution.Services.SearchRequest
{
}