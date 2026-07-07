using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialPlant;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.Mappings;

public sealed class MaterialPlantProfile : Profile
{
    public MaterialPlantProfile()
    {
        CreateMap<Entity, MaterialPlantDto>();
        CreateMap<CreateMaterialPlantDto, Entity>();
        CreateMap<UpdateMaterialPlantDto, Entity>();
    }
}