using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class CustomerSalesArea : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int SalesOrganizationId { get; set; }
    [Required]
    [MaxLength(30)]
    public string DistributionChannel { get; set; } = string.Empty;
    [Required]
    [MaxLength(30)]
    public string Division { get; set; } = string.Empty;
    public int? PaymentTermId { get; set; }
    public decimal? CreditLimit { get; set; }
    [MaxLength(50)]
    public string? CustomerGroup { get; set; }
    [MaxLength(50)]
    public string? SalesOffice { get; set; }
    [MaxLength(50)]
    public string? SalesDistrict { get; set; }
    public Customer? Customer { get; set; }
    public SalesOrganization? SalesOrganization { get; set; }
    public PaymentTerm? PaymentTerm { get; set; }
}
