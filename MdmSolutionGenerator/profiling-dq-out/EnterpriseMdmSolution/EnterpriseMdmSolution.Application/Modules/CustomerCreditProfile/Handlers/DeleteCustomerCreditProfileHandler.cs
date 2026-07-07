using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile;

namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Handlers;

public sealed class DeleteCustomerCreditProfileHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteCustomerCreditProfileCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerCreditProfileCommand request, CancellationToken cancellationToken)
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