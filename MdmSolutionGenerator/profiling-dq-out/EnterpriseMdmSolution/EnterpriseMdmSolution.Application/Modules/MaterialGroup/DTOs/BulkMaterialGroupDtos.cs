namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;

public sealed class BulkCreateMaterialGroupDto
{
    public List<CreateMaterialGroupDto> Items { get; init; } = [];
}

public sealed class BulkUpdateMaterialGroupDto
{
    public List<UpdateMaterialGroupDto> Items { get; init; } = [];
}

public sealed class BulkUpsertMaterialGroupDto
{
    public List<UpdateMaterialGroupDto> Items { get; init; } = [];
}

public sealed class BulkDeleteMaterialGroupDto
{
    public List<int> Ids { get; init; } = [];
}

public sealed class BulkMaterialGroupOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<MaterialGroupDto> Items { get; init; } = [];
}