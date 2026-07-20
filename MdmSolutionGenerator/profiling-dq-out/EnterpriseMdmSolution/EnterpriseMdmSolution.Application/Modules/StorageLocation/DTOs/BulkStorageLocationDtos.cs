namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;

public sealed class BulkCreateStorageLocationDto
{
    public List<CreateStorageLocationDto> Items { get; init; } = [];
}

public sealed class BulkUpdateStorageLocationDto
{
    public List<UpdateStorageLocationDto> Items { get; init; } = [];
}

public sealed class BulkUpsertStorageLocationDto
{
    public List<UpdateStorageLocationDto> Items { get; init; } = [];
}

public sealed class BulkDeleteStorageLocationDto
{
    public List<int> Ids { get; init; } = [];
}

public sealed class BulkStorageLocationOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<StorageLocationDto> Items { get; init; } = [];
}