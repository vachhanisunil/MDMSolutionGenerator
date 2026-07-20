using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.SalesOrganization;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Handlers;

public sealed class BulkUpdateSalesOrganizationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpdateSalesOrganizationCommand, BulkSalesOrganizationOperationResultDto>
{
    public async Task<BulkSalesOrganizationOperationResultDto> Handle(BulkUpdateSalesOrganizationCommand request, CancellationToken cancellationToken)
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
        return new BulkSalesOrganizationOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            UpdatedCount = updatedEntities.Count,
            NotFoundIds = notFoundIds,
            Items = mapper.Map<IReadOnlyList<SalesOrganizationDto>>(updatedEntities)
        };
    }
}