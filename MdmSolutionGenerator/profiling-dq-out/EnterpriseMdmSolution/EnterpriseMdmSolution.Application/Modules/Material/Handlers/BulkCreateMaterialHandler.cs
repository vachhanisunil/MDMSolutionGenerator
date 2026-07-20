using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Material;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class BulkCreateMaterialHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkCreateMaterialCommand, BulkMaterialOperationResultDto>
{
    public async Task<BulkMaterialOperationResultDto> Handle(BulkCreateMaterialCommand request, CancellationToken cancellationToken)
    {
        var entities = request.Input.Items.Select(mapper.Map<Entity>).ToList();
        foreach (var entity in entities)
        {
            await repository.AddAsync(entity, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkMaterialOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = entities.Count,
            Items = mapper.Map<IReadOnlyList<MaterialDto>>(entities)
        };
    }
}