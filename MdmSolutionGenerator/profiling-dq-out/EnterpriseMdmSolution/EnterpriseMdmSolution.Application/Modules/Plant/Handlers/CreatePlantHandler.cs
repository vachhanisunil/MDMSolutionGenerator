using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Plant.Commands;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Plant;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Handlers;

public sealed class CreatePlantHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreatePlantCommand, PlantDto>
{
    public async Task<PlantDto> Handle(CreatePlantCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<PlantDto>(entity);
    }
}