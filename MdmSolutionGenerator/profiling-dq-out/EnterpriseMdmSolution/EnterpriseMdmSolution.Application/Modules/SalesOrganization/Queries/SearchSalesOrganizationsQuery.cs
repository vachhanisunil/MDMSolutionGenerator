using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Queries;

public sealed record SearchSalesOrganizationsQuery(SearchSalesOrganizationDto Search) : IRequest<PagedResult<SalesOrganizationDto>>;