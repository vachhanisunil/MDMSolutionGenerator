namespace EnterpriseMdmSolution.Core.Entities;

public class MaterialVendor : BaseEntity
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int VendorId { get; set; }
    public string? VendorMaterialNumber { get; set; }
    public int? LeadTimeDays { get; set; }
    public decimal? MinimumOrderQuantity { get; set; }
    public int? PurchaseUnitOfMeasureId { get; set; }
    public bool IsPreferred { get; set; }
    public Material? Material { get; set; }
    public Vendor? Vendor { get; set; }
    public UnitOfMeasure? UnitOfMeasure { get; set; }
}
