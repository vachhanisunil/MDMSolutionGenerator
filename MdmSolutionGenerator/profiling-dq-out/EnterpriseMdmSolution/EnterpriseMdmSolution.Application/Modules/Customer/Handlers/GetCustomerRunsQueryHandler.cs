using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Application.Modules.Customer.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Customer.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class GetCustomerRunsQueryHandler(ICustomerRunService runService)
    : IRequestHandler<GetCustomerRunsQuery, IReadOnlyList<CustomerRunDto>>
{
    public async Task<IReadOnlyList<CustomerRunDto>> Handle(GetCustomerRunsQuery request, CancellationToken cancellationToken)
        => await runService.GetRunsAsync(cancellationToken);
}