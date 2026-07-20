using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Plant.Commands;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Plant;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Handlers;

public sealed class BulkCreatePlantHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkCreatePlantCommand, BulkPlantOperationResultDto>
{
    public async Task<BulkPlantOperationResultDto> Handle(BulkCreatePlantCommand request, CancellationToken cancellationToken)
    {
        var entities = request.Input.Items.Select(mapper.Map<Entity>).ToList();
        foreach (var entity in entities)
        {
            await repository.AddAsync(entity, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkPlantOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = entities.Count,
            Items = mapper.Map<IReadOnlyList<PlantDto>>(entities)
        };
    }
}