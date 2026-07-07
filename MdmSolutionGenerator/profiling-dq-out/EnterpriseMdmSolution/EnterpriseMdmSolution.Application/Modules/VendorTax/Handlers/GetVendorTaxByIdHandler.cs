using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorTax.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorTax;

namespace EnterpriseMdmSolution.Application.Modules.VendorTax.Handlers;

public sealed class GetVendorTaxByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetVendorTaxByIdQuery, VendorTaxDto?>
{
    public async Task<VendorTaxDto?> Handle(GetVendorTaxByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<VendorTaxDto>(entity);
    }
}