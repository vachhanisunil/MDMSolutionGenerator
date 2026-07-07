using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerBankAccount;

namespace EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Handlers;

public sealed class GetCustomerBankAccountByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetCustomerBankAccountByIdQuery, CustomerBankAccountDto?>
{
    public async Task<CustomerBankAccountDto?> Handle(GetCustomerBankAccountByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<CustomerBankAccountDto>(entity);
    }
}