using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialForecast;

namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.Handlers;

public sealed class GetMaterialForecastByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetMaterialForecastByIdQuery, MaterialForecastDto?>
{
    public async Task<MaterialForecastDto?> Handle(GetMaterialForecastByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<MaterialForecastDto>(entity);
    }
}