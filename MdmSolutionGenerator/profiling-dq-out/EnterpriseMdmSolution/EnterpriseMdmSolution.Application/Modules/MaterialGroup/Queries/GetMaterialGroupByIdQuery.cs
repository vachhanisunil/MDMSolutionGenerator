using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Queries;

public sealed record GetMaterialGroupByIdQuery(int Id) : IRequest<MaterialGroupDto?>;