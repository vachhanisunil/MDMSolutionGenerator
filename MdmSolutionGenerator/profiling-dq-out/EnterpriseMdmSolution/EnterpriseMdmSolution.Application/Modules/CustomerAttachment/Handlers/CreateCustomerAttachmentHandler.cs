using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerAttachment;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Handlers;

public sealed class CreateCustomerAttachmentHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateCustomerAttachmentCommand, CustomerAttachmentDto>
{
    public async Task<CustomerAttachmentDto> Handle(CreateCustomerAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerAttachmentDto>(entity);
    }
}