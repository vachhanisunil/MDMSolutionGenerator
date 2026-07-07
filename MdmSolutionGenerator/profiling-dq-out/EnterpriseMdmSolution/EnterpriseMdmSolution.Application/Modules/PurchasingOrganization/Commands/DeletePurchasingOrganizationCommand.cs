using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Commands;

public sealed record DeletePurchasingOrganizationCommand(int Id) : IRequest<bool>;