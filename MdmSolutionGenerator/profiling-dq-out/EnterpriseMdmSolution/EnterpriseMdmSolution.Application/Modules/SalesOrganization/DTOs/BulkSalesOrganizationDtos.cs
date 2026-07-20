namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;

public sealed class BulkCreateSalesOrganizationDto
{
    public List<CreateSalesOrganizationDto> Items { get; init; } = [];
}

public sealed class BulkUpdateSalesOrganizationDto
{
    public List<UpdateSalesOrganizationDto> Items { get; init; } = [];
}

public sealed class BulkUpsertSalesOrganizationDto
{
    public List<UpdateSalesOrganizationDto> Items { get; init; } = [];
}

public sealed class BulkDeleteSalesOrganizationDto
{
    public List<int> Ids { get; init; } = [];
}

public sealed class BulkSalesOrganizationOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<SalesOrganizationDto> Items { get; init; } = [];
}