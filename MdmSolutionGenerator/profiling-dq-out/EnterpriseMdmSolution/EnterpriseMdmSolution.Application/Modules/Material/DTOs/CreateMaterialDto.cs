namespace EnterpriseMdmSolution.Application.Modules.Material.DTOs;

public sealed class CreateMaterialDto
{
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
    public List<EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs.CreateMaterialPlantDto> MaterialPlants { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs.CreateMaterialPriceDto> MaterialPrices { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs.CreateMaterialStorageDto> MaterialStorages { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs.CreateMaterialClassificationDto> MaterialClassifications { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs.CreateMaterialVendorDto> MaterialVendors { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs.CreateMaterialUOMDto> MaterialUOMs { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs.CreateMaterialQualityInspectionDto> MaterialQualityInspections { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs.CreateMaterialForecastDto> MaterialForecasts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs.CreateMaterialBarcodeDto> MaterialBarcodes { get; init; } = [];
}
