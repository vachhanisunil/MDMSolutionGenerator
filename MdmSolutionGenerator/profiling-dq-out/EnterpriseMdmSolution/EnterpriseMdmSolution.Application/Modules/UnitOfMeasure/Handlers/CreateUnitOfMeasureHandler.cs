using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.UnitOfMeasure;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Handlers;

public sealed class CreateUnitOfMeasureHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateUnitOfMeasureCommand, UnitOfMeasureDto>
{
    public async Task<UnitOfMeasureDto> Handle(CreateUnitOfMeasureCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<UnitOfMeasureDto>(entity);
    }
}