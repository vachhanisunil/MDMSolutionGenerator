using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialForecast;

namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.Handlers;

public sealed class UpdateMaterialForecastHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateMaterialForecastCommand, MaterialForecastDto?>
{
    public async Task<MaterialForecastDto?> Handle(UpdateMaterialForecastCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialForecastDto>(entity);
    }
}