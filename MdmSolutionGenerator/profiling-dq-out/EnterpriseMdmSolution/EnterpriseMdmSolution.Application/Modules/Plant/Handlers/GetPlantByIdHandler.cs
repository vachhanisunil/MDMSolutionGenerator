using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;
using EnterpriseMdmSolution.Application.Modules.Plant.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Plant;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Handlers;

public sealed class GetPlantByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetPlantByIdQuery, PlantDto?>
{
    public async Task<PlantDto?> Handle(GetPlantByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<PlantDto>(entity);
    }
}