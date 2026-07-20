namespace EnterpriseMdmSolution.Application.Modules.Plant.DTOs;

public sealed class BulkCreatePlantDto
{
    public List<CreatePlantDto> Items { get; init; } = [];
}

public sealed class BulkUpdatePlantDto
{
    public List<UpdatePlantDto> Items { get; init; } = [];
}

public sealed class BulkUpsertPlantDto
{
    public List<UpdatePlantDto> Items { get; init; } = [];
}

public sealed class BulkDeletePlantDto
{
    public List<int> Ids { get; init; } = [];
}

public sealed class BulkPlantOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<PlantDto> Items { get; init; } = [];
}