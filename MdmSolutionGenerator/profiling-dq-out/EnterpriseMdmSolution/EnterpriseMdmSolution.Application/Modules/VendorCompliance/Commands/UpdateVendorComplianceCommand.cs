using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.Commands;

public sealed record UpdateVendorComplianceCommand(int Id, UpdateVendorComplianceDto Input) : IRequest<VendorComplianceDto?>;