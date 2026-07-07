namespace EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.DTOs;

public sealed class UpdateVendorPurchasingOrganizationDto
{
    public int VendorId { get; init; }
    public int PurchasingOrganizationId { get; init; }
    public int? PaymentTermId { get; init; }
    public string? Incoterms { get; init; }
    public int? OrderCurrencyId { get; init; }
    public string? PurchaseGroup { get; init; }
    public decimal? MinimumOrderValue { get; init; }
    public bool IsBlockedForPurchasing { get; init; }
}
