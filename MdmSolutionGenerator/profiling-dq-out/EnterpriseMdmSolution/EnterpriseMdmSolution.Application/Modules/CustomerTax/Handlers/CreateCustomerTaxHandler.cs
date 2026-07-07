using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerTax;

namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.Handlers;

public sealed class CreateCustomerTaxHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateCustomerTaxCommand, CustomerTaxDto>
{
    public async Task<CustomerTaxDto> Handle(CreateCustomerTaxCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerTaxDto>(entity);
    }
}