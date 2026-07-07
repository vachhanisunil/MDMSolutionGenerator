using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.Commands;

public sealed record UpdateVendorCertificateCommand(int Id, UpdateVendorCertificateDto Input) : IRequest<VendorCertificateDto?>;