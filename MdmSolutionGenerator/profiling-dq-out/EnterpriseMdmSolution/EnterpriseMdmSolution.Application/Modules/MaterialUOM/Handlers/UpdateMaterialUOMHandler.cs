using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialUOM;

namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.Handlers;

public sealed class UpdateMaterialUOMHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateMaterialUOMCommand, MaterialUOMDto?>
{
    public async Task<MaterialUOMDto?> Handle(UpdateMaterialUOMCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialUOMDto>(entity);
    }
}