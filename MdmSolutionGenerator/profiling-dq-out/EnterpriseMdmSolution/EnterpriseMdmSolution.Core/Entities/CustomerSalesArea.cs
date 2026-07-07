namespace EnterpriseMdmSolution.Core.Entities;

public class CustomerSalesArea : BaseEntity
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
    public Customer? Customer { get; set; }
    public SalesOrganization? SalesOrganization { get; set; }
    public PaymentTerm? PaymentTerm { get; set; }
}
