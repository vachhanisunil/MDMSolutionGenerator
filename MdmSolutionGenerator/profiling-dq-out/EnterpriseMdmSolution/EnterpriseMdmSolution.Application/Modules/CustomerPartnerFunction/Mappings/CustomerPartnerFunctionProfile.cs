using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction;

namespace EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Mappings;

public sealed class CustomerPartnerFunctionProfile : Profile
{
    public CustomerPartnerFunctionProfile()
    {
        CreateMap<Entity, CustomerPartnerFunctionDto>();
        CreateMap<CreateCustomerPartnerFunctionDto, Entity>();
        CreateMap<UpdateCustomerPartnerFunctionDto, Entity>();
    }
}