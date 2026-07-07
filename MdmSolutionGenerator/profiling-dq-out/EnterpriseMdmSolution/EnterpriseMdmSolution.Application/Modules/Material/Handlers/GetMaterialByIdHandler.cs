using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Material;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class GetMaterialByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetMaterialByIdQuery, MaterialDto?>
{
    public async Task<MaterialDto?> Handle(GetMaterialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, new[] { "MaterialPlants", "MaterialPrices", "MaterialStorages", "MaterialClassifications", "MaterialVendors", "MaterialUOMs", "MaterialQualityInspections", "MaterialForecasts", "MaterialBarcodes" }, cancellationToken);
        return entity is null ? null : mapper.Map<MaterialDto>(entity);
    }
}