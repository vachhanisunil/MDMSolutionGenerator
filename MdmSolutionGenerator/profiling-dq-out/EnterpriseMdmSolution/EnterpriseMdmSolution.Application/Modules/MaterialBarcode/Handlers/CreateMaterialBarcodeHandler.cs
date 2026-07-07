using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialBarcode;

namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Handlers;

public sealed class CreateMaterialBarcodeHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateMaterialBarcodeCommand, MaterialBarcodeDto>
{
    public async Task<MaterialBarcodeDto> Handle(CreateMaterialBarcodeCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialBarcodeDto>(entity);
    }
}