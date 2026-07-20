using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Material;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class BulkDeleteMaterialHandler(IRepository<Entity> repository)
    : IRequestHandler<BulkDeleteMaterialCommand, BulkMaterialOperationResultDto>
{
    public async Task<BulkMaterialOperationResultDto> Handle(BulkDeleteMaterialCommand request, CancellationToken cancellationToken)
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
        return new BulkMaterialOperationResultDto
        {
            RequestedCount = request.Input.Ids.Count,
            DeletedCount = deletedCount,
            NotFoundIds = notFoundIds
        };
    }
}