using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Handlers;

public sealed class BulkCreatePurchasingOrganizationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkCreatePurchasingOrganizationCommand, BulkPurchasingOrganizationOperationResultDto>
{
    public async Task<BulkPurchasingOrganizationOperationResultDto> Handle(BulkCreatePurchasingOrganizationCommand request, CancellationToken cancellationToken)
    {
        var entities = request.Input.Items.Select(mapper.Map<Entity>).ToList();
        foreach (var entity in entities)
        {
            await repository.AddAsync(entity, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkPurchasingOrganizationOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = entities.Count,
            Items = mapper.Map<IReadOnlyList<PurchasingOrganizationDto>>(entities)
        };
    }
}