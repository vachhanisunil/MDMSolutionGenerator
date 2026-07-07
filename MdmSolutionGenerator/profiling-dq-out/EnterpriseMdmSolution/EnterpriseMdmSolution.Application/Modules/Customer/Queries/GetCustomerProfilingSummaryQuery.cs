using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Queries;

public sealed record GetCustomerProfilingSummaryQuery(Guid RunId) : IRequest<IReadOnlyList<CustomerProfilingSummaryDto>>;