using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection;

namespace EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Mappings;

public sealed class MaterialQualityInspectionProfile : Profile
{
    public MaterialQualityInspectionProfile()
    {
        CreateMap<Entity, MaterialQualityInspectionDto>();
        CreateMap<CreateMaterialQualityInspectionDto, Entity>();
        CreateMap<UpdateMaterialQualityInspectionDto, Entity>();
    }
}