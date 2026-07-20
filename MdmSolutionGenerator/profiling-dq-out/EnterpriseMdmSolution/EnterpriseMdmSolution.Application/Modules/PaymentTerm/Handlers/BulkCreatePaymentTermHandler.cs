using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.Commands;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PaymentTerm;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Handlers;

public sealed class BulkCreatePaymentTermHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkCreatePaymentTermCommand, BulkPaymentTermOperationResultDto>
{
    public async Task<BulkPaymentTermOperationResultDto> Handle(BulkCreatePaymentTermCommand request, CancellationToken cancellationToken)
    {
        var entities = request.Input.Items.Select(mapper.Map<Entity>).ToList();
        foreach (var entity in entities)
        {
            await repository.AddAsync(entity, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkPaymentTermOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = entities.Count,
            Items = mapper.Map<IReadOnlyList<PaymentTermDto>>(entities)
        };
    }
}