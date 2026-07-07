using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialPrice;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.Handlers;

public sealed class GetMaterialPriceByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetMaterialPriceByIdQuery, MaterialPriceDto?>
{
    public async Task<MaterialPriceDto?> Handle(GetMaterialPriceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<MaterialPriceDto>(entity);
    }
}