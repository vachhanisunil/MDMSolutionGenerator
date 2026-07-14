using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.StorageLocation;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Mappings;

public sealed class StorageLocationProfile : Profile
{
    public StorageLocationProfile()
    {
        CreateMap<Entity, StorageLocationDto>();
        CreateMap<CreateStorageLocationDto, Entity>();
        CreateMap<UpdateStorageLocationDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}