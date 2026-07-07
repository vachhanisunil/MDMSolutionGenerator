using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialPlant;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.Handlers;

public sealed class GetMaterialPlantByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetMaterialPlantByIdQuery, MaterialPlantDto?>
{
    public async Task<MaterialPlantDto?> Handle(GetMaterialPlantByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<MaterialPlantDto>(entity);
    }
}