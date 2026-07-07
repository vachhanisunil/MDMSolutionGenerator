using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialStorage;

namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.Handlers;

public sealed class UpdateMaterialStorageHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateMaterialStorageCommand, MaterialStorageDto?>
{
    public async Task<MaterialStorageDto?> Handle(UpdateMaterialStorageCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialStorageDto>(entity);
    }
}