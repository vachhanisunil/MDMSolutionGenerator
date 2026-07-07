using AutoMapper;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorEvaluation;

namespace EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Mappings;

public sealed class VendorEvaluationProfile : Profile
{
    public VendorEvaluationProfile()
    {
        CreateMap<Entity, VendorEvaluationDto>();
        CreateMap<CreateVendorEvaluationDto, Entity>();
        CreateMap<UpdateVendorEvaluationDto, Entity>();
    }
}