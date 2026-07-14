using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorAddress;

namespace EnterpriseMdmSolution.Application.Modules.VendorAddress.Mappings;

public sealed class VendorAddressProfile : Profile
{
    public VendorAddressProfile()
    {
        CreateMap<Entity, VendorAddressDto>();
        CreateMap<CreateVendorAddressDto, Entity>();
        CreateMap<UpdateVendorAddressDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}