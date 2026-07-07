using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection;

namespace EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Handlers;

public sealed class DeleteMaterialQualityInspectionHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteMaterialQualityInspectionCommand, bool>
{
    public async Task<bool> Handle(DeleteMaterialQualityInspectionCommand request, CancellationToken cancellationToken)
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