namespace EnterpriseMdmSolution.Core.Entities;

public class Plant : BaseEntity
{
    public int Id { get; set; }
    public string PlantCode { get; set; } = string.Empty;
    public string PlantName { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public ICollection<MaterialPlant> MaterialPlants { get; set; } = [];
    public ICollection<MaterialForecast> MaterialForecasts { get; set; } = [];
    public Country? Country { get; set; }
    public ICollection<StorageLocation> StorageLocations { get; set; } = [];
}
