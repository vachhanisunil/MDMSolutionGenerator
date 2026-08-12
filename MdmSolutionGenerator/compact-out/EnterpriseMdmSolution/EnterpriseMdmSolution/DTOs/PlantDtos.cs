namespace EnterpriseMdmSolution.DTOs;

public sealed class PlantDto
{
    public int Id { get; set; }
    public string PlantCode { get; set; } = string.Empty;
    public string PlantName { get; set; } = string.Empty;
    public int CountryId { get; set; }
}

public sealed class CreatePlantDto
{
    public string PlantCode { get; set; } = string.Empty;
    public string PlantName { get; set; } = string.Empty;
    public int CountryId { get; set; }
}

public sealed class UpdatePlantDto
{
    public string PlantCode { get; set; } = string.Empty;
    public string PlantName { get; set; } = string.Empty;
    public int CountryId { get; set; }
}

public sealed class SearchPlantDto : EnterpriseMdmSolution.Services.SearchRequest
{
}