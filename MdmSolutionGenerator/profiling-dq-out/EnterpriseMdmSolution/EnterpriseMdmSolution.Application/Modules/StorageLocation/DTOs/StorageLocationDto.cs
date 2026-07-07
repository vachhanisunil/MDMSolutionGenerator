namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;

public sealed class StorageLocationDto
{
    public int Id { get; init; }
    public string StorageLocationCode { get; init; } = string.Empty;
    public string StorageLocationName { get; init; } = string.Empty;
    public int PlantId { get; init; }
}
