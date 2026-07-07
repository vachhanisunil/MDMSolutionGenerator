using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorTax.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorTax;

namespace EnterpriseMdmSolution.Application.Modules.VendorTax.Handlers;

public sealed class DeleteVendorTaxHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteVendorTaxCommand, bool>
{
    public async Task<bool> Handle(DeleteVendorTaxCommand request, CancellationToken cancellationToken)
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