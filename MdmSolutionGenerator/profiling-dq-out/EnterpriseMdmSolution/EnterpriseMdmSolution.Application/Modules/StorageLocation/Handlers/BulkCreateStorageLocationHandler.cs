using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.StorageLocation;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Handlers;

public sealed class BulkCreateStorageLocationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkCreateStorageLocationCommand, BulkStorageLocationOperationResultDto>
{
    public async Task<BulkStorageLocationOperationResultDto> Handle(BulkCreateStorageLocationCommand request, CancellationToken cancellationToken)
    {
        var entities = request.Input.Items.Select(mapper.Map<Entity>).ToList();
        foreach (var entity in entities)
        {
            await repository.AddAsync(entity, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkStorageLocationOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = entities.Count,
            Items = mapper.Map<IReadOnlyList<StorageLocationDto>>(entities)
        };
    }
}