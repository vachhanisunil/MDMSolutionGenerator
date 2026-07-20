using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.Commands;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PaymentTerm;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Handlers;

public sealed class BulkUpdatePaymentTermHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpdatePaymentTermCommand, BulkPaymentTermOperationResultDto>
{
    public async Task<BulkPaymentTermOperationResultDto> Handle(BulkUpdatePaymentTermCommand request, CancellationToken cancellationToken)
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
        return new BulkPaymentTermOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            UpdatedCount = updatedEntities.Count,
            NotFoundIds = notFoundIds,
            Items = mapper.Map<IReadOnlyList<PaymentTermDto>>(updatedEntities)
        };
    }
}