using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorCertificate;

namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.Handlers;

public sealed class DeleteVendorCertificateHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteVendorCertificateCommand, bool>
{
    public async Task<bool> Handle(DeleteVendorCertificateCommand request, CancellationToken cancellationToken)
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