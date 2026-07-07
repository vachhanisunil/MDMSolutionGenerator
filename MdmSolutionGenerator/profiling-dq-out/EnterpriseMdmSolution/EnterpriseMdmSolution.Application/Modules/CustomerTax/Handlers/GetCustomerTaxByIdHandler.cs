using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerTax;

namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.Handlers;

public sealed class GetCustomerTaxByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetCustomerTaxByIdQuery, CustomerTaxDto?>
{
    public async Task<CustomerTaxDto?> Handle(GetCustomerTaxByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<CustomerTaxDto>(entity);
    }
}