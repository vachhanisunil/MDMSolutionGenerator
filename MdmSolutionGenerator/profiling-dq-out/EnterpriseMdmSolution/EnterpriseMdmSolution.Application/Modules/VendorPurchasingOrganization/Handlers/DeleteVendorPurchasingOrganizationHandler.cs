using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Handlers;

public sealed class DeleteVendorPurchasingOrganizationHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteVendorPurchasingOrganizationCommand, bool>
{
    public async Task<bool> Handle(DeleteVendorPurchasingOrganizationCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null)
        {
            return false;
        }

        repository.Delete(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }
}