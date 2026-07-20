using MediatR;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Commands;

public sealed record BulkCreatePaymentTermCommand(BulkCreatePaymentTermDto Input) : IRequest<BulkPaymentTermOperationResultDto>;