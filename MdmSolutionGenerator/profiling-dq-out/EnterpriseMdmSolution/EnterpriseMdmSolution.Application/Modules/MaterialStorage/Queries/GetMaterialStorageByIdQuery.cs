using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.Queries;

public sealed record GetMaterialStorageByIdQuery(int Id) : IRequest<MaterialStorageDto?>;