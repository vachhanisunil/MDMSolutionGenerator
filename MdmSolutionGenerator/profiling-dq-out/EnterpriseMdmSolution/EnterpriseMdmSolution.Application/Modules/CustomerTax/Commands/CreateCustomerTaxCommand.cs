using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.Commands;

public sealed record CreateCustomerTaxCommand(CreateCustomerTaxDto Input) : IRequest<CustomerTaxDto>;