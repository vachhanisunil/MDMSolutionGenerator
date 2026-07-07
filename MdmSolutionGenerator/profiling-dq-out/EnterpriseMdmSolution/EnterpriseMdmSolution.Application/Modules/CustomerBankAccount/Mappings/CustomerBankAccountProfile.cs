using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerBankAccount;

namespace EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Mappings;

public sealed class CustomerBankAccountProfile : Profile
{
    public CustomerBankAccountProfile()
    {
        CreateMap<Entity, CustomerBankAccountDto>();
        CreateMap<CreateCustomerBankAccountDto, Entity>();
        CreateMap<UpdateCustomerBankAccountDto, Entity>();
    }
}