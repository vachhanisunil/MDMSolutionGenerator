using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection;

namespace EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Handlers;

public sealed class GetMaterialQualityInspectionByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetMaterialQualityInspectionByIdQuery, MaterialQualityInspectionDto?>
{
    public async Task<MaterialQualityInspectionDto?> Handle(GetMaterialQualityInspectionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<MaterialQualityInspectionDto>(entity);
    }
}