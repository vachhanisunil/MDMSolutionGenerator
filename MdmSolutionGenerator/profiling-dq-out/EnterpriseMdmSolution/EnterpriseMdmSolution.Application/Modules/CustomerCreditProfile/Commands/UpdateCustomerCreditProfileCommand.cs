using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Commands;

public sealed record UpdateCustomerCreditProfileCommand(int Id, UpdateCustomerCreditProfileDto Input) : IRequest<CustomerCreditProfileDto?>;