using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.Queries;

public sealed record GetMaterialPriceByIdQuery(int Id) : IRequest<MaterialPriceDto?>;