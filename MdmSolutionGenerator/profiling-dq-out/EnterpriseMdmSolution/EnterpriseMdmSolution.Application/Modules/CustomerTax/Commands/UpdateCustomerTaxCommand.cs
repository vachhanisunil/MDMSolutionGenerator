using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.Commands;

public sealed record UpdateCustomerTaxCommand(int Id, UpdateCustomerTaxDto Input) : IRequest<CustomerTaxDto?>;