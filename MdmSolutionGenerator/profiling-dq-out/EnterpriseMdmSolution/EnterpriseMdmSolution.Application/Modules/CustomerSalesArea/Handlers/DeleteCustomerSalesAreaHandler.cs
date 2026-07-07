using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerSalesArea;

namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Handlers;

public sealed class DeleteCustomerSalesAreaHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteCustomerSalesAreaCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerSalesAreaCommand request, CancellationToken cancellationToken)
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