using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorBankAccount;

namespace EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Handlers;

public sealed class GetVendorBankAccountByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetVendorBankAccountByIdQuery, VendorBankAccountDto?>
{
    public async Task<VendorBankAccountDto?> Handle(GetVendorBankAccountByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<VendorBankAccountDto>(entity);
    }
}