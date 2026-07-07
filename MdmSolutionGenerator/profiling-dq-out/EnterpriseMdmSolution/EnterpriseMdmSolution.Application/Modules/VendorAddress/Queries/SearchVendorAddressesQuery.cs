using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorAddress.Queries;

public sealed record SearchVendorAddressesQuery(SearchVendorAddressDto Search) : IRequest<PagedResult<VendorAddressDto>>;