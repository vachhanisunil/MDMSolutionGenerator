using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialVendor;

namespace EnterpriseMdmSolution.Application.Modules.MaterialVendor.Mappings;

public sealed class MaterialVendorProfile : Profile
{
    public MaterialVendorProfile()
    {
        CreateMap<Entity, MaterialVendorDto>();
        CreateMap<CreateMaterialVendorDto, Entity>();
        CreateMap<UpdateMaterialVendorDto, Entity>();
    }
}