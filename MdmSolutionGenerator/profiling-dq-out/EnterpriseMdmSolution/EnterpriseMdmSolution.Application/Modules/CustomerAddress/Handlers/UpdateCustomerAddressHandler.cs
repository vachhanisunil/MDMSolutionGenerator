using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerAddress;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAddress.Handlers;

public sealed class UpdateCustomerAddressHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateCustomerAddressCommand, CustomerAddressDto?>
{
    public async Task<CustomerAddressDto?> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerAddressDto>(entity);
    }
}