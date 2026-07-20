using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.StorageLocation;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Handlers;

public sealed class BulkUpdateStorageLocationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpdateStorageLocationCommand, BulkStorageLocationOperationResultDto>
{
    public async Task<BulkStorageLocationOperationResultDto> Handle(BulkUpdateStorageLocationCommand request, CancellationToken cancellationToken)
    {
        var updatedEntities = new List<Entity>();
        var notFoundIds = new List<int>();

        foreach (var requestedItem in request.Input.Items)
        {
            var existingEntity = await repository.GetByIdAsync(requestedItem.Id, Array.Empty<string>(), cancellationToken);
            if (existingEntity is null)
            {
                notFoundIds.Add(requestedItem.Id);
                continue;
            }

            mapper.Map(requestedItem, existingEntity);

            repository.Update(existingEntity);
            updatedEntities.Add(existingEntity);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkStorageLocationOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            UpdatedCount = updatedEntities.Count,
            NotFoundIds = notFoundIds,
            Items = mapper.Map<IReadOnlyList<StorageLocationDto>>(updatedEntities)
        };
    }
}