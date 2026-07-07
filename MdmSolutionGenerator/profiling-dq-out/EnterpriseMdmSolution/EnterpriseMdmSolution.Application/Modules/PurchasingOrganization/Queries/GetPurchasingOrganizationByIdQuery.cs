using MediatR;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Queries;

public sealed record GetPurchasingOrganizationByIdQuery(int Id) : IRequest<PurchasingOrganizationDto?>;