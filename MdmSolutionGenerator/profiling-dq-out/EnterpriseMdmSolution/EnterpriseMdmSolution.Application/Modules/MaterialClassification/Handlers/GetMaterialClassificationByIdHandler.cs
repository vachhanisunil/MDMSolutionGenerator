using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialClassification;

namespace EnterpriseMdmSolution.Application.Modules.MaterialClassification.Handlers;

public sealed class GetMaterialClassificationByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetMaterialClassificationByIdQuery, MaterialClassificationDto?>
{
    public async Task<MaterialClassificationDto?> Handle(GetMaterialClassificationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<MaterialClassificationDto>(entity);
    }
}