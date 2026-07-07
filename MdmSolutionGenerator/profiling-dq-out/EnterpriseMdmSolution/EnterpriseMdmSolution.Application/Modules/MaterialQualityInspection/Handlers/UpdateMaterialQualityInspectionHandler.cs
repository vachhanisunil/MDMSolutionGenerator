using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection;

namespace EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Handlers;

public sealed class UpdateMaterialQualityInspectionHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateMaterialQualityInspectionCommand, MaterialQualityInspectionDto?>
{
    public async Task<MaterialQualityInspectionDto?> Handle(UpdateMaterialQualityInspectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialQualityInspectionDto>(entity);
    }
}