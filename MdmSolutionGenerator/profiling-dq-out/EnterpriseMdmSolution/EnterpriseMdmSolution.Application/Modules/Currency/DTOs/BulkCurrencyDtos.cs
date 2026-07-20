namespace EnterpriseMdmSolution.Application.Modules.Currency.DTOs;

public sealed class BulkCreateCurrencyDto
{
    public List<CreateCurrencyDto> Items { get; init; } = [];
}

public sealed class BulkUpdateCurrencyDto
{
    public List<UpdateCurrencyDto> Items { get; init; } = [];
}

public sealed class BulkUpsertCurrencyDto
{
    public List<UpdateCurrencyDto> Items { get; init; } = [];
}

public sealed class BulkDeleteCurrencyDto
{
    public List<int> Ids { get; init; } = [];
}

public sealed class BulkCurrencyOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<CurrencyDto> Items { get; init; } = [];
}