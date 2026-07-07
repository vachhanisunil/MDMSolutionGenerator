using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.Commands;

public sealed record DeleteMaterialPriceCommand(int Id) : IRequest<bool>;