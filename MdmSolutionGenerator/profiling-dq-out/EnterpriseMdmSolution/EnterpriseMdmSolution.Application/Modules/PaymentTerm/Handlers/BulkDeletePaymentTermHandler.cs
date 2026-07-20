using MediatR;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.Commands;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PaymentTerm;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Handlers;

public sealed class BulkDeletePaymentTermHandler(IRepository<Entity> repository)
    : IRequestHandler<BulkDeletePaymentTermCommand, BulkPaymentTermOperationResultDto>
{
    public async Task<BulkPaymentTermOperationResultDto> Handle(BulkDeletePaymentTermCommand request, CancellationToken cancellationToken)
    {
        var deletedCount = 0;
        var notFoundIds = new List<int>();

        foreach (var id in request.Input.Ids)
        {
            var entity = await repository.GetByIdAsync(id, cancellationToken);
            if (entity is null)
            {
                notFoundIds.Add(id);
                continue;
            }

            repository.Delete(entity);
            deletedCount++;
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkPaymentTermOperationResultDto
        {
            RequestedCount = request.Input.Ids.Count,
            DeletedCount = deletedCount,
            NotFoundIds = notFoundIds
        };
    }
}