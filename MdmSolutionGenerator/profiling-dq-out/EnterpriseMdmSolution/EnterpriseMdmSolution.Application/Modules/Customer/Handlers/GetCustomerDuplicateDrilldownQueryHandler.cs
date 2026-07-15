using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Application.Modules.Customer.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Customer.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class GetCustomerDuplicateDrilldownQueryHandler(ICustomerRunService runService)
    : IRequestHandler<GetCustomerDuplicateDrilldownQuery, IReadOnlyList<CustomerDuplicateDrilldownDto>>
{
    public async Task<IReadOnlyList<CustomerDuplicateDrilldownDto>> Handle(GetCustomerDuplicateDrilldownQuery request, CancellationToken cancellationToken)
        => await runService.GetDuplicateDrilldownAsync(request.RunId, request.ResultId, cancellationToken);
}