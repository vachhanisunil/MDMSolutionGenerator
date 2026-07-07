using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialClassification.Queries;

public sealed record SearchMaterialClassificationsQuery(SearchMaterialClassificationDto Search) : IRequest<PagedResult<MaterialClassificationDto>>;