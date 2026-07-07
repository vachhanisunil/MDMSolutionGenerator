namespace EnterpriseMdmSolution.Core.Entities;

public class Material : BaseEntity
{
    public int Id { get; set; }
    public string MaterialNumber { get; set; } = string.Empty;
    public string MaterialName { get; set; } = string.Empty;
    public string MaterialType { get; set; } = string.Empty;
    public int MaterialGroupId { get; set; }
    public int BaseUnitOfMeasureId { get; set; }
    public string? GlobalTradeItemNumber { get; set; }
    public string? ProductHierarchy { get; set; }
    public decimal? GrossWeight { get; set; }
    public decimal? NetWeight { get; set; }
    public int? WeightUnitOfMeasureId { get; set; }
    public bool IsBatchManaged { get; set; }
    public bool IsSerialManaged { get; set; }
    public bool IsActive { get; set; }
    public MaterialGroup? MaterialGroup { get; set; }
    public UnitOfMeasure? UnitOfMeasure { get; set; }
    public ICollection<MaterialPlant> MaterialPlants { get; set; } = [];
    public ICollection<MaterialPrice> MaterialPrices { get; set; } = [];
    public ICollection<MaterialStorage> MaterialStorages { get; set; } = [];
    public ICollection<MaterialClassification> MaterialClassifications { get; set; } = [];
    public ICollection<MaterialVendor> MaterialVendors { get; set; } = [];
    public ICollection<MaterialUOM> MaterialUOMs { get; set; } = [];
    public ICollection<MaterialQualityInspection> MaterialQualityInspections { get; set; } = [];
    public ICollection<MaterialForecast> MaterialForecasts { get; set; } = [];
    public ICollection<MaterialBarcode> MaterialBarcodes { get; set; } = [];
}
