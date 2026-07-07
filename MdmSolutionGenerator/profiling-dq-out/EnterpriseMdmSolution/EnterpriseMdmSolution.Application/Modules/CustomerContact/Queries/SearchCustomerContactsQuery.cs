using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.Queries;

public sealed record SearchCustomerContactsQuery(SearchCustomerContactDto Search) : IRequest<PagedResult<CustomerContactDto>>;