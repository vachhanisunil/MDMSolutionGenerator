using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.Commands;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PaymentTerm;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Handlers;

public sealed class BulkUpsertPaymentTermHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpsertPaymentTermCommand, BulkPaymentTermOperationResultDto>
{
    public async Task<BulkPaymentTermOperationResultDto> Handle(BulkUpsertPaymentTermCommand request, CancellationToken cancellationToken)
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
        return new BulkPaymentTermOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = createdCount,
            UpdatedCount = updatedCount,
            Items = mapper.Map<IReadOnlyList<PaymentTermDto>>(changedEntities)
        };
    }
}