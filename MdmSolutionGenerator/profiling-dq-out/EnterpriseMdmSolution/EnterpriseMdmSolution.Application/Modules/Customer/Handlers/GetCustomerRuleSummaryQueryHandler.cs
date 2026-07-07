using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Application.Modules.Customer.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Customer.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class GetCustomerRuleSummaryQueryHandler(ICustomerRunService runService)
    : IRequestHandler<GetCustomerRuleSummaryQuery, IReadOnlyList<CustomerRuleSummaryDto>>
{
    public async Task<IReadOnlyList<CustomerRuleSummaryDto>> Handle(GetCustomerRuleSummaryQuery request, CancellationToken cancellationToken)
        => await runService.GetRuleSummaryAsync(request.RunId, cancellationToken);
}