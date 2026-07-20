using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class GetBulkVendorJobHandler(
    IRepository<BulkOperationJob> jobRepository,
    IRepository<BulkOperationItem> itemRepository)
    : IRequestHandler<GetBulkVendorJobQuery, BulkVendorJobDto?>
{
    public async Task<BulkVendorJobDto?> Handle(GetBulkVendorJobQuery request, CancellationToken cancellationToken)
    {
        var job = await jobRepository.GetByIdAsync(request.JobId, cancellationToken);
        if (job is null || job.BusinessObjectName != "Vendor")
        {
            return null;
        }

        var items = (await itemRepository.ListAsync(cancellationToken))
            .Where(x => x.JobId == job.JobId)
            .OrderBy(x => x.SequenceNumber)
            .ToList();

        return new BulkVendorJobDto
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
            Items = items.Select(item => new BulkVendorJobItemDto
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