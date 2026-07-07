using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialGroup;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Mappings;

public sealed class MaterialGroupProfile : Profile
{
    public MaterialGroupProfile()
    {
        CreateMap<Entity, MaterialGroupDto>();
        CreateMap<CreateMaterialGroupDto, Entity>();
        CreateMap<UpdateMaterialGroupDto, Entity>();
    }
}