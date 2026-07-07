using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorBankAccount;

namespace EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Handlers;

public sealed class UpdateVendorBankAccountHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateVendorBankAccountCommand, VendorBankAccountDto?>
{
    public async Task<VendorBankAccountDto?> Handle(UpdateVendorBankAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorBankAccountDto>(entity);
    }
}