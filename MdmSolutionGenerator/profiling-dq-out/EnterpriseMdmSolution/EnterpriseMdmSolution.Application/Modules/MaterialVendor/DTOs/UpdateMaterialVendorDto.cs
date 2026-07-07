namespace EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs;

public sealed class UpdateMaterialVendorDto
{
    public int MaterialId { get; init; }
    public int VendorId { get; init; }
    public string? VendorMaterialNumber { get; init; }
    public int? LeadTimeDays { get; init; }
    public decimal? MinimumOrderQuantity { get; init; }
    public int? PurchaseUnitOfMeasureId { get; init; }
    public bool IsPreferred { get; init; }
}
