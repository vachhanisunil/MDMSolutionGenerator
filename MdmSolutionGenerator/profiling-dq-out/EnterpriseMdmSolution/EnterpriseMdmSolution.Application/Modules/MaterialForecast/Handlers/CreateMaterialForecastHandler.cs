using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialForecast;

namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.Handlers;

public sealed class CreateMaterialForecastHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateMaterialForecastCommand, MaterialForecastDto>
{
    public async Task<MaterialForecastDto> Handle(CreateMaterialForecastCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialForecastDto>(entity);
    }
}