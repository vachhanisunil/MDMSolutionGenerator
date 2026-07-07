using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.Commands;

public sealed record UpdateCustomerContactCommand(int Id, UpdateCustomerContactDto Input) : IRequest<CustomerContactDto?>;