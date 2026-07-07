using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.Queries;

public sealed record GetCustomerTaxByIdQuery(int Id) : IRequest<CustomerTaxDto?>;