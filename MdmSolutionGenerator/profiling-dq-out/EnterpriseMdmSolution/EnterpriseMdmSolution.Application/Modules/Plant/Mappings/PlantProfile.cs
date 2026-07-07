using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.Plant;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Mappings;

public sealed class PlantProfile : Profile
{
    public PlantProfile()
    {
        CreateMap<Entity, PlantDto>();
        CreateMap<CreatePlantDto, Entity>();
        CreateMap<UpdatePlantDto, Entity>();
    }
}