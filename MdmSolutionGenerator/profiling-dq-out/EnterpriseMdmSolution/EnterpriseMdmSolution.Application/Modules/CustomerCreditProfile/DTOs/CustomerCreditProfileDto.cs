namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs;

public sealed class CustomerCreditProfileDto
{
    public int Id { get; init; }
    public int CustomerId { get; init; }
    public string CreditControlArea { get; init; } = string.Empty;
    public decimal CreditLimit { get; init; }
    public decimal? CreditExposure { get; init; }
    public string? CreditRiskClass { get; init; }
    public DateTime? ReviewDate { get; init; }
    public bool IsBlocked { get; init; }
}
