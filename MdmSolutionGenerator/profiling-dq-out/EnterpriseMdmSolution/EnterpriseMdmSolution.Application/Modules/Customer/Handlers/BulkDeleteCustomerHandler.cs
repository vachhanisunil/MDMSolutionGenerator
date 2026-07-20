using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Customer;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class BulkDeleteCustomerHandler(IRepository<Entity> repository)
    : IRequestHandler<BulkDeleteCustomerCommand, BulkCustomerOperationResultDto>
{
    public async Task<BulkCustomerOperationResultDto> Handle(BulkDeleteCustomerCommand request, CancellationToken cancellationToken)
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
        return new BulkCustomerOperationResultDto
        {
            RequestedCount = request.Input.Ids.Count,
            DeletedCount = deletedCount,
            NotFoundIds = notFoundIds
        };
    }
}