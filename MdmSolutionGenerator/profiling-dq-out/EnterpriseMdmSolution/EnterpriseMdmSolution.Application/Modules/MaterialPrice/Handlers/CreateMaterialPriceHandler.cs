using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialPrice;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.Handlers;

public sealed class CreateMaterialPriceHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateMaterialPriceCommand, MaterialPriceDto>
{
    public async Task<MaterialPriceDto> Handle(CreateMaterialPriceCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialPriceDto>(entity);
    }
}