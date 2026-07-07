namespace EnterpriseMdmSolution.Application.Modules.Plant.DTOs;

public sealed class UpdatePlantDto
{
    public string PlantCode { get; init; } = string.Empty;
    public string PlantName { get; init; } = string.Empty;
    public int CountryId { get; init; }
}
