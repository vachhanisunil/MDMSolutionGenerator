using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class GetVendorDuplicateDrilldownQueryHandler(IVendorRunService runService)
    : IRequestHandler<GetVendorDuplicateDrilldownQuery, IReadOnlyList<VendorDuplicateDrilldownDto>>
{
    public async Task<IReadOnlyList<VendorDuplicateDrilldownDto>> Handle(GetVendorDuplicateDrilldownQuery request, CancellationToken cancellationToken)
        => await runService.GetDuplicateDrilldownAsync(request.RunId, request.ResultId, cancellationToken);
}