namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;

public sealed class CreateStorageLocationDto
{
    public string StorageLocationCode { get; init; } = string.Empty;
    public string StorageLocationName { get; init; } = string.Empty;
    public int PlantId { get; init; }
}
