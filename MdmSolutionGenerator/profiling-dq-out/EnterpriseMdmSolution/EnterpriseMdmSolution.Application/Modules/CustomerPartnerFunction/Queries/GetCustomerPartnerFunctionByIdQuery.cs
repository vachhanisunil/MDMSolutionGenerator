using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Queries;

public sealed record GetCustomerPartnerFunctionByIdQuery(int Id) : IRequest<CustomerPartnerFunctionDto?>;