using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Mappings;

public sealed class VendorPurchasingOrganizationProfile : Profile
{
    public VendorPurchasingOrganizationProfile()
    {
        CreateMap<Entity, VendorPurchasingOrganizationDto>();
        CreateMap<CreateVendorPurchasingOrganizationDto, Entity>();
        CreateMap<UpdateVendorPurchasingOrganizationDto, Entity>();
    }
}