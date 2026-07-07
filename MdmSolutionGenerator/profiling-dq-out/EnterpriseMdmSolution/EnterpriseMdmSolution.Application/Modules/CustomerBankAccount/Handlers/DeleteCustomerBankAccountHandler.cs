using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerBankAccount;

namespace EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Handlers;

public sealed class DeleteCustomerBankAccountHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteCustomerBankAccountCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerBankAccountCommand request, CancellationToken cancellationToken)
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