using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.UnitOfMeasure;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Mappings;

public sealed class UnitOfMeasureProfile : Profile
{
    public UnitOfMeasureProfile()
    {
        CreateMap<Entity, UnitOfMeasureDto>();
        CreateMap<CreateUnitOfMeasureDto, Entity>();
        CreateMap<UpdateUnitOfMeasureDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}