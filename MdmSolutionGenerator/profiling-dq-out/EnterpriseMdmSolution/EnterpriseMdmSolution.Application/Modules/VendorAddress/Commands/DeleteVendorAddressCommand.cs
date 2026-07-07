using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.VendorAddress.Commands;

public sealed record DeleteVendorAddressCommand(int Id) : IRequest<bool>;