using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialForecast;

namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.Mappings;

public sealed class MaterialForecastProfile : Profile
{
    public MaterialForecastProfile()
    {
        CreateMap<Entity, MaterialForecastDto>();
        CreateMap<CreateMaterialForecastDto, Entity>();
        CreateMap<UpdateMaterialForecastDto, Entity>();
    }
}