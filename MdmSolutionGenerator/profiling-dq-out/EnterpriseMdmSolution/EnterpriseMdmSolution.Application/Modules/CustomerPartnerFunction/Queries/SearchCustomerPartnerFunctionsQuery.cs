using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Queries;

public sealed record SearchCustomerPartnerFunctionsQuery(SearchCustomerPartnerFunctionDto Search) : IRequest<PagedResult<CustomerPartnerFunctionDto>>;