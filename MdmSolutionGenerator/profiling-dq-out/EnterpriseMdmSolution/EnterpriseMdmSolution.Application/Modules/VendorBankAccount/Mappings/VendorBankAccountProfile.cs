using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorBankAccount;

namespace EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Mappings;

public sealed class VendorBankAccountProfile : Profile
{
    public VendorBankAccountProfile()
    {
        CreateMap<Entity, VendorBankAccountDto>();
        CreateMap<CreateVendorBankAccountDto, Entity>();
        CreateMap<UpdateVendorBankAccountDto, Entity>();
    }
}