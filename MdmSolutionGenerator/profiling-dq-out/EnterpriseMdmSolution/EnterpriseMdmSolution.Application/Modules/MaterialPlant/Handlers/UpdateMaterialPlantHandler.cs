using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialPlant;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.Handlers;

public sealed class UpdateMaterialPlantHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateMaterialPlantCommand, MaterialPlantDto?>
{
    public async Task<MaterialPlantDto?> Handle(UpdateMaterialPlantCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialPlantDto>(entity);
    }
}