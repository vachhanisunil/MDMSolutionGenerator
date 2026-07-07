using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Application.Modules.Customer.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Customer.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class GetCustomerProfilingSummaryQueryHandler(ICustomerRunService runService)
    : IRequestHandler<GetCustomerProfilingSummaryQuery, IReadOnlyList<CustomerProfilingSummaryDto>>
{
    public async Task<IReadOnlyList<CustomerProfilingSummaryDto>> Handle(GetCustomerProfilingSummaryQuery request, CancellationToken cancellationToken)
        => await runService.GetProfilingSummaryAsync(request.RunId, cancellationToken);
}