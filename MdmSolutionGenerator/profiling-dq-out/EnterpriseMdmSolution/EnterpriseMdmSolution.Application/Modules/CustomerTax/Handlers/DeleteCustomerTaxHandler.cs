using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerTax;

namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.Handlers;

public sealed class DeleteCustomerTaxHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteCustomerTaxCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerTaxCommand request, CancellationToken cancellationToken)
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