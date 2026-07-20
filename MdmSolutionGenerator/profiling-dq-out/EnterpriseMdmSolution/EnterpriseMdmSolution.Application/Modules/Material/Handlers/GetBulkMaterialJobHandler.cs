using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class GetBulkMaterialJobHandler(
    IRepository<BulkOperationJob> jobRepository,
    IRepository<BulkOperationItem> itemRepository)
    : IRequestHandler<GetBulkMaterialJobQuery, BulkMaterialJobDto?>
{
    public async Task<BulkMaterialJobDto?> Handle(GetBulkMaterialJobQuery request, CancellationToken cancellationToken)
    {
        var job = await jobRepository.GetByIdAsync(request.JobId, cancellationToken);
        if (job is null || job.BusinessObjectName != "Material")
        {
            return null;
        }

        var items = (await itemRepository.ListAsync(cancellationToken))
            .Where(x => x.JobId == job.JobId)
            .OrderBy(x => x.SequenceNumber)
            .ToList();

        return new BulkMaterialJobDto
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
}