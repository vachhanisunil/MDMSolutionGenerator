using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAddress.Queries;

public sealed record SearchCustomerAddressesQuery(SearchCustomerAddressDto Search) : IRequest<PagedResult<CustomerAddressDto>>;