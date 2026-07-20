using MediatR;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Handlers;

public sealed class BulkDeletePurchasingOrganizationHandler(IRepository<Entity> repository)
    : IRequestHandler<BulkDeletePurchasingOrganizationCommand, BulkPurchasingOrganizationOperationResultDto>
{
    public async Task<BulkPurchasingOrganizationOperationResultDto> Handle(BulkDeletePurchasingOrganizationCommand request, CancellationToken cancellationToken)
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
        return new BulkPurchasingOrganizationOperationResultDto
        {
            RequestedCount = request.Input.Ids.Count,
            DeletedCount = deletedCount,
            NotFoundIds = notFoundIds
        };
    }
}