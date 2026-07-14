using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.SalesOrganization;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Mappings;

public sealed class SalesOrganizationProfile : Profile
{
    public SalesOrganizationProfile()
    {
        CreateMap<Entity, SalesOrganizationDto>();
        CreateMap<CreateSalesOrganizationDto, Entity>();
        CreateMap<UpdateSalesOrganizationDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}