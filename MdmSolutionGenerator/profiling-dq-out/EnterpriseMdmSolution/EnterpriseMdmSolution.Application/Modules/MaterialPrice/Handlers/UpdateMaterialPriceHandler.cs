using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialPrice;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.Handlers;

public sealed class UpdateMaterialPriceHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateMaterialPriceCommand, MaterialPriceDto?>
{
    public async Task<MaterialPriceDto?> Handle(UpdateMaterialPriceCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialPriceDto>(entity);
    }
}