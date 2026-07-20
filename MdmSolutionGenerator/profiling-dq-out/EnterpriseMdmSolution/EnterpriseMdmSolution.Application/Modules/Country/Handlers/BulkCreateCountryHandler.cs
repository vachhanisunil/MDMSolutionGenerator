using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Country.Commands;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Country;

namespace EnterpriseMdmSolution.Application.Modules.Country.Handlers;

public sealed class BulkCreateCountryHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkCreateCountryCommand, BulkCountryOperationResultDto>
{
    public async Task<BulkCountryOperationResultDto> Handle(BulkCreateCountryCommand request, CancellationToken cancellationToken)
    {
        var entities = request.Input.Items.Select(mapper.Map<Entity>).ToList();
        foreach (var entity in entities)
        {
            await repository.AddAsync(entity, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkCountryOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = entities.Count,
            Items = mapper.Map<IReadOnlyList<CountryDto>>(entities)
        };
    }
}