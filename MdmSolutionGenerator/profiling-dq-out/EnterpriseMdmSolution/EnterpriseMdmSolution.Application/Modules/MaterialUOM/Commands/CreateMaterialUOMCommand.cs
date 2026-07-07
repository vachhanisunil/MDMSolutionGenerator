using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.Commands;

public sealed record CreateMaterialUOMCommand(CreateMaterialUOMDto Input) : IRequest<MaterialUOMDto>;