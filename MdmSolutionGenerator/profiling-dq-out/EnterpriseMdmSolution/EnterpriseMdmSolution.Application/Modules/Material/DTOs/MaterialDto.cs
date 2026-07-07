namespace EnterpriseMdmSolution.Application.Modules.Material.DTOs;

public sealed class MaterialDto
{
    public int Id { get; init; }
    public string MaterialNumber { get; init; } = string.Empty;
    public string MaterialName { get; init; } = string.Empty;
    public string MaterialType { get; init; } = string.Empty;
    public int MaterialGroupId { get; init; }
    public int BaseUnitOfMeasureId { get; init; }
    public string? GlobalTradeItemNumber { get; init; }
    public string? ProductHierarchy { get; init; }
    public decimal? GrossWeight { get; init; }
    public decimal? NetWeight { get; init; }
    public int? WeightUnitOfMeasureId { get; init; }
    public bool IsBatchManaged { get; init; }
    public bool IsSerialManaged { get; init; }
    public bool IsActive { get; init; }
    public List<EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs.MaterialPlantDto> MaterialPlants { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs.MaterialPriceDto> MaterialPrices { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs.MaterialStorageDto> MaterialStorages { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs.MaterialClassificationDto> MaterialClassifications { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs.MaterialVendorDto> MaterialVendors { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs.MaterialUOMDto> MaterialUOMs { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs.MaterialQualityInspectionDto> MaterialQualityInspections { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs.MaterialForecastDto> MaterialForecasts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs.MaterialBarcodeDto> MaterialBarcodes { get; init; } = [];
}
