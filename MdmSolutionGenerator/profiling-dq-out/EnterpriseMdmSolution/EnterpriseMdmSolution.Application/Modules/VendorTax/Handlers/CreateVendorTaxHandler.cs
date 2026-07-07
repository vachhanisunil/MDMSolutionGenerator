using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorTax.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorTax;

namespace EnterpriseMdmSolution.Application.Modules.VendorTax.Handlers;

public sealed class CreateVendorTaxHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateVendorTaxCommand, VendorTaxDto>
{
    public async Task<VendorTaxDto> Handle(CreateVendorTaxCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorTaxDto>(entity);
    }
}