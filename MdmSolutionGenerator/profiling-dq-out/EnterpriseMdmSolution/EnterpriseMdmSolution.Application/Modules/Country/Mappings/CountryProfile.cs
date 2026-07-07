using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.Country;

namespace EnterpriseMdmSolution.Application.Modules.Country.Mappings;

public sealed class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<Entity, CountryDto>();
        CreateMap<CreateCountryDto, Entity>();
        CreateMap<UpdateCountryDto, Entity>();
    }
}