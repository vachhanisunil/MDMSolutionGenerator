using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Plant.Commands;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Plant;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Handlers;

public sealed class UpdatePlantHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdatePlantCommand, PlantDto?>
{
    public async Task<PlantDto?> Handle(UpdatePlantCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<PlantDto>(entity);
    }
}