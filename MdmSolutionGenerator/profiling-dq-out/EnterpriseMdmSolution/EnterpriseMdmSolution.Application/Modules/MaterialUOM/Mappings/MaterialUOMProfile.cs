using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialUOM;

namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.Mappings;

public sealed class MaterialUOMProfile : Profile
{
    public MaterialUOMProfile()
    {
        CreateMap<Entity, MaterialUOMDto>();
        CreateMap<CreateMaterialUOMDto, Entity>();
        CreateMap<UpdateMaterialUOMDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}