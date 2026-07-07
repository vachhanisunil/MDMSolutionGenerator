using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Application.Modules.Customer.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Customer.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class GetCustomerRunQueryHandler(ICustomerRunService runService)
    : IRequestHandler<GetCustomerRunQuery, CustomerRunDto?>
{
    public async Task<CustomerRunDto?> Handle(GetCustomerRunQuery request, CancellationToken cancellationToken)
        => await runService.GetRunAsync(request.RunId, cancellationToken);
}