namespace EnterpriseMdmSolution.DTOs;

public sealed class VendorPurchasingOrganizationDto
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
}

public sealed class CreateVendorPurchasingOrganizationDto
{
    public int VendorId { get; set; }
    public int PurchasingOrganizationId { get; set; }
    public int? PaymentTermId { get; set; }
    public string? Incoterms { get; set; }
    public int? OrderCurrencyId { get; set; }
    public string? PurchaseGroup { get; set; }
    public decimal? MinimumOrderValue { get; set; }
    public bool IsBlockedForPurchasing { get; set; }
}

public sealed class UpdateVendorPurchasingOrganizationDto
{
    public int VendorId { get; set; }
    public int PurchasingOrganizationId { get; set; }
    public int? PaymentTermId { get; set; }
    public string? Incoterms { get; set; }
    public int? OrderCurrencyId { get; set; }
    public string? PurchaseGroup { get; set; }
    public decimal? MinimumOrderValue { get; set; }
    public bool IsBlockedForPurchasing { get; set; }
}

public sealed class SearchVendorPurchasingOrganizationDto : EnterpriseMdmSolution.Services.SearchRequest
{
}