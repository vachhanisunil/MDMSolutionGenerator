using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.Currency;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Mappings;

public sealed class CurrencyProfile : Profile
{
    public CurrencyProfile()
    {
        CreateMap<Entity, CurrencyDto>();
        CreateMap<CreateCurrencyDto, Entity>();
        CreateMap<UpdateCurrencyDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}