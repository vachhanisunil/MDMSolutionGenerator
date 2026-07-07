using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerContact;

namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.Handlers;

public sealed class GetCustomerContactByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetCustomerContactByIdQuery, CustomerContactDto?>
{
    public async Task<CustomerContactDto?> Handle(GetCustomerContactByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<CustomerContactDto>(entity);
    }
}