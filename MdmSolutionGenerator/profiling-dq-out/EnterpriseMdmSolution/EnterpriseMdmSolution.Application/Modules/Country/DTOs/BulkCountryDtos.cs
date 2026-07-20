namespace EnterpriseMdmSolution.Application.Modules.Country.DTOs;

public sealed class BulkCreateCountryDto
{
    public List<CreateCountryDto> Items { get; init; } = [];
}

public sealed class BulkUpdateCountryDto
{
    public List<UpdateCountryDto> Items { get; init; } = [];
}

public sealed class BulkUpsertCountryDto
{
    public List<UpdateCountryDto> Items { get; init; } = [];
}

public sealed class BulkDeleteCountryDto
{
    public List<int> Ids { get; init; } = [];
}

public sealed class BulkCountryOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<CountryDto> Items { get; init; } = [];
}