using MediatR;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Country.Commands;

public sealed record BulkUpsertCountryCommand(BulkUpsertCountryDto Input) : IRequest<BulkCountryOperationResultDto>;