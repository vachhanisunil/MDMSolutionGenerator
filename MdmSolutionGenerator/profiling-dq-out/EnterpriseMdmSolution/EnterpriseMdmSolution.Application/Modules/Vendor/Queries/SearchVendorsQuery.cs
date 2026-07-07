using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

public sealed record SearchVendorsQuery(SearchVendorDto Search) : IRequest<PagedResult<VendorDto>>;