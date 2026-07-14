using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerTax;

namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.Mappings;

public sealed class CustomerTaxProfile : Profile
{
    public CustomerTaxProfile()
    {
        CreateMap<Entity, CustomerTaxDto>();
        CreateMap<CreateCustomerTaxDto, Entity>();
        CreateMap<UpdateCustomerTaxDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}