using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialBarcode;

namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Handlers;

public sealed class UpdateMaterialBarcodeHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateMaterialBarcodeCommand, MaterialBarcodeDto?>
{
    public async Task<MaterialBarcodeDto?> Handle(UpdateMaterialBarcodeCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialBarcodeDto>(entity);
    }
}