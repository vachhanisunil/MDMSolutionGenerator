using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class PurchasingOrganization : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(10)]
    public string PurchasingOrganizationCode { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    public string PurchasingOrganizationName { get; set; } = string.Empty;
    public int CurrencyId { get; set; }
    public Currency? Currency { get; set; }
    public ICollection<VendorPurchasingOrganization> VendorPurchasingOrganizations { get; set; } = [];
}
