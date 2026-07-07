namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs;

public sealed class UpdateCustomerSalesAreaDto
{
    public int CustomerId { get; init; }
    public int SalesOrganizationId { get; init; }
    public string DistributionChannel { get; init; } = string.Empty;
    public string Division { get; init; } = string.Empty;
    public int? PaymentTermId { get; init; }
    public decimal? CreditLimit { get; init; }
    public string? CustomerGroup { get; init; }
    public string? SalesOffice { get; init; }
    public string? SalesDistrict { get; init; }
}
