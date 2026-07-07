using MediatR;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.StorageLocation;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Handlers;

public sealed class DeleteStorageLocationHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteStorageLocationCommand, bool>
{
    public async Task<bool> Handle(DeleteStorageLocationCommand request, CancellationToken cancellationToken)
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