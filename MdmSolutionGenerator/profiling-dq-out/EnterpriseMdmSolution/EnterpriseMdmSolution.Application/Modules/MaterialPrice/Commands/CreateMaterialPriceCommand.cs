using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.Commands;

public sealed record CreateMaterialPriceCommand(CreateMaterialPriceDto Input) : IRequest<MaterialPriceDto>;