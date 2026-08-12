using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class PaymentTerm : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string Code { get; set; } = string.Empty;
    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;
    public int NetDays { get; set; }
    public ICollection<CustomerSalesArea> CustomerSalesAreas { get; set; } = [];
    public ICollection<Vendor> Vendors { get; set; } = [];
    public ICollection<VendorPurchasingOrganization> VendorPurchasingOrganizations { get; set; } = [];
}
