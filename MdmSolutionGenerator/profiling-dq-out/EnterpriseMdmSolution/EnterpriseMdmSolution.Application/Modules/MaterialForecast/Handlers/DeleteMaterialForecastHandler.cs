using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialForecast;

namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.Handlers;

public sealed class DeleteMaterialForecastHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteMaterialForecastCommand, bool>
{
    public async Task<bool> Handle(DeleteMaterialForecastCommand request, CancellationToken cancellationToken)
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