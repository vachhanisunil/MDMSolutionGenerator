using System.Text.Json;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class BulkCreateCustomerHandler(
    IRepository<BulkOperationJob> jobRepository,
    IRepository<BulkOperationItem> itemRepository)
    : IRequestHandler<BulkCreateCustomerCommand, BulkCustomerJobDto>
{
    public async Task<BulkCustomerJobDto> Handle(BulkCreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var job = new BulkOperationJob
        {
            JobId = Guid.NewGuid(),
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            Operation = "BulkCreate",
            Status = "Queued",
            RequestedCount = request.Input.Items.Count,
            QueuedOn = DateTimeOffset.UtcNow,
            TriggeredBy = string.IsNullOrWhiteSpace(request.Input.TriggeredBy) ? "system" : request.Input.TriggeredBy,
            InputSnapshotJson = JsonSerializer.Serialize(request.Input)
        };

        await jobRepository.AddAsync(job, cancellationToken);

        var sequenceNumber = 1;
        foreach (var inputItem in request.Input.Items)
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

    private static BulkCustomerJobDto MapBulkJob(BulkOperationJob job, IReadOnlyList<BulkOperationItem> items)
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
            Items = items.Select(item => new BulkCustomerJobItemDto
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