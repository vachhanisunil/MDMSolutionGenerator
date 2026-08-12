using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class Plant : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(10)]
    public string PlantCode { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    public string PlantName { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public ICollection<MaterialPlant> MaterialPlants { get; set; } = [];
    public ICollection<MaterialForecast> MaterialForecasts { get; set; } = [];
    public ICollection<StorageLocation> StorageLocations { get; set; } = [];
}
