using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialClassification;

namespace EnterpriseMdmSolution.Application.Modules.MaterialClassification.Handlers;

public sealed class CreateMaterialClassificationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateMaterialClassificationCommand, MaterialClassificationDto>
{
    public async Task<MaterialClassificationDto> Handle(CreateMaterialClassificationCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialClassificationDto>(entity);
    }
}