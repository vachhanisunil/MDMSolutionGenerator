namespace EnterpriseMdmSolution.DTOs;

public sealed class CustomerSalesAreaDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int SalesOrganizationId { get; set; }
    public string DistributionChannel { get; set; } = string.Empty;
    public string Division { get; set; } = string.Empty;
    public int? PaymentTermId { get; set; }
    public decimal? CreditLimit { get; set; }
    public string? CustomerGroup { get; set; }
    public string? SalesOffice { get; set; }
    public string? SalesDistrict { get; set; }
}

public sealed class CreateCustomerSalesAreaDto
{
    public int CustomerId { get; set; }
    public int SalesOrganizationId { get; set; }
    public string DistributionChannel { get; set; } = string.Empty;
    public string Division { get; set; } = string.Empty;
    public int? PaymentTermId { get; set; }
    public decimal? CreditLimit { get; set; }
    public string? CustomerGroup { get; set; }
    public string? SalesOffice { get; set; }
    public string? SalesDistrict { get; set; }
}

public sealed class UpdateCustomerSalesAreaDto
{
    public int CustomerId { get; set; }
    public int SalesOrganizationId { get; set; }
    public string DistributionChannel { get; set; } = string.Empty;
    public string Division { get; set; } = string.Empty;
    public int? PaymentTermId { get; set; }
    public decimal? CreditLimit { get; set; }
    public string? CustomerGroup { get; set; }
    public string? SalesOffice { get; set; }
    public string? SalesDistrict { get; set; }
}

public sealed class SearchCustomerSalesAreaDto : EnterpriseMdmSolution.Services.SearchRequest
{
}