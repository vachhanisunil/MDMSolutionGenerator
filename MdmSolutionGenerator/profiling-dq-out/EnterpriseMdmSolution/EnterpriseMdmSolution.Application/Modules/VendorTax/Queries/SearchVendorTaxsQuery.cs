using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorTax.Queries;

public sealed record SearchVendorTaxsQuery(SearchVendorTaxDto Search) : IRequest<PagedResult<VendorTaxDto>>;