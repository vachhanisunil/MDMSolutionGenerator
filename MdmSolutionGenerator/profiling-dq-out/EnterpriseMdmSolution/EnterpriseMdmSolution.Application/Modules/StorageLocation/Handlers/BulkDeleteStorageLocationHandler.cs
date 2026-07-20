using MediatR;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.StorageLocation;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Handlers;

public sealed class BulkDeleteStorageLocationHandler(IRepository<Entity> repository)
    : IRequestHandler<BulkDeleteStorageLocationCommand, BulkStorageLocationOperationResultDto>
{
    public async Task<BulkStorageLocationOperationResultDto> Handle(BulkDeleteStorageLocationCommand request, CancellationToken cancellationToken)
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
        return new BulkStorageLocationOperationResultDto
        {
            RequestedCount = request.Input.Ids.Count,
            DeletedCount = deletedCount,
            NotFoundIds = notFoundIds
        };
    }
}