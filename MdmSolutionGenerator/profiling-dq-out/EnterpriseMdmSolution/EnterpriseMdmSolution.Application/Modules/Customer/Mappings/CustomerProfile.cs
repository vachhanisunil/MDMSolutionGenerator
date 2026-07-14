using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.Customer;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Mappings;

public sealed class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Entity, CustomerDto>();
        CreateMap<CreateCustomerDto, Entity>();
        CreateMap<UpdateCustomerDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore())
            .ForMember(x => x.CustomerAddresses, options => options.Ignore())
            .ForMember(x => x.CustomerContacts, options => options.Ignore())
            .ForMember(x => x.CustomerBankAccounts, options => options.Ignore())
            .ForMember(x => x.CustomerSalesAreas, options => options.Ignore())
            .ForMember(x => x.CustomerTaxs, options => options.Ignore())
            .ForMember(x => x.CustomerClassifications, options => options.Ignore())
            .ForMember(x => x.CustomerCreditProfiles, options => options.Ignore())
            .ForMember(x => x.CustomerPartnerFunctions, options => options.Ignore())
            .ForMember(x => x.CustomerAttachments, options => options.Ignore());
    }
}