using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorContact.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorContact;

namespace EnterpriseMdmSolution.Application.Modules.VendorContact.Handlers;

public sealed class DeleteVendorContactHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteVendorContactCommand, bool>
{
    public async Task<bool> Handle(DeleteVendorContactCommand request, CancellationToken cancellationToken)
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