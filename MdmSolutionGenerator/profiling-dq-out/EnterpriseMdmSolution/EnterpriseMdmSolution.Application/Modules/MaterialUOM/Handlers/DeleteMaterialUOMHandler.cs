using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialUOM;

namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.Handlers;

public sealed class DeleteMaterialUOMHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteMaterialUOMCommand, bool>
{
    public async Task<bool> Handle(DeleteMaterialUOMCommand request, CancellationToken cancellationToken)
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