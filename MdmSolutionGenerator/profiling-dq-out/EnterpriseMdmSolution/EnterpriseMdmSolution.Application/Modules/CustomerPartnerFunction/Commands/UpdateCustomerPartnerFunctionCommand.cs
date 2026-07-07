using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Commands;

public sealed record UpdateCustomerPartnerFunctionCommand(int Id, UpdateCustomerPartnerFunctionDto Input) : IRequest<CustomerPartnerFunctionDto?>;