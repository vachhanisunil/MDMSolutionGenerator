using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerSalesArea;

namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Mappings;

public sealed class CustomerSalesAreaProfile : Profile
{
    public CustomerSalesAreaProfile()
    {
        CreateMap<Entity, CustomerSalesAreaDto>();
        CreateMap<CreateCustomerSalesAreaDto, Entity>();
        CreateMap<UpdateCustomerSalesAreaDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}