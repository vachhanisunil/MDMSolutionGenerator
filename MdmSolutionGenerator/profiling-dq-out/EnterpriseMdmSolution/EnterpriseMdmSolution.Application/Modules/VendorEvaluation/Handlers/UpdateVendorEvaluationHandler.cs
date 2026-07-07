using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorEvaluation;

namespace EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Handlers;

public sealed class UpdateVendorEvaluationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateVendorEvaluationCommand, VendorEvaluationDto?>
{
    public async Task<VendorEvaluationDto?> Handle(UpdateVendorEvaluationCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorEvaluationDto>(entity);
    }
}