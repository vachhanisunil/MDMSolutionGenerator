using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class GetVendorRuleSummaryQueryHandler(IVendorRunService runService)
    : IRequestHandler<GetVendorRuleSummaryQuery, IReadOnlyList<VendorRuleSummaryDto>>
{
    public async Task<IReadOnlyList<VendorRuleSummaryDto>> Handle(GetVendorRuleSummaryQuery request, CancellationToken cancellationToken)
        => await runService.GetRuleSummaryAsync(request.RunId, cancellationToken);
}