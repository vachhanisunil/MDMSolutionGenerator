namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;

public sealed class BulkCreateUnitOfMeasureDto
{
    public List<CreateUnitOfMeasureDto> Items { get; init; } = [];
}

public sealed class BulkUpdateUnitOfMeasureDto
{
    public List<UpdateUnitOfMeasureDto> Items { get; init; } = [];
}

public sealed class BulkUpsertUnitOfMeasureDto
{
    public List<UpdateUnitOfMeasureDto> Items { get; init; } = [];
}

public sealed class BulkDeleteUnitOfMeasureDto
{
    public List<int> Ids { get; init; } = [];
}

public sealed class BulkUnitOfMeasureOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<UnitOfMeasureDto> Items { get; init; } = [];
}