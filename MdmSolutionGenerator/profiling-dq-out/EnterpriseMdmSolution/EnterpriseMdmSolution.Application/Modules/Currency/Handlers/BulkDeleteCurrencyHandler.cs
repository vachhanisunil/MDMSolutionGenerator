using MediatR;
using EnterpriseMdmSolution.Application.Modules.Currency.Commands;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Currency;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Handlers;

public sealed class BulkDeleteCurrencyHandler(IRepository<Entity> repository)
    : IRequestHandler<BulkDeleteCurrencyCommand, BulkCurrencyOperationResultDto>
{
    public async Task<BulkCurrencyOperationResultDto> Handle(BulkDeleteCurrencyCommand request, CancellationToken cancellationToken)
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
        return new BulkCurrencyOperationResultDto
        {
            RequestedCount = request.Input.Ids.Count,
            DeletedCount = deletedCount,
            NotFoundIds = notFoundIds
        };
    }
}