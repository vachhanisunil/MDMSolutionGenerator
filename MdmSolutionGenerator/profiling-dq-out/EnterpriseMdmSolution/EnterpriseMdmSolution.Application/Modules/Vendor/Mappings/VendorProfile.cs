using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.Vendor;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Mappings;

public sealed class VendorProfile : Profile
{
    public VendorProfile()
    {
        CreateMap<Entity, VendorDto>();
        CreateMap<CreateVendorDto, Entity>();
        CreateMap<UpdateVendorDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore())
            .ForMember(x => x.VendorAddresses, options => options.Ignore())
            .ForMember(x => x.VendorContacts, options => options.Ignore())
            .ForMember(x => x.VendorBankAccounts, options => options.Ignore())
            .ForMember(x => x.VendorTaxs, options => options.Ignore())
            .ForMember(x => x.VendorPurchasingOrganizations, options => options.Ignore())
            .ForMember(x => x.VendorCompliances, options => options.Ignore())
            .ForMember(x => x.VendorEvaluations, options => options.Ignore())
            .ForMember(x => x.VendorCertificates, options => options.Ignore());
    }
}