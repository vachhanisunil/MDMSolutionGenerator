using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class GetVendorRunQueryHandler(IVendorRunService runService)
    : IRequestHandler<GetVendorRunQuery, VendorRunDto?>
{
    public async Task<VendorRunDto?> Handle(GetVendorRunQuery request, CancellationToken cancellationToken)
        => await runService.GetRunAsync(request.RunId, cancellationToken);
}