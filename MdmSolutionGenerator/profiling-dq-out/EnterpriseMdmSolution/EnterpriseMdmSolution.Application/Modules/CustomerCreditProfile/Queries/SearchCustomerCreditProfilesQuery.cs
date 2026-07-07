using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Queries;

public sealed record SearchCustomerCreditProfilesQuery(SearchCustomerCreditProfileDto Search) : IRequest<PagedResult<CustomerCreditProfileDto>>;