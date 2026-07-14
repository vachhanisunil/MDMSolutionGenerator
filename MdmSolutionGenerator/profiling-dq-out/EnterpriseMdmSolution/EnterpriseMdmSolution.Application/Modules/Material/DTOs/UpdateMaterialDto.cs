namespace EnterpriseMdmSolution.Application.Modules.Material.DTOs;

public sealed class UpdateMaterialDto
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
    public List<EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs.UpdateMaterialPlantDto> MaterialPlants { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs.UpdateMaterialPriceDto> MaterialPrices { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs.UpdateMaterialStorageDto> MaterialStorages { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs.UpdateMaterialClassificationDto> MaterialClassifications { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs.UpdateMaterialVendorDto> MaterialVendors { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs.UpdateMaterialUOMDto> MaterialUOMs { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs.UpdateMaterialQualityInspectionDto> MaterialQualityInspections { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs.UpdateMaterialForecastDto> MaterialForecasts { get; init; } = [];
    public List<EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs.UpdateMaterialBarcodeDto> MaterialBarcodes { get; init; } = [];

    public int Id { get; init; }
}
