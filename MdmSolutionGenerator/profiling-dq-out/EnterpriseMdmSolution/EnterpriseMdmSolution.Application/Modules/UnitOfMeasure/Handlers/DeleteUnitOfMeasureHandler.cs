using MediatR;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.UnitOfMeasure;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Handlers;

public sealed class DeleteUnitOfMeasureHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteUnitOfMeasureCommand, bool>
{
    public async Task<bool> Handle(DeleteUnitOfMeasureCommand request, CancellationToken cancellationToken)
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