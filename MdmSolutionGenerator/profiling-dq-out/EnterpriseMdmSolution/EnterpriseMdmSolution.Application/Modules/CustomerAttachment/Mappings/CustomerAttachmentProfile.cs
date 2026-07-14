using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerAttachment;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Mappings;

public sealed class CustomerAttachmentProfile : Profile
{
    public CustomerAttachmentProfile()
    {
        CreateMap<Entity, CustomerAttachmentDto>();
        CreateMap<CreateCustomerAttachmentDto, Entity>();
        CreateMap<UpdateCustomerAttachmentDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}