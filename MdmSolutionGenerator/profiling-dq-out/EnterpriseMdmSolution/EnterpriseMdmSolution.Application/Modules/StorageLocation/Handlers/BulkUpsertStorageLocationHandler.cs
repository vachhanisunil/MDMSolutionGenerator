using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.StorageLocation;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Handlers;

public sealed class BulkUpsertStorageLocationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpsertStorageLocationCommand, BulkStorageLocationOperationResultDto>
{
    public async Task<BulkStorageLocationOperationResultDto> Handle(BulkUpsertStorageLocationCommand request, CancellationToken cancellationToken)
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
        return new BulkStorageLocationOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = createdCount,
            UpdatedCount = updatedCount,
            Items = mapper.Map<IReadOnlyList<StorageLocationDto>>(changedEntities)
        };
    }
}