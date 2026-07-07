using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialUOM;

namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.Handlers;

public sealed class GetMaterialUOMByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetMaterialUOMByIdQuery, MaterialUOMDto?>
{
    public async Task<MaterialUOMDto?> Handle(GetMaterialUOMByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<MaterialUOMDto>(entity);
    }
}