using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorBankAccount;

namespace EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Handlers;

public sealed class CreateVendorBankAccountHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateVendorBankAccountCommand, VendorBankAccountDto>
{
    public async Task<VendorBankAccountDto> Handle(CreateVendorBankAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorBankAccountDto>(entity);
    }
}