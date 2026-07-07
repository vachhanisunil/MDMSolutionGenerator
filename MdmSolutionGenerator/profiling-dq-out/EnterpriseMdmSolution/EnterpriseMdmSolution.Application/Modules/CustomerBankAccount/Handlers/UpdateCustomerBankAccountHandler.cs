using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerBankAccount;

namespace EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Handlers;

public sealed class UpdateCustomerBankAccountHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateCustomerBankAccountCommand, CustomerBankAccountDto?>
{
    public async Task<CustomerBankAccountDto?> Handle(UpdateCustomerBankAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerBankAccountDto>(entity);
    }
}