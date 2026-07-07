using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Currency.Commands;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Currency;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Handlers;

public sealed class CreateCurrencyHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateCurrencyCommand, CurrencyDto>
{
    public async Task<CurrencyDto> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CurrencyDto>(entity);
    }
}