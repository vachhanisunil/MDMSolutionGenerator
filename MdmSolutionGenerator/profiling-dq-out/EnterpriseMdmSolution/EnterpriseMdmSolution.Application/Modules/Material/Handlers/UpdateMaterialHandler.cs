using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Material;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class UpdateMaterialHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateMaterialCommand, MaterialDto?>
{
    public async Task<MaterialDto?> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, new[] { "MaterialPlants", "MaterialPrices", "MaterialStorages", "MaterialClassifications", "MaterialVendors", "MaterialUOMs", "MaterialQualityInspections", "MaterialForecasts", "MaterialBarcodes" }, cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);
        repository.ReplaceCollection(entity.MaterialPlants, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.MaterialPlant>>(request.Input.MaterialPlants));
        repository.ReplaceCollection(entity.MaterialPrices, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.MaterialPrice>>(request.Input.MaterialPrices));
        repository.ReplaceCollection(entity.MaterialStorages, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.MaterialStorage>>(request.Input.MaterialStorages));
        repository.ReplaceCollection(entity.MaterialClassifications, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.MaterialClassification>>(request.Input.MaterialClassifications));
        repository.ReplaceCollection(entity.MaterialVendors, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.MaterialVendor>>(request.Input.MaterialVendors));
        repository.ReplaceCollection(entity.MaterialUOMs, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.MaterialUOM>>(request.Input.MaterialUOMs));
        repository.ReplaceCollection(entity.MaterialQualityInspections, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection>>(request.Input.MaterialQualityInspections));
        repository.ReplaceCollection(entity.MaterialForecasts, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.MaterialForecast>>(request.Input.MaterialForecasts));
        repository.ReplaceCollection(entity.MaterialBarcodes, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.MaterialBarcode>>(request.Input.MaterialBarcodes));
        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialDto>(entity);
    }
}