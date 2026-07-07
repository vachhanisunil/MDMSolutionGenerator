namespace EnterpriseMdmSolution.Application.Modules.Plant.DTOs;

public sealed class PlantDto
{
    public int Id { get; init; }
    public string PlantCode { get; init; } = string.Empty;
    public string PlantName { get; init; } = string.Empty;
    public int CountryId { get; init; }
}
