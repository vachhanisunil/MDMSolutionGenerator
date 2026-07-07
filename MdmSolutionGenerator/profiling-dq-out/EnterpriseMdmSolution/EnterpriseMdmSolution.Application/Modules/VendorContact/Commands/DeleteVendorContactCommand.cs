using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.VendorContact.Commands;

public sealed record DeleteVendorContactCommand(int Id) : IRequest<bool>;