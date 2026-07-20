using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Country.Commands;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Country;

namespace EnterpriseMdmSolution.Application.Modules.Country.Handlers;

public sealed class BulkUpdateCountryHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpdateCountryCommand, BulkCountryOperationResultDto>
{
    public async Task<BulkCountryOperationResultDto> Handle(BulkUpdateCountryCommand request, CancellationToken cancellationToken)
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
        return new BulkCountryOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            UpdatedCount = updatedEntities.Count,
            NotFoundIds = notFoundIds,
            Items = mapper.Map<IReadOnlyList<CountryDto>>(updatedEntities)
        };
    }
}