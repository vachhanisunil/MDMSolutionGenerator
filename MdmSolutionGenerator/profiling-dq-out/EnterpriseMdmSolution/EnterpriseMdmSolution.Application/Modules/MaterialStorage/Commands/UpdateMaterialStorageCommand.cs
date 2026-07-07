using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.Commands;

public sealed record UpdateMaterialStorageCommand(int Id, UpdateMaterialStorageDto Input) : IRequest<MaterialStorageDto?>;