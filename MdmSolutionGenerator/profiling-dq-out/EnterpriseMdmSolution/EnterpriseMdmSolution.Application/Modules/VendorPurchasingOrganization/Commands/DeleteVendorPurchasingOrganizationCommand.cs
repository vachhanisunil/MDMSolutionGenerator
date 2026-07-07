using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Commands;

public sealed record DeleteVendorPurchasingOrganizationCommand(int Id) : IRequest<bool>;