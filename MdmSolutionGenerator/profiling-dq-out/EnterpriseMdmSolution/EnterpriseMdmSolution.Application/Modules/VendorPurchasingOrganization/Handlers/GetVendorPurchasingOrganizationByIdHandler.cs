using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Handlers;

public sealed class GetVendorPurchasingOrganizationByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetVendorPurchasingOrganizationByIdQuery, VendorPurchasingOrganizationDto?>
{
    public async Task<VendorPurchasingOrganizationDto?> Handle(GetVendorPurchasingOrganizationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<VendorPurchasingOrganizationDto>(entity);
    }
}