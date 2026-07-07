using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerAddress;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAddress.Handlers;

public sealed class GetCustomerAddressByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetCustomerAddressByIdQuery, CustomerAddressDto?>
{
    public async Task<CustomerAddressDto?> Handle(GetCustomerAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<CustomerAddressDto>(entity);
    }
}