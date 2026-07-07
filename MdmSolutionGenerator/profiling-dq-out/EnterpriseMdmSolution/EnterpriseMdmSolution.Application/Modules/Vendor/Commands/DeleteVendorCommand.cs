using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Commands;

public sealed record DeleteVendorCommand(int Id) : IRequest<bool>;