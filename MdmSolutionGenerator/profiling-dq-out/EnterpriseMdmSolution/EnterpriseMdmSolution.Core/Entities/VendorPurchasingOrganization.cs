namespace EnterpriseMdmSolution.Core.Entities;

public class VendorPurchasingOrganization : BaseEntity
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public int PurchasingOrganizationId { get; set; }
    public int? PaymentTermId { get; set; }
    public string? Incoterms { get; set; }
    public int? OrderCurrencyId { get; set; }
    public string? PurchaseGroup { get; set; }
    public decimal? MinimumOrderValue { get; set; }
    public bool IsBlockedForPurchasing { get; set; }
    public Vendor? Vendor { get; set; }
    public PurchasingOrganization? PurchasingOrganization { get; set; }
    public PaymentTerm? PaymentTerm { get; set; }
    public Currency? Currency { get; set; }
}
