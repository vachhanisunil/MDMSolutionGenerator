using MediatR;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.SalesOrganization;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Handlers;

public sealed class BulkDeleteSalesOrganizationHandler(IRepository<Entity> repository)
    : IRequestHandler<BulkDeleteSalesOrganizationCommand, BulkSalesOrganizationOperationResultDto>
{
    public async Task<BulkSalesOrganizationOperationResultDto> Handle(BulkDeleteSalesOrganizationCommand request, CancellationToken cancellationToken)
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
        return new BulkSalesOrganizationOperationResultDto
        {
            RequestedCount = request.Input.Ids.Count,
            DeletedCount = deletedCount,
            NotFoundIds = notFoundIds
        };
    }
}