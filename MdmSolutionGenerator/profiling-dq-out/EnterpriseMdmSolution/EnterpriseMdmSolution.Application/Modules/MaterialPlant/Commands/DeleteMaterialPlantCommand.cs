using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.Commands;

public sealed record DeleteMaterialPlantCommand(int Id) : IRequest<bool>;