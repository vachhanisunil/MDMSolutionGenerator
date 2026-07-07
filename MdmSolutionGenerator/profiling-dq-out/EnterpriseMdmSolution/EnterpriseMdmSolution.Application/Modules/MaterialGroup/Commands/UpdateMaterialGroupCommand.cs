using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Commands;

public sealed record UpdateMaterialGroupCommand(int Id, UpdateMaterialGroupDto Input) : IRequest<MaterialGroupDto?>;