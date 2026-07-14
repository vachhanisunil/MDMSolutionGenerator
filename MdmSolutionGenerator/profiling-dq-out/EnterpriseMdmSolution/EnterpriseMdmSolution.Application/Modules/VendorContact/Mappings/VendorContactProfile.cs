using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorContact;

namespace EnterpriseMdmSolution.Application.Modules.VendorContact.Mappings;

public sealed class VendorContactProfile : Profile
{
    public VendorContactProfile()
    {
        CreateMap<Entity, VendorContactDto>();
        CreateMap<CreateVendorContactDto, Entity>();
        CreateMap<UpdateVendorContactDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}