using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorTax;

namespace EnterpriseMdmSolution.Application.Modules.VendorTax.Mappings;

public sealed class VendorTaxProfile : Profile
{
    public VendorTaxProfile()
    {
        CreateMap<Entity, VendorTaxDto>();
        CreateMap<CreateVendorTaxDto, Entity>();
        CreateMap<UpdateVendorTaxDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}