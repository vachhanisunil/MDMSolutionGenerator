using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile;

namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Mappings;

public sealed class CustomerCreditProfileProfile : Profile
{
    public CustomerCreditProfileProfile()
    {
        CreateMap<Entity, CustomerCreditProfileDto>();
        CreateMap<CreateCustomerCreditProfileDto, Entity>();
        CreateMap<UpdateCustomerCreditProfileDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}