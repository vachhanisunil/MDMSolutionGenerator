using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerAddress;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAddress.Handlers;

public sealed class DeleteCustomerAddressHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteCustomerAddressCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
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