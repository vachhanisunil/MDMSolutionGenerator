using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;
using EnterpriseMdmSolution.Application.Modules.Currency.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Currency;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Handlers;

public sealed class GetCurrencyByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetCurrencyByIdQuery, CurrencyDto?>
{
    public async Task<CurrencyDto?> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<CurrencyDto>(entity);
    }
}