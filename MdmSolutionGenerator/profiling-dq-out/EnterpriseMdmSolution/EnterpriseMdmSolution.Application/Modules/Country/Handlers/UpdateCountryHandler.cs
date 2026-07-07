using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Country.Commands;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Country;

namespace EnterpriseMdmSolution.Application.Modules.Country.Handlers;

public sealed class UpdateCountryHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateCountryCommand, CountryDto?>
{
    public async Task<CountryDto?> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CountryDto>(entity);
    }
}