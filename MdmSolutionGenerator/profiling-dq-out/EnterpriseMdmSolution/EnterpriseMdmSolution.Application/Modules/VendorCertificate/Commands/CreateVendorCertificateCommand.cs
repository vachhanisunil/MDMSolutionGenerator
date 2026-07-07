using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.Commands;

public sealed record CreateVendorCertificateCommand(CreateVendorCertificateDto Input) : IRequest<VendorCertificateDto>;