using MediatR;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Country.Commands;

public sealed record BulkCreateCountryCommand(BulkCreateCountryDto Input) : IRequest<BulkCountryOperationResultDto>;