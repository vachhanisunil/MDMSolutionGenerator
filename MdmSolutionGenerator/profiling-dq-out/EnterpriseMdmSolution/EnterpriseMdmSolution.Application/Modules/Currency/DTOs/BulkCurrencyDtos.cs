namespace EnterpriseMdmSolution.Application.Modules.Currency.DTOs;

public sealed class BulkCreateCurrencyDto
{
    public List<CreateCurrencyDto> Items { get; init; } = [];
    public string TriggeredBy { get; init; } = "system";
}

public sealed class BulkUpsertCurrencyDto
{
    public List<UpdateCurrencyDto> Items { get; init; } = [];
    public string TriggeredBy { get; init; } = "system";
}

public sealed class BulkDeleteCurrencyDto
{
    public List<int> Ids { get; init; } = [];
    public string TriggeredBy { get; init; } = "system";
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

public sealed class BulkCurrencyJobDto
{
    public Guid JobId { get; init; }
    public string BusinessObjectName { get; init; } = string.Empty;
    public string EntityName { get; init; } = string.Empty;
    public string Operation { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int FailedCount { get; init; }
    public DateTimeOffset QueuedOn { get; init; }
    public DateTimeOffset? StartedOn { get; init; }
    public DateTimeOffset? CompletedOn { get; init; }
    public string TriggeredBy { get; init; } = string.Empty;
    public string? ErrorMessage { get; init; }
    public IReadOnlyList<BulkCurrencyJobItemDto> Items { get; init; } = [];
}

public sealed class BulkCurrencyJobItemDto
{
    public Guid ItemId { get; init; }
    public Guid JobId { get; init; }
    public int SequenceNumber { get; init; }
    public string Status { get; init; } = string.Empty;
    public string? RecordId { get; init; }
    public string? ErrorMessage { get; init; }
    public string InputSnapshotJson { get; init; } = string.Empty;
    public string ResultSnapshotJson { get; init; } = string.Empty;
}