using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialPlant;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.Handlers;

public sealed class CreateMaterialPlantHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateMaterialPlantCommand, MaterialPlantDto>
{
    public async Task<MaterialPlantDto> Handle(CreateMaterialPlantCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialPlantDto>(entity);
    }
}