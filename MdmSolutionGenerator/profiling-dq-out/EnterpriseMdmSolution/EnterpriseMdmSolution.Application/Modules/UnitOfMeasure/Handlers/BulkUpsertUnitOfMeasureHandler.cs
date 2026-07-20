using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.UnitOfMeasure;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Handlers;

public sealed class BulkUpsertUnitOfMeasureHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpsertUnitOfMeasureCommand, BulkUnitOfMeasureOperationResultDto>
{
    public async Task<BulkUnitOfMeasureOperationResultDto> Handle(BulkUpsertUnitOfMeasureCommand request, CancellationToken cancellationToken)
    {
        var changedEntities = new List<Entity>();
        var createdCount = 0;
        var updatedCount = 0;

        foreach (var requestedItem in request.Input.Items)
        {
            Entity? existingEntity = null;
            if (!EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
            {
                existingEntity = await repository.GetByIdAsync(requestedItem.Id, Array.Empty<string>(), cancellationToken);
            }

            if (existingEntity is null)
            {
                var newEntity = mapper.Map<Entity>(requestedItem);

                await repository.AddAsync(newEntity, cancellationToken);
                changedEntities.Add(newEntity);
                createdCount++;
                continue;
            }

            mapper.Map(requestedItem, existingEntity);

            repository.Update(existingEntity);
            changedEntities.Add(existingEntity);
            updatedCount++;
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkUnitOfMeasureOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = createdCount,
            UpdatedCount = updatedCount,
            Items = mapper.Map<IReadOnlyList<UnitOfMeasureDto>>(changedEntities)
        };
    }
}