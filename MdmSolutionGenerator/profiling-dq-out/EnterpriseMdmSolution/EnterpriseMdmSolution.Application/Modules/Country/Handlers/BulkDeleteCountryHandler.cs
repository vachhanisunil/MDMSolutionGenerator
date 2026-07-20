using MediatR;
using EnterpriseMdmSolution.Application.Modules.Country.Commands;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Country;

namespace EnterpriseMdmSolution.Application.Modules.Country.Handlers;

public sealed class BulkDeleteCountryHandler(IRepository<Entity> repository)
    : IRequestHandler<BulkDeleteCountryCommand, BulkCountryOperationResultDto>
{
    public async Task<BulkCountryOperationResultDto> Handle(BulkDeleteCountryCommand request, CancellationToken cancellationToken)
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
        return new BulkCountryOperationResultDto
        {
            RequestedCount = request.Input.Ids.Count,
            DeletedCount = deletedCount,
            NotFoundIds = notFoundIds
        };
    }
}