using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialClassification;

namespace EnterpriseMdmSolution.Application.Modules.MaterialClassification.Mappings;

public sealed class MaterialClassificationProfile : Profile
{
    public MaterialClassificationProfile()
    {
        CreateMap<Entity, MaterialClassificationDto>();
        CreateMap<CreateMaterialClassificationDto, Entity>();
        CreateMap<UpdateMaterialClassificationDto, Entity>();
    }
}