using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerAttachment;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Handlers;

public sealed class UpdateCustomerAttachmentHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateCustomerAttachmentCommand, CustomerAttachmentDto?>
{
    public async Task<CustomerAttachmentDto?> Handle(UpdateCustomerAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerAttachmentDto>(entity);
    }
}