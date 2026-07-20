using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.UnitOfMeasure;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Handlers;

public sealed class BulkCreateUnitOfMeasureHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkCreateUnitOfMeasureCommand, BulkUnitOfMeasureOperationResultDto>
{
    public async Task<BulkUnitOfMeasureOperationResultDto> Handle(BulkCreateUnitOfMeasureCommand request, CancellationToken cancellationToken)
    {
        var entities = request.Input.Items.Select(mapper.Map<Entity>).ToList();
        foreach (var entity in entities)
        {
            await repository.AddAsync(entity, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkUnitOfMeasureOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = entities.Count,
            Items = mapper.Map<IReadOnlyList<UnitOfMeasureDto>>(entities)
        };
    }
}