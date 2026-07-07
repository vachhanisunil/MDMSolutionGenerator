using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.Queries;

public sealed record SearchVendorCertificatesQuery(SearchVendorCertificateDto Search) : IRequest<PagedResult<VendorCertificateDto>>;