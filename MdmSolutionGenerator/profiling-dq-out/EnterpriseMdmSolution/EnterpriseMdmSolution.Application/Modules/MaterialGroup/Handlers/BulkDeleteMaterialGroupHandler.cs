using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialGroup;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Handlers;

public sealed class BulkDeleteMaterialGroupHandler(IRepository<Entity> repository)
    : IRequestHandler<BulkDeleteMaterialGroupCommand, BulkMaterialGroupOperationResultDto>
{
    public async Task<BulkMaterialGroupOperationResultDto> Handle(BulkDeleteMaterialGroupCommand request, CancellationToken cancellationToken)
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
        return new BulkMaterialGroupOperationResultDto
        {
            RequestedCount = request.Input.Ids.Count,
            DeletedCount = deletedCount,
            NotFoundIds = notFoundIds
        };
    }
}