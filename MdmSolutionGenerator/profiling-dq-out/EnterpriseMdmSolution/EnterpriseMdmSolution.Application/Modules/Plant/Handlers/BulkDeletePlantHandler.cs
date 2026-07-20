using MediatR;
using EnterpriseMdmSolution.Application.Modules.Plant.Commands;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Plant;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Handlers;

public sealed class BulkDeletePlantHandler(IRepository<Entity> repository)
    : IRequestHandler<BulkDeletePlantCommand, BulkPlantOperationResultDto>
{
    public async Task<BulkPlantOperationResultDto> Handle(BulkDeletePlantCommand request, CancellationToken cancellationToken)
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
        return new BulkPlantOperationResultDto
        {
            RequestedCount = request.Input.Ids.Count,
            DeletedCount = deletedCount,
            NotFoundIds = notFoundIds
        };
    }
}