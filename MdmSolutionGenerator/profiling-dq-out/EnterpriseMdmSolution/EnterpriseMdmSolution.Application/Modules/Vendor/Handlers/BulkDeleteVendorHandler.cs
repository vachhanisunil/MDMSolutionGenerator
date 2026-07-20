using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Vendor;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class BulkDeleteVendorHandler(IRepository<Entity> repository)
    : IRequestHandler<BulkDeleteVendorCommand, BulkVendorOperationResultDto>
{
    public async Task<BulkVendorOperationResultDto> Handle(BulkDeleteVendorCommand request, CancellationToken cancellationToken)
    {
        var deletedCount = 0;
        var notFoundIds = new List<int>();

        foreach (var id in request.Input.Ids)
        {
            var entity = await repository.GetByIdAsync(id, cancellationToken);
            if (entity is null)
            {
                notFoundIds.Add(id);
                continue;
            }

            repository.Delete(entity);
            deletedCount++;
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkVendorOperationResultDto
        {
            RequestedCount = request.Input.Ids.Count,
            DeletedCount = deletedCount,
            NotFoundIds = notFoundIds
        };
    }
}