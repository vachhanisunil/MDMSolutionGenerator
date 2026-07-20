using MediatR;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.UnitOfMeasure;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Handlers;

public sealed class BulkDeleteUnitOfMeasureHandler(IRepository<Entity> repository)
    : IRequestHandler<BulkDeleteUnitOfMeasureCommand, BulkUnitOfMeasureOperationResultDto>
{
    public async Task<BulkUnitOfMeasureOperationResultDto> Handle(BulkDeleteUnitOfMeasureCommand request, CancellationToken cancellationToken)
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
        return new BulkUnitOfMeasureOperationResultDto
        {
            RequestedCount = request.Input.Ids.Count,
            DeletedCount = deletedCount,
            NotFoundIds = notFoundIds
        };
    }
}