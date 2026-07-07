using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Commands;

public sealed record DeleteCustomerPartnerFunctionCommand(int Id) : IRequest<bool>;