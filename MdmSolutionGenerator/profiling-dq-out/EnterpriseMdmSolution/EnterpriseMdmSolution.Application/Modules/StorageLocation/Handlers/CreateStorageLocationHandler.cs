using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.StorageLocation;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Handlers;

public sealed class CreateStorageLocationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateStorageLocationCommand, StorageLocationDto>
{
    public async Task<StorageLocationDto> Handle(CreateStorageLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<StorageLocationDto>(entity);
    }
}