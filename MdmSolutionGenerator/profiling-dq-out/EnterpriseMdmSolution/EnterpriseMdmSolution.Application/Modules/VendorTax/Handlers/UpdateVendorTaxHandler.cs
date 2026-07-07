using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorTax.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorTax;

namespace EnterpriseMdmSolution.Application.Modules.VendorTax.Handlers;

public sealed class UpdateVendorTaxHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateVendorTaxCommand, VendorTaxDto?>
{
    public async Task<VendorTaxDto?> Handle(UpdateVendorTaxCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorTaxDto>(entity);
    }
}