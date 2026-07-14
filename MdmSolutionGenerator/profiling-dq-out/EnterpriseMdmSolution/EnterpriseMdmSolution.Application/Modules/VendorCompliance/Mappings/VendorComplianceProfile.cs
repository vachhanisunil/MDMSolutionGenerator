using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorCompliance;

namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.Mappings;

public sealed class VendorComplianceProfile : Profile
{
    public VendorComplianceProfile()
    {
        CreateMap<Entity, VendorComplianceDto>();
        CreateMap<CreateVendorComplianceDto, Entity>();
        CreateMap<UpdateVendorComplianceDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}