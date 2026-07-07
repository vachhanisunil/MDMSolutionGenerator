using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialGroup;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Handlers;

public sealed class UpdateMaterialGroupHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateMaterialGroupCommand, MaterialGroupDto?>
{
    public async Task<MaterialGroupDto?> Handle(UpdateMaterialGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialGroupDto>(entity);
    }
}