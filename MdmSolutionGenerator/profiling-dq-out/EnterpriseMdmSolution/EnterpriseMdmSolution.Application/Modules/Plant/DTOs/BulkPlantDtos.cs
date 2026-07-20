namespace EnterpriseMdmSolution.Application.Modules.Plant.DTOs;

public sealed class BulkCreatePlantDto
{
    public List<CreatePlantDto> Items { get; init; } = [];
    public string TriggeredBy { get; init; } = "system";
}

public sealed class BulkUpsertPlantDto
{
    public List<UpdatePlantDto> Items { get; init; } = [];
    public string TriggeredBy { get; init; } = "system";
}

public sealed class BulkDeletePlantDto
{
    public List<int> Ids { get; init; } = [];
    public string TriggeredBy { get; init; } = "system";
}

public sealed class BulkPlantOperationResultDto
{
    public int RequestedCount { get; init; }
    public int CreatedCount { get; init; }
    public int UpdatedCount { get; init; }
    public int DeletedCount { get; init; }
    public int NotFoundCount => NotFoundIds.Count;
    public List<int> NotFoundIds { get; init; } = [];
    public IReadOnlyList<PlantDto> Items { get; init; } = [];
}

public sealed class BulkPlantJobDto
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
    public IReadOnlyList<BulkPlantJobItemDto> Items { get; init; } = [];
}

public sealed class BulkPlantJobItemDto
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