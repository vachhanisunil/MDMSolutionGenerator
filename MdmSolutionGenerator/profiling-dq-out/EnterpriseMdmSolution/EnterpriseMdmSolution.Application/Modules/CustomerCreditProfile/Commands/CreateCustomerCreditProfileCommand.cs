using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Commands;

public sealed record CreateCustomerCreditProfileCommand(CreateCustomerCreditProfileDto Input) : IRequest<CustomerCreditProfileDto>;