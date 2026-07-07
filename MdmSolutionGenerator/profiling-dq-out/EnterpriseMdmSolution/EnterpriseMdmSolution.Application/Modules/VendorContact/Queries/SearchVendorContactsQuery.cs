using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorContact.Queries;

public sealed record SearchVendorContactsQuery(SearchVendorContactDto Search) : IRequest<PagedResult<VendorContactDto>>;