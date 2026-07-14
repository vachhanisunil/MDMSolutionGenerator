using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorCertificate;

namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.Mappings;

public sealed class VendorCertificateProfile : Profile
{
    public VendorCertificateProfile()
    {
        CreateMap<Entity, VendorCertificateDto>();
        CreateMap<CreateVendorCertificateDto, Entity>();
        CreateMap<UpdateVendorCertificateDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}