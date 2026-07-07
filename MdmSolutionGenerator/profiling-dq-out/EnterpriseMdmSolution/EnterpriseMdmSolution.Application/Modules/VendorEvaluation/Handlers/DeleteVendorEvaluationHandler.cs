using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorEvaluation;

namespace EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Handlers;

public sealed class DeleteVendorEvaluationHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteVendorEvaluationCommand, bool>
{
    public async Task<bool> Handle(DeleteVendorEvaluationCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null)
        {
            return false;
        }

        repository.Delete(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }
}