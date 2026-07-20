using MediatR;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Commands;

public sealed record BulkUpdatePaymentTermCommand(BulkUpdatePaymentTermDto Input) : IRequest<BulkPaymentTermOperationResultDto>;