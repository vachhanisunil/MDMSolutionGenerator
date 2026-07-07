using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Commands;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerAttachment;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Handlers;

public sealed class DeleteCustomerAttachmentHandler(IRepository<Entity> repository)
    : IRequestHandler<DeleteCustomerAttachmentCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerAttachmentCommand request, CancellationToken cancellationToken)
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