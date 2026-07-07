using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorAddress;

namespace EnterpriseMdmSolution.Application.Modules.VendorAddress.Handlers;

public sealed class DeleteVendorAddressHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteVendorAddressCommand, bool>
{
    public async Task<bool> Handle(DeleteVendorAddressCommand request, CancellationToken cancellationToken)
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