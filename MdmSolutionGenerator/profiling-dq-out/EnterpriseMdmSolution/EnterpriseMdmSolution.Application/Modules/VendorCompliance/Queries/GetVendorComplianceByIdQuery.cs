using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.Queries;

public sealed record GetVendorComplianceByIdQuery(int Id) : IRequest<VendorComplianceDto?>;