using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.PurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Mappings;

public sealed class PurchasingOrganizationProfile : Profile
{
    public PurchasingOrganizationProfile()
    {
        CreateMap<Entity, PurchasingOrganizationDto>();
        CreateMap<CreatePurchasingOrganizationDto, Entity>();
        CreateMap<UpdatePurchasingOrganizationDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}