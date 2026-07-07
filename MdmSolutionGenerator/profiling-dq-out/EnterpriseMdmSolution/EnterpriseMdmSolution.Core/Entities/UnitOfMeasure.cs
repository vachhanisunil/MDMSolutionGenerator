namespace EnterpriseMdmSolution.Core.Entities;

public class UnitOfMeasure : BaseEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Dimension { get; set; }
    public ICollection<Material> Materials { get; set; } = [];
    public ICollection<MaterialVendor> MaterialVendors { get; set; } = [];
    public ICollection<MaterialUOM> MaterialUOMs { get; set; } = [];
    public ICollection<MaterialForecast> MaterialForecasts { get; set; } = [];
    public ICollection<MaterialBarcode> MaterialBarcodes { get; set; } = [];
}
