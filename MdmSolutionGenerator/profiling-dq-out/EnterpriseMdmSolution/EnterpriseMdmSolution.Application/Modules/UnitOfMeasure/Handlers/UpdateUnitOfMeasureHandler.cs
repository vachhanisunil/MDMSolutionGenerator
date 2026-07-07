using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.UnitOfMeasure;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Handlers;

public sealed class UpdateUnitOfMeasureHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateUnitOfMeasureCommand, UnitOfMeasureDto?>
{
    public async Task<UnitOfMeasureDto?> Handle(UpdateUnitOfMeasureCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<UnitOfMeasureDto>(entity);
    }
}