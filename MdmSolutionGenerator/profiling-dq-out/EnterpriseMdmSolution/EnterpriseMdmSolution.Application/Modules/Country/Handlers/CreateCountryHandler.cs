using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Country.Commands;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Country;

namespace EnterpriseMdmSolution.Application.Modules.Country.Handlers;

public sealed class CreateCountryHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateCountryCommand, CountryDto>
{
    public async Task<CountryDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CountryDto>(entity);
    }
}