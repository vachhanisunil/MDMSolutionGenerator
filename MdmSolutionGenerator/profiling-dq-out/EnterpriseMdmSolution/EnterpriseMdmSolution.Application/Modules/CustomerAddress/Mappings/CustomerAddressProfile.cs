using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerAddress;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAddress.Mappings;

public sealed class CustomerAddressProfile : Profile
{
    public CustomerAddressProfile()
    {
        CreateMap<Entity, CustomerAddressDto>();
        CreateMap<CreateCustomerAddressDto, Entity>();
        CreateMap<UpdateCustomerAddressDto, Entity>();
    }
}