using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction;

namespace EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Handlers;

public sealed class DeleteCustomerPartnerFunctionHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteCustomerPartnerFunctionCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerPartnerFunctionCommand request, CancellationToken cancellationToken)
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