namespace EnterpriseMdmSolution.Core.Entities;

public class MaterialStorage : BaseEntity
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int StorageLocationId { get; set; }
    public string? BinLocation { get; set; }
    public decimal? SafetyStock { get; set; }
    public decimal? MaximumStock { get; set; }
    public string? TemperatureZone { get; set; }
    public bool? HazardousStorageRequired { get; set; }
    public Material? Material { get; set; }
    public StorageLocation? StorageLocation { get; set; }
}
