using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.StorageLocation;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Handlers;

public sealed class GetStorageLocationByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetStorageLocationByIdQuery, StorageLocationDto?>
{
    public async Task<StorageLocationDto?> Handle(GetStorageLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<StorageLocationDto>(entity);
    }
}