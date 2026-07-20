using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialGroup;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Handlers;

public sealed class BulkCreateMaterialGroupHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkCreateMaterialGroupCommand, BulkMaterialGroupOperationResultDto>
{
    public async Task<BulkMaterialGroupOperationResultDto> Handle(BulkCreateMaterialGroupCommand request, CancellationToken cancellationToken)
    {
        var entities = request.Input.Items.Select(mapper.Map<Entity>).ToList();
        foreach (var entity in entities)
        {
            await repository.AddAsync(entity, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkMaterialGroupOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = entities.Count,
            Items = mapper.Map<IReadOnlyList<MaterialGroupDto>>(entities)
        };
    }
}