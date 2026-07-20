namespace EnterpriseMdmSolution.Application.Modules.Material.DTOs;

public sealed class BulkCreateMaterialDto
{
    public List<CreateMaterialDto> Items { get; init; } = [];
    public string TriggeredBy { get; init; } = "system";
}

public sealed class BulkUpsertMaterialDto
{
    public List<UpdateMaterialDto> Items { get; init; } = [];
    public string TriggeredBy { get; init; } = "system";
}

public sealed class BulkDeleteMaterialDto
{
    public List<int> Ids { get; init; } = [];
    public string TriggeredBy { get; init; } = "system";
}

public sealed class BulkMaterialOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<MaterialDto> Items { get; init; } = [];
}

public sealed class BulkMaterialJobDto
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
    public IReadOnlyList<BulkMaterialJobItemDto> Items { get; init; } = [];
}

public sealed class BulkMaterialJobItemDto
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