namespace EnterpriseMdmSolution.Application.Modules.Material.DTOs;

public sealed class BulkCreateMaterialDto
{
    public List<CreateMaterialDto> Items { get; init; } = [];
}

public sealed class BulkUpdateMaterialDto
{
    public List<UpdateMaterialDto> Items { get; init; } = [];
}

public sealed class BulkUpsertMaterialDto
{
    public List<UpdateMaterialDto> Items { get; init; } = [];
}

public sealed class BulkDeleteMaterialDto
{
    public List<int> Ids { get; init; } = [];
}

public sealed class BulkMaterialOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<MaterialDto> Items { get; init; } = [];
}