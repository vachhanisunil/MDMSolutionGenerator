using MediatR;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Queries;

public sealed record GetPaymentTermByIdQuery(int Id) : IRequest<PaymentTermDto?>;