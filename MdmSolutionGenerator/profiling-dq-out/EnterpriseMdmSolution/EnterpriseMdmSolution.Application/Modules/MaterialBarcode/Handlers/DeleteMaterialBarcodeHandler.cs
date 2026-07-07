using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialBarcode;

namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Handlers;

public sealed class DeleteMaterialBarcodeHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteMaterialBarcodeCommand, bool>
{
    public async Task<bool> Handle(DeleteMaterialBarcodeCommand request, CancellationToken cancellationToken)
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