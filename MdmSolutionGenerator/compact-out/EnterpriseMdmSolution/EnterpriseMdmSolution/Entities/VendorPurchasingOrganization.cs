using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class VendorPurchasingOrganization : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int VendorId { get; set; }
    public int PurchasingOrganizationId { get; set; }
    public int? PaymentTermId { get; set; }
    [MaxLength(30)]
    public string? Incoterms { get; set; }
    public int? OrderCurrencyId { get; set; }
    [MaxLength(50)]
    public string? PurchaseGroup { get; set; }
    public decimal? MinimumOrderValue { get; set; }
    public bool IsBlockedForPurchasing { get; set; }
    public Vendor? Vendor { get; set; }
    public PurchasingOrganization? PurchasingOrganization { get; set; }
    public PaymentTerm? PaymentTerm { get; set; }
    public Currency? Currency { get; set; }
}
