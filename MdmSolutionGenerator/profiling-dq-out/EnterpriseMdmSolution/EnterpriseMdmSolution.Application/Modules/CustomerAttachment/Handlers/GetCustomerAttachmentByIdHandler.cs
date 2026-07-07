using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerAttachment;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Handlers;

public sealed class GetCustomerAttachmentByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetCustomerAttachmentByIdQuery, CustomerAttachmentDto?>
{
    public async Task<CustomerAttachmentDto?> Handle(GetCustomerAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<CustomerAttachmentDto>(entity);
    }
}