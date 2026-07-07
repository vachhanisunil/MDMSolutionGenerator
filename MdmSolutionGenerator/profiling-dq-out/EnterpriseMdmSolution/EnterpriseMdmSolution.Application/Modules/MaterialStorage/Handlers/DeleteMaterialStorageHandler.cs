using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialStorage;

namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.Handlers;

public sealed class DeleteMaterialStorageHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteMaterialStorageCommand, bool>
{
    public async Task<bool> Handle(DeleteMaterialStorageCommand request, CancellationToken cancellationToken)
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