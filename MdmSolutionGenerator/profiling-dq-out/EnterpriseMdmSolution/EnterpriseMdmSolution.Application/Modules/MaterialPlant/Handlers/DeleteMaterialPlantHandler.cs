using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialPlant;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.Handlers;

public sealed class DeleteMaterialPlantHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteMaterialPlantCommand, bool>
{
    public async Task<bool> Handle(DeleteMaterialPlantCommand request, CancellationToken cancellationToken)
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