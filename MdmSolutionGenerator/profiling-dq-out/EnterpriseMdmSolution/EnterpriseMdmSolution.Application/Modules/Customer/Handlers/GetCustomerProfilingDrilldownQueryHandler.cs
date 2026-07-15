using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Application.Modules.Customer.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Customer.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class GetCustomerProfilingDrilldownQueryHandler(ICustomerRunService runService)
    : IRequestHandler<GetCustomerProfilingDrilldownQuery, IReadOnlyList<CustomerProfilingDrilldownDto>>
{
    public async Task<IReadOnlyList<CustomerProfilingDrilldownDto>> Handle(GetCustomerProfilingDrilldownQuery request, CancellationToken cancellationToken)
        => await runService.GetProfilingDrilldownAsync(request.RunId, request.SummaryId, cancellationToken);
}