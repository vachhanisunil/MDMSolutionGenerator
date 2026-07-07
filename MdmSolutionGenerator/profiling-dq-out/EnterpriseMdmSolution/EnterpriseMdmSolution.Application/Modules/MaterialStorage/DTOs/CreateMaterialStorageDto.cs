namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs;

public sealed class CreateMaterialStorageDto
{
    public int MaterialId { get; init; }
    public int StorageLocationId { get; init; }
    public string? BinLocation { get; init; }
    public decimal? SafetyStock { get; init; }
    public decimal? MaximumStock { get; init; }
    public string? TemperatureZone { get; init; }
    public bool? HazardousStorageRequired { get; init; }
}
