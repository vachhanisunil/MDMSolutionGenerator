using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerBankAccount;

namespace EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Handlers;

public sealed class CreateCustomerBankAccountHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateCustomerBankAccountCommand, CustomerBankAccountDto>
{
    public async Task<CustomerBankAccountDto> Handle(CreateCustomerBankAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerBankAccountDto>(entity);
    }
}