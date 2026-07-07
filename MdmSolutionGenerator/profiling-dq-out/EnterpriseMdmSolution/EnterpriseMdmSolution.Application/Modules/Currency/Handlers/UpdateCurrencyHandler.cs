using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Currency.Commands;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Currency;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Handlers;

public sealed class UpdateCurrencyHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateCurrencyCommand, CurrencyDto?>
{
    public async Task<CurrencyDto?> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CurrencyDto>(entity);
    }
}