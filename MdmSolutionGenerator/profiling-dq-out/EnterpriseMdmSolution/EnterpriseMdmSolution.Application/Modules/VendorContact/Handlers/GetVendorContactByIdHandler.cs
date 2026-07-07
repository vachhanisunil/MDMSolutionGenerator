using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorContact.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorContact;

namespace EnterpriseMdmSolution.Application.Modules.VendorContact.Handlers;

public sealed class GetVendorContactByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetVendorContactByIdQuery, VendorContactDto?>
{
    public async Task<VendorContactDto?> Handle(GetVendorContactByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<VendorContactDto>(entity);
    }
}