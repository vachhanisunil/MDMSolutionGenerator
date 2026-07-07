using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorAddress;

namespace EnterpriseMdmSolution.Application.Modules.VendorAddress.Handlers;

public sealed class GetVendorAddressByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetVendorAddressByIdQuery, VendorAddressDto?>
{
    public async Task<VendorAddressDto?> Handle(GetVendorAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<VendorAddressDto>(entity);
    }
}