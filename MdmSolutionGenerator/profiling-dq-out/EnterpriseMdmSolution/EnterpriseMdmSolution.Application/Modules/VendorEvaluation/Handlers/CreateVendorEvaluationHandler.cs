using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorEvaluation;

namespace EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Handlers;

public sealed class CreateVendorEvaluationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateVendorEvaluationCommand, VendorEvaluationDto>
{
    public async Task<VendorEvaluationDto> Handle(CreateVendorEvaluationCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorEvaluationDto>(entity);
    }
}