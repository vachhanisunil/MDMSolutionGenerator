using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class GetVendorRunsQueryHandler(IVendorRunService runService)
    : IRequestHandler<GetVendorRunsQuery, IReadOnlyList<VendorRunDto>>
{
    public async Task<IReadOnlyList<VendorRunDto>> Handle(GetVendorRunsQuery request, CancellationToken cancellationToken)
        => await runService.GetRunsAsync(cancellationToken);
}