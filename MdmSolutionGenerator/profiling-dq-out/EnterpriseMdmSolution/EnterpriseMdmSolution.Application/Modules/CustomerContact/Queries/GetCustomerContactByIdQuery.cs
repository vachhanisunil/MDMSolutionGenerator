using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.Queries;

public sealed record GetCustomerContactByIdQuery(int Id) : IRequest<CustomerContactDto?>;