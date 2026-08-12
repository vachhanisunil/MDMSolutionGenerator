namespace EnterpriseMdmSolution.DTOs;

public sealed class StorageLocationDto
{
    public int Id { get; set; }
    public string StorageLocationCode { get; set; } = string.Empty;
    public string StorageLocationName { get; set; } = string.Empty;
    public int PlantId { get; set; }
}

public sealed class CreateStorageLocationDto
{
    public string StorageLocationCode { get; set; } = string.Empty;
    public string StorageLocationName { get; set; } = string.Empty;
    public int PlantId { get; set; }
}

public sealed class UpdateStorageLocationDto
{
    public string StorageLocationCode { get; set; } = string.Empty;
    public string StorageLocationName { get; set; } = string.Empty;
    public int PlantId { get; set; }
}

public sealed class SearchStorageLocationDto : EnterpriseMdmSolution.Services.SearchRequest
{
}