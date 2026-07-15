using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Queries;

public sealed record GetCustomerDuplicateDrilldownQuery(Guid RunId, Guid ResultId) : IRequest<IReadOnlyList<CustomerDuplicateDrilldownDto>>;