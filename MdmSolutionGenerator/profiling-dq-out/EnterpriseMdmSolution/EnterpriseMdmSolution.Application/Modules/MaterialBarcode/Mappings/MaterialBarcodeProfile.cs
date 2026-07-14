using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialBarcode;

namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Mappings;

public sealed class MaterialBarcodeProfile : Profile
{
    public MaterialBarcodeProfile()
    {
        CreateMap<Entity, MaterialBarcodeDto>();
        CreateMap<CreateMaterialBarcodeDto, Entity>();
        CreateMap<UpdateMaterialBarcodeDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}