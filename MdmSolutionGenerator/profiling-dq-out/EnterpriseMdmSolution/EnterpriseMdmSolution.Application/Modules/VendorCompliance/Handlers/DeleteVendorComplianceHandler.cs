using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorCompliance;

namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.Handlers;

public sealed class DeleteVendorComplianceHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteVendorComplianceCommand, bool>
{
    public async Task<bool> Handle(DeleteVendorComplianceCommand request, CancellationToken cancellationToken)
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