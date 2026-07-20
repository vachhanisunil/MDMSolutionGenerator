namespace EnterpriseMdmSolution.Application.Modules.Customer.DTOs;

public sealed class BulkCreateCustomerDto
{
    public List<CreateCustomerDto> Items { get; init; } = [];
}

public sealed class BulkUpdateCustomerDto
{
    public List<UpdateCustomerDto> Items { get; init; } = [];
}

public sealed class BulkUpsertCustomerDto
{
    public List<UpdateCustomerDto> Items { get; init; } = [];
}

public sealed class BulkDeleteCustomerDto
{
    public List<int> Ids { get; init; } = [];
}

public sealed class BulkCustomerOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<CustomerDto> Items { get; init; } = [];
}