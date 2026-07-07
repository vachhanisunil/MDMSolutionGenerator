using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection;

namespace EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Handlers;

public sealed class CreateMaterialQualityInspectionHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateMaterialQualityInspectionCommand, MaterialQualityInspectionDto>
{
    public async Task<MaterialQualityInspectionDto> Handle(CreateMaterialQualityInspectionCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialQualityInspectionDto>(entity);
    }
}