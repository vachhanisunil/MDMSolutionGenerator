using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Queries;

public sealed record GetVendorPurchasingOrganizationByIdQuery(int Id) : IRequest<VendorPurchasingOrganizationDto?>;