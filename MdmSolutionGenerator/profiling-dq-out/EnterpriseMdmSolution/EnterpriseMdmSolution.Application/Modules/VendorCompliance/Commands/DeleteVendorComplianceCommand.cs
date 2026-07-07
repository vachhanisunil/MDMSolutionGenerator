using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.Commands;

public sealed record DeleteVendorComplianceCommand(int Id) : IRequest<bool>;