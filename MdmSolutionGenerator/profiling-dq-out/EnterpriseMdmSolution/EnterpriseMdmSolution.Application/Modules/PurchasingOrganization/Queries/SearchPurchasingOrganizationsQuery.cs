using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Queries;

public sealed record SearchPurchasingOrganizationsQuery(SearchPurchasingOrganizationDto Search) : IRequest<PagedResult<PurchasingOrganizationDto>>;