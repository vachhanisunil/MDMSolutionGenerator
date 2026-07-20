using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialGroup;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Handlers;

public sealed class BulkUpsertMaterialGroupHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpsertMaterialGroupCommand, BulkMaterialGroupOperationResultDto>
{
    public async Task<BulkMaterialGroupOperationResultDto> Handle(BulkUpsertMaterialGroupCommand request, CancellationToken cancellationToken)
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
        return new BulkMaterialGroupOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = createdCount,
            UpdatedCount = updatedCount,
            Items = mapper.Map<IReadOnlyList<MaterialGroupDto>>(changedEntities)
        };
    }
}