using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class GetVendorProfilingSummaryQueryHandler(IVendorRunService runService)
    : IRequestHandler<GetVendorProfilingSummaryQuery, IReadOnlyList<VendorProfilingSummaryDto>>
{
    public async Task<IReadOnlyList<VendorProfilingSummaryDto>> Handle(GetVendorProfilingSummaryQuery request, CancellationToken cancellationToken)
        => await runService.GetProfilingSummaryAsync(request.RunId, cancellationToken);
}