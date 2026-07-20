namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;

public sealed class BulkCreatePurchasingOrganizationDto
{
    public List<CreatePurchasingOrganizationDto> Items { get; init; } = [];
}

public sealed class BulkUpdatePurchasingOrganizationDto
{
    public List<UpdatePurchasingOrganizationDto> Items { get; init; } = [];
}

public sealed class BulkUpsertPurchasingOrganizationDto
{
    public List<UpdatePurchasingOrganizationDto> Items { get; init; } = [];
}

public sealed class BulkDeletePurchasingOrganizationDto
{
    public List<int> Ids { get; init; } = [];
}

public sealed class BulkPurchasingOrganizationOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<PurchasingOrganizationDto> Items { get; init; } = [];
}