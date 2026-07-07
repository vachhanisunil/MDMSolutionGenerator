using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.UnitOfMeasure;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Handlers;

public sealed class GetUnitOfMeasureByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetUnitOfMeasureByIdQuery, UnitOfMeasureDto?>
{
    public async Task<UnitOfMeasureDto?> Handle(GetUnitOfMeasureByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<UnitOfMeasureDto>(entity);
    }
}