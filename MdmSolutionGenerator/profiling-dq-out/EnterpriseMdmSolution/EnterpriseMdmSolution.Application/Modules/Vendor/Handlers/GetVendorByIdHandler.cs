using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Vendor;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class GetVendorByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetVendorByIdQuery, VendorDto?>
{
    public async Task<VendorDto?> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, new[] { "VendorAddresses", "VendorContacts", "VendorBankAccounts", "VendorTaxs", "VendorPurchasingOrganizations", "VendorCompliances", "VendorEvaluations", "VendorCertificates" }, cancellationToken);
        return entity is null ? null : mapper.Map<VendorDto>(entity);
    }
}