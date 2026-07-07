using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class GetVendorRuleDrilldownQueryHandler(IVendorRunService runService)
    : IRequestHandler<GetVendorRuleDrilldownQuery, IReadOnlyList<VendorRuleDrilldownDto>>
{
    public async Task<IReadOnlyList<VendorRuleDrilldownDto>> Handle(GetVendorRuleDrilldownQuery request, CancellationToken cancellationToken)
        => await runService.GetRuleDrilldownAsync(request.RunId, cancellationToken);
}