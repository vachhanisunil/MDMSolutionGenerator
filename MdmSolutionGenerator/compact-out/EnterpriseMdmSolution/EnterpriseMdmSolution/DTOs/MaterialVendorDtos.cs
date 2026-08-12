namespace EnterpriseMdmSolution.DTOs;

public sealed class MaterialVendorDto
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int VendorId { get; set; }
    public string? VendorMaterialNumber { get; set; }
    public int? LeadTimeDays { get; set; }
    public decimal? MinimumOrderQuantity { get; set; }
    public int? PurchaseUnitOfMeasureId { get; set; }
    public bool IsPreferred { get; set; }
}

public sealed class CreateMaterialVendorDto
{
    public int MaterialId { get; set; }
    public int VendorId { get; set; }
    public string? VendorMaterialNumber { get; set; }
    public int? LeadTimeDays { get; set; }
    public decimal? MinimumOrderQuantity { get; set; }
    public int? PurchaseUnitOfMeasureId { get; set; }
    public bool IsPreferred { get; set; }
}

public sealed class UpdateMaterialVendorDto
{
    public int MaterialId { get; set; }
    public int VendorId { get; set; }
    public string? VendorMaterialNumber { get; set; }
    public int? LeadTimeDays { get; set; }
    public decimal? MinimumOrderQuantity { get; set; }
    public int? PurchaseUnitOfMeasureId { get; set; }
    public bool IsPreferred { get; set; }
}

public sealed class SearchMaterialVendorDto : EnterpriseMdmSolution.Services.SearchRequest
{
}