using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Application.Modules.Customer.Queries;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class GetBulkCustomerJobHandler(
    IRepository<BulkOperationJob> jobRepository,
    IRepository<BulkOperationItem> itemRepository)
    : IRequestHandler<GetBulkCustomerJobQuery, BulkCustomerJobDto?>
{
    public async Task<BulkCustomerJobDto?> Handle(GetBulkCustomerJobQuery request, CancellationToken cancellationToken)
    {
        var job = await jobRepository.GetByIdAsync(request.JobId, cancellationToken);
        if (job is null || job.BusinessObjectName != "Customer")
        {
            return null;
        }

        var items = (await itemRepository.ListAsync(cancellationToken))
            .Where(x => x.JobId == job.JobId)
            .OrderBy(x => x.SequenceNumber)
            .ToList();

        return new BulkCustomerJobDto
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
}