namespace EnterpriseMdmSolution.DTOs;

public sealed class MaterialStorageDto
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int StorageLocationId { get; set; }
    public string? BinLocation { get; set; }
    public decimal? SafetyStock { get; set; }
    public decimal? MaximumStock { get; set; }
    public string? TemperatureZone { get; set; }
    public bool? HazardousStorageRequired { get; set; }
}

public sealed class CreateMaterialStorageDto
{
    public int MaterialId { get; set; }
    public int StorageLocationId { get; set; }
    public string? BinLocation { get; set; }
    public decimal? SafetyStock { get; set; }
    public decimal? MaximumStock { get; set; }
    public string? TemperatureZone { get; set; }
    public bool? HazardousStorageRequired { get; set; }
}

public sealed class UpdateMaterialStorageDto
{
    public int MaterialId { get; set; }
    public int StorageLocationId { get; set; }
    public string? BinLocation { get; set; }
    public decimal? SafetyStock { get; set; }
    public decimal? MaximumStock { get; set; }
    public string? TemperatureZone { get; set; }
    public bool? HazardousStorageRequired { get; set; }
}

public sealed class SearchMaterialStorageDto : EnterpriseMdmSolution.Services.SearchRequest
{
}