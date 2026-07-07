using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Queries;

public sealed record GetCustomerRuleDrilldownQuery(Guid RunId) : IRequest<IReadOnlyList<CustomerRuleDrilldownDto>>;