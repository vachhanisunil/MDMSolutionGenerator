using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Plant.Commands;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Plant;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Handlers;

public sealed class BulkUpdatePlantHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpdatePlantCommand, BulkPlantOperationResultDto>
{
    public async Task<BulkPlantOperationResultDto> Handle(BulkUpdatePlantCommand request, CancellationToken cancellationToken)
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
        return new BulkPlantOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            UpdatedCount = updatedEntities.Count,
            NotFoundIds = notFoundIds,
            Items = mapper.Map<IReadOnlyList<PlantDto>>(updatedEntities)
        };
    }
}