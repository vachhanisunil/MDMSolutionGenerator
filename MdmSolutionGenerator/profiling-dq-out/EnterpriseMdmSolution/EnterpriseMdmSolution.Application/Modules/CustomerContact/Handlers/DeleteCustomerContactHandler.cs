using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerContact;

namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.Handlers;

public sealed class DeleteCustomerContactHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteCustomerContactCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerContactCommand request, CancellationToken cancellationToken)
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