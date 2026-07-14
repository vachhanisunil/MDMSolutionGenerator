using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialStorage;

namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.Mappings;

public sealed class MaterialStorageProfile : Profile
{
    public MaterialStorageProfile()
    {
        CreateMap<Entity, MaterialStorageDto>();
        CreateMap<CreateMaterialStorageDto, Entity>();
        CreateMap<UpdateMaterialStorageDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}