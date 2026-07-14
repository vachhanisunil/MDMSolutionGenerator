using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerClassification;

namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.Mappings;

public sealed class CustomerClassificationProfile : Profile
{
    public CustomerClassificationProfile()
    {
        CreateMap<Entity, CustomerClassificationDto>();
        CreateMap<CreateCustomerClassificationDto, Entity>();
        CreateMap<UpdateCustomerClassificationDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}