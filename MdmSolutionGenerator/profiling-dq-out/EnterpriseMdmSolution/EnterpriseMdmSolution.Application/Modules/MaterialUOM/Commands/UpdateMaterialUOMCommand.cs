using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.Commands;

public sealed record UpdateMaterialUOMCommand(int Id, UpdateMaterialUOMDto Input) : IRequest<MaterialUOMDto?>;