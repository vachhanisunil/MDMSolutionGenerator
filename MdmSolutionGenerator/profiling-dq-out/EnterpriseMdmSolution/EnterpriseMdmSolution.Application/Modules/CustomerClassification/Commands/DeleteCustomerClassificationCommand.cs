using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.Commands;

public sealed record DeleteCustomerClassificationCommand(int Id) : IRequest<bool>;