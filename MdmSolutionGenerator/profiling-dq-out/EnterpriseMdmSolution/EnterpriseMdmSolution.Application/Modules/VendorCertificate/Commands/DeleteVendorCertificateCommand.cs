using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.Commands;

public sealed record DeleteVendorCertificateCommand(int Id) : IRequest<bool>;