using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class MaterialStorage : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int StorageLocationId { get; set; }
    [MaxLength(50)]
    public string? BinLocation { get; set; }
    public decimal? SafetyStock { get; set; }
    public decimal? MaximumStock { get; set; }
    [MaxLength(30)]
    public string? TemperatureZone { get; set; }
    public bool? HazardousStorageRequired { get; set; }
    public Material? Material { get; set; }
    public StorageLocation? StorageLocation { get; set; }
}
