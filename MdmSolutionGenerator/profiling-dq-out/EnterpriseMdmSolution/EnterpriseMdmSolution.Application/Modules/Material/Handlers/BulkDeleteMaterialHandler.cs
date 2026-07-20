using System.Text.Json;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class BulkDeleteMaterialHandler(
    IRepository<BulkOperationJob> jobRepository,
    IRepository<BulkOperationItem> itemRepository)
    : IRequestHandler<BulkDeleteMaterialCommand, BulkMaterialJobDto>
{
    public async Task<BulkMaterialJobDto> Handle(BulkDeleteMaterialCommand request, CancellationToken cancellationToken)
    {
        var job = new BulkOperationJob
        {
            JobId = Guid.NewGuid(),
            BusinessObjectName = "Material",
            EntityName = "Material",
            Operation = "BulkDelete",
            Status = "Queued",
            RequestedCount = request.Input.Ids.Count,
            QueuedOn = DateTimeOffset.UtcNow,
            TriggeredBy = string.IsNullOrWhiteSpace(request.Input.TriggeredBy) ? "system" : request.Input.TriggeredBy,
            InputSnapshotJson = JsonSerializer.Serialize(request.Input)
        };

        await jobRepository.AddAsync(job, cancellationToken);

        var sequenceNumber = 1;
        foreach (var inputItem in request.Input.Ids)
        {
            await itemRepository.AddAsync(new BulkOperationItem
            {
                ItemId = Guid.NewGuid(),
                JobId = job.JobId,
                SequenceNumber = sequenceNumber++,
                Status = "Queued",
                InputSnapshotJson = JsonSerializer.Serialize(inputItem)
            }, cancellationToken);
        }

        await jobRepository.SaveChangesAsync(cancellationToken);
        var items = (await itemRepository.ListAsync(cancellationToken)).Where(x => x.JobId == job.JobId).OrderBy(x => x.SequenceNumber).ToList();
        return MapBulkJob(job, items);
    }

    private static BulkMaterialJobDto MapBulkJob(BulkOperationJob job, IReadOnlyList<BulkOperationItem> items)
        => new()
        {
            JobId = job.JobId,
            BusinessObjectName = job.BusinessObjectName,
            EntityName = job.EntityName,
            Operation = job.Operation,
            Status = job.Status,
            RequestedCount = job.RequestedCount,
            CreatedCount = job.CreatedCount,
            UpdatedCount = job.UpdatedCount,
            DeletedCount = job.DeletedCount,
            FailedCount = job.FailedCount,
            QueuedOn = job.QueuedOn,
            StartedOn = job.StartedOn,
            CompletedOn = job.CompletedOn,
            TriggeredBy = job.TriggeredBy,
            ErrorMessage = job.ErrorMessage,
            Items = items.Select(item => new BulkMaterialJobItemDto
            {
                ItemId = item.ItemId,
                JobId = item.JobId,
                SequenceNumber = item.SequenceNumber,
                Status = item.Status,
                RecordId = item.RecordId,
                ErrorMessage = item.ErrorMessage,
                InputSnapshotJson = item.InputSnapshotJson,
                ResultSnapshotJson = item.ResultSnapshotJson
            }).ToList()
        };
}