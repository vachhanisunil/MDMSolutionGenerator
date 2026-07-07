using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialClassification;

namespace EnterpriseMdmSolution.Application.Modules.MaterialClassification.Handlers;

public sealed class UpdateMaterialClassificationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateMaterialClassificationCommand, MaterialClassificationDto?>
{
    public async Task<MaterialClassificationDto?> Handle(UpdateMaterialClassificationCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialClassificationDto>(entity);
    }
}