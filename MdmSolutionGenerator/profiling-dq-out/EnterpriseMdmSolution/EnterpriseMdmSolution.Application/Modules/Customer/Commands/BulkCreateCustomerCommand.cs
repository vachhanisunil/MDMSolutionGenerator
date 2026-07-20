using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Commands;

public sealed record BulkCreateCustomerCommand(BulkCreateCustomerDto Input) : IRequest<BulkCustomerOperationResultDto>;