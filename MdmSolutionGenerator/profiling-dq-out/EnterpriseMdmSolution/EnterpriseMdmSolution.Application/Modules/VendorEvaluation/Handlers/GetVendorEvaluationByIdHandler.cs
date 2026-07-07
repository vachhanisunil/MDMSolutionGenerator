using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorEvaluation;

namespace EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Handlers;

public sealed class GetVendorEvaluationByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetVendorEvaluationByIdQuery, VendorEvaluationDto?>
{
    public async Task<VendorEvaluationDto?> Handle(GetVendorEvaluationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<VendorEvaluationDto>(entity);
    }
}