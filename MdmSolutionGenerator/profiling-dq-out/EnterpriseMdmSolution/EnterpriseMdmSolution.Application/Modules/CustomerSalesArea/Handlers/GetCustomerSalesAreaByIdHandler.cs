using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerSalesArea;

namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Handlers;

public sealed class GetCustomerSalesAreaByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetCustomerSalesAreaByIdQuery, CustomerSalesAreaDto?>
{
    public async Task<CustomerSalesAreaDto?> Handle(GetCustomerSalesAreaByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<CustomerSalesAreaDto>(entity);
    }
}