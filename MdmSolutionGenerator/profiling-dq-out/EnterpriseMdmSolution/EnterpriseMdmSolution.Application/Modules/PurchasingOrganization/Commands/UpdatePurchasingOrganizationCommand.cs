using MediatR;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Commands;

public sealed record UpdatePurchasingOrganizationCommand(int Id, UpdatePurchasingOrganizationDto Input) : IRequest<PurchasingOrganizationDto?>;