using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialPrice;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.Mappings;

public sealed class MaterialPriceProfile : Profile
{
    public MaterialPriceProfile()
    {
        CreateMap<Entity, MaterialPriceDto>();
        CreateMap<CreateMaterialPriceDto, Entity>();
        CreateMap<UpdateMaterialPriceDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}