using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.Queries;

public sealed record GetMaterialUOMByIdQuery(int Id) : IRequest<MaterialUOMDto?>;