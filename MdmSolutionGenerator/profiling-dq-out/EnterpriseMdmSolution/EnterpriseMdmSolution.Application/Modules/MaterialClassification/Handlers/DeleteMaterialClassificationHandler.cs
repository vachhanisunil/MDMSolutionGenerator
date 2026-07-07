using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialClassification;

namespace EnterpriseMdmSolution.Application.Modules.MaterialClassification.Handlers;

public sealed class DeleteMaterialClassificationHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteMaterialClassificationCommand, bool>
{
    public async Task<bool> Handle(DeleteMaterialClassificationCommand request, CancellationToken cancellationToken)
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