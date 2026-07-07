using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.Commands;

public sealed record CreateMaterialStorageCommand(CreateMaterialStorageDto Input) : IRequest<MaterialStorageDto>;