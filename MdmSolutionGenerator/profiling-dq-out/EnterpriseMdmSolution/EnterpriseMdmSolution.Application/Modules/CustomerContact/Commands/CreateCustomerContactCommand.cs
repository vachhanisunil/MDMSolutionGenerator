using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.Commands;

public sealed record CreateCustomerContactCommand(CreateCustomerContactDto Input) : IRequest<CustomerContactDto>;