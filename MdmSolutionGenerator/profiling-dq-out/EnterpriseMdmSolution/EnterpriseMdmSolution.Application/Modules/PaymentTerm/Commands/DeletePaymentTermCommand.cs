using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Commands;

public sealed record DeletePaymentTermCommand(int Id) : IRequest<bool>;