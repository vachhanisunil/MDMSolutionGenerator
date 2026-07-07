using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerClassification;

namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.Handlers;

public sealed class DeleteCustomerClassificationHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteCustomerClassificationCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerClassificationCommand request, CancellationToken cancellationToken)
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