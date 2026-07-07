using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.Queries;

public sealed record GetVendorCertificateByIdQuery(int Id) : IRequest<VendorCertificateDto?>;