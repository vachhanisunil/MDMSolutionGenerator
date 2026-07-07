using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.Material;

namespace EnterpriseMdmSolution.Application.Modules.Material.Mappings;

public sealed class MaterialProfile : Profile
{
    public MaterialProfile()
    {
        CreateMap<Entity, MaterialDto>();
        CreateMap<CreateMaterialDto, Entity>();
        CreateMap<UpdateMaterialDto, Entity>()
            .ForMember(x => x.MaterialPlants, options => options.Ignore())
            .ForMember(x => x.MaterialPrices, options => options.Ignore())
            .ForMember(x => x.MaterialStorages, options => options.Ignore())
            .ForMember(x => x.MaterialClassifications, options => options.Ignore())
            .ForMember(x => x.MaterialVendors, options => options.Ignore())
            .ForMember(x => x.MaterialUOMs, options => options.Ignore())
            .ForMember(x => x.MaterialQualityInspections, options => options.Ignore())
            .ForMember(x => x.MaterialForecasts, options => options.Ignore())
            .ForMember(x => x.MaterialBarcodes, options => options.Ignore());
    }
}