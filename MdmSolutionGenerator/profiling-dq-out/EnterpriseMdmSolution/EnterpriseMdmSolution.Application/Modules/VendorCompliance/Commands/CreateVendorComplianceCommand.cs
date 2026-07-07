using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.Commands;

public sealed record CreateVendorComplianceCommand(CreateVendorComplianceDto Input) : IRequest<VendorComplianceDto>;