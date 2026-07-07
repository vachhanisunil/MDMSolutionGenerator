using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerContact;

namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.Mappings;

public sealed class CustomerContactProfile : Profile
{
    public CustomerContactProfile()
    {
        CreateMap<Entity, CustomerContactDto>();
        CreateMap<CreateCustomerContactDto, Entity>();
        CreateMap<UpdateCustomerContactDto, Entity>();
    }
}