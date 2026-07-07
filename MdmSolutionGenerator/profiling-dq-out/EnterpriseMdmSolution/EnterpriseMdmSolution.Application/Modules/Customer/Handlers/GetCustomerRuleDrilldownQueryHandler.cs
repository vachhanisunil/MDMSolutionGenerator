using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Application.Modules.Customer.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Customer.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class GetCustomerRuleDrilldownQueryHandler(ICustomerRunService runService)
    : IRequestHandler<GetCustomerRuleDrilldownQuery, IReadOnlyList<CustomerRuleDrilldownDto>>
{
    public async Task<IReadOnlyList<CustomerRuleDrilldownDto>> Handle(GetCustomerRuleDrilldownQuery request, CancellationToken cancellationToken)
        => await runService.GetRuleDrilldownAsync(request.RunId, cancellationToken);
}