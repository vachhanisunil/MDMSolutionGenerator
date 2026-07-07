using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialVendor;

namespace EnterpriseMdmSolution.Application.Modules.MaterialVendor.Handlers;

public sealed class DeleteMaterialVendorHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteMaterialVendorCommand, bool>
{
    public async Task<bool> Handle(DeleteMaterialVendorCommand request, CancellationToken cancellationToken)
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