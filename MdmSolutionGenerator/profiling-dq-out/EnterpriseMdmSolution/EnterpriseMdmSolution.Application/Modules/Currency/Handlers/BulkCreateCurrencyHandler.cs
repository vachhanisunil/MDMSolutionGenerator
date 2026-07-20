using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Currency.Commands;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Currency;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Handlers;

public sealed class BulkCreateCurrencyHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkCreateCurrencyCommand, BulkCurrencyOperationResultDto>
{
    public async Task<BulkCurrencyOperationResultDto> Handle(BulkCreateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entities = request.Input.Items.Select(mapper.Map<Entity>).ToList();
        foreach (var entity in entities)
        {
            await repository.AddAsync(entity, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkCurrencyOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = entities.Count,
            Items = mapper.Map<IReadOnlyList<CurrencyDto>>(entities)
        };
    }
}