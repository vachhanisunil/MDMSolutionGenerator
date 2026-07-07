using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerContact;

namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.Handlers;

public sealed class CreateCustomerContactHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateCustomerContactCommand, CustomerContactDto>
{
    public async Task<CustomerContactDto> Handle(CreateCustomerContactCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerContactDto>(entity);
    }
}