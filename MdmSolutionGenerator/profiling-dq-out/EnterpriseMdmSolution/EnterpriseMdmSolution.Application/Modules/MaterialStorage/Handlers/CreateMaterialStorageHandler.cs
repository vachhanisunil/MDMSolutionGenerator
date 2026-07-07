using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialStorage;

namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.Handlers;

public sealed class CreateMaterialStorageHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateMaterialStorageCommand, MaterialStorageDto>
{
    public async Task<MaterialStorageDto> Handle(CreateMaterialStorageCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialStorageDto>(entity);
    }
}