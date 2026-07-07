using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerSalesArea;

namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Handlers;

public sealed class CreateCustomerSalesAreaHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateCustomerSalesAreaCommand, CustomerSalesAreaDto>
{
    public async Task<CustomerSalesAreaDto> Handle(CreateCustomerSalesAreaCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerSalesAreaDto>(entity);
    }
}