using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.Commands;

public sealed record UpdateCustomerClassificationCommand(int Id, UpdateCustomerClassificationDto Input) : IRequest<CustomerClassificationDto?>;