using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.PaymentTerm;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Mappings;

public sealed class PaymentTermProfile : Profile
{
    public PaymentTermProfile()
    {
        CreateMap<Entity, PaymentTermDto>();
        CreateMap<CreatePaymentTermDto, Entity>();
        CreateMap<UpdatePaymentTermDto, Entity>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}