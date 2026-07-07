using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Queries;

public sealed record GetCustomerCreditProfileByIdQuery(int Id) : IRequest<CustomerCreditProfileDto?>;