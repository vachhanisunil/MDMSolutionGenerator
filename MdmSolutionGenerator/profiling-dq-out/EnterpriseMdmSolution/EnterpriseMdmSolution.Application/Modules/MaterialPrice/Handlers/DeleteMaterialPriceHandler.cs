using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialPrice;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.Handlers;

public sealed class DeleteMaterialPriceHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteMaterialPriceCommand, bool>
{
    public async Task<bool> Handle(DeleteMaterialPriceCommand request, CancellationToken cancellationToken)
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