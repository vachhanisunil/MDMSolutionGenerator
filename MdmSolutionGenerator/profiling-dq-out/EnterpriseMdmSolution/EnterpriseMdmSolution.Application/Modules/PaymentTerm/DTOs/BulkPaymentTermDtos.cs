namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;

public sealed class BulkCreatePaymentTermDto
{
    public List<CreatePaymentTermDto> Items { get; init; } = [];
}

public sealed class BulkUpdatePaymentTermDto
{
    public List<UpdatePaymentTermDto> Items { get; init; } = [];
}

public sealed class BulkUpsertPaymentTermDto
{
    public List<UpdatePaymentTermDto> Items { get; init; } = [];
}

public sealed class BulkDeletePaymentTermDto
{
    public List<int> Ids { get; init; } = [];
}

public sealed class BulkPaymentTermOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<PaymentTermDto> Items { get; init; } = [];
}