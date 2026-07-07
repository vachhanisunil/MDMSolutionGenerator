using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class GetVendorProfilingDrilldownQueryHandler(IVendorRunService runService)
    : IRequestHandler<GetVendorProfilingDrilldownQuery, IReadOnlyList<VendorProfilingDrilldownDto>>
{
    public async Task<IReadOnlyList<VendorProfilingDrilldownDto>> Handle(GetVendorProfilingDrilldownQuery request, CancellationToken cancellationToken)
        => await runService.GetProfilingDrilldownAsync(request.RunId, cancellationToken);
}