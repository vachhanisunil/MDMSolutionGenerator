using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorBankAccount;

namespace EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Handlers;

public sealed class DeleteVendorBankAccountHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteVendorBankAccountCommand, bool>
{
    public async Task<bool> Handle(DeleteVendorBankAccountCommand request, CancellationToken cancellationToken)
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