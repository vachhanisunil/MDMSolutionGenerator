using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerContact;

namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.Handlers;

public sealed class UpdateCustomerContactHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateCustomerContactCommand, CustomerContactDto?>
{
    public async Task<CustomerContactDto?> Handle(UpdateCustomerContactCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerContactDto>(entity);
    }
}