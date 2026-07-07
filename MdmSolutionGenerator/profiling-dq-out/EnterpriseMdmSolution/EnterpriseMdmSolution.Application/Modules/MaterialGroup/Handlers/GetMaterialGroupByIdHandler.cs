using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialGroup;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Handlers;

public sealed class GetMaterialGroupByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetMaterialGroupByIdQuery, MaterialGroupDto?>
{
    public async Task<MaterialGroupDto?> Handle(GetMaterialGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<MaterialGroupDto>(entity);
    }
}