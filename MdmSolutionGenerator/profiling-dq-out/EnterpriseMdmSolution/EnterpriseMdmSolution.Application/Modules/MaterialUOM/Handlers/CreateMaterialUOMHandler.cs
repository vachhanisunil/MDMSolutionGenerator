using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialUOM;

namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.Handlers;

public sealed class CreateMaterialUOMHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateMaterialUOMCommand, MaterialUOMDto>
{
    public async Task<MaterialUOMDto> Handle(CreateMaterialUOMCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialUOMDto>(entity);
    }
}