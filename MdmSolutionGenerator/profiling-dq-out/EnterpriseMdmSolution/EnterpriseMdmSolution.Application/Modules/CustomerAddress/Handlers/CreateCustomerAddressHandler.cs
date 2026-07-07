using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerAddress;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAddress.Handlers;

public sealed class CreateCustomerAddressHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateCustomerAddressCommand, CustomerAddressDto>
{
    public async Task<CustomerAddressDto> Handle(CreateCustomerAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerAddressDto>(entity);
    }
}