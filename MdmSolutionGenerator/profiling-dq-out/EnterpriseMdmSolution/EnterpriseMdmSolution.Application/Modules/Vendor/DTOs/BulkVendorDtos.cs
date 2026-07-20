namespace EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;

public sealed class BulkCreateVendorDto
{
    public List<CreateVendorDto> Items { get; init; } = [];
}

public sealed class BulkUpdateVendorDto
{
    public List<UpdateVendorDto> Items { get; init; } = [];
}

public sealed class BulkUpsertVendorDto
{
    public List<UpdateVendorDto> Items { get; init; } = [];
}

public sealed class BulkDeleteVendorDto
{
    public List<int> Ids { get; init; } = [];
}

public sealed class BulkVendorOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<VendorDto> Items { get; init; } = [];
}