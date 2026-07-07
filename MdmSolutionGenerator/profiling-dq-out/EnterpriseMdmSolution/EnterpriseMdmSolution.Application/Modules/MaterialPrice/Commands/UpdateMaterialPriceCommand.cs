using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.Commands;

public sealed record UpdateMaterialPriceCommand(int Id, UpdateMaterialPriceDto Input) : IRequest<MaterialPriceDto?>;