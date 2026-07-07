using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialStorage;

namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.Handlers;

public sealed class GetMaterialStorageByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetMaterialStorageByIdQuery, MaterialStorageDto?>
{
    public async Task<MaterialStorageDto?> Handle(GetMaterialStorageByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<MaterialStorageDto>(entity);
    }
}