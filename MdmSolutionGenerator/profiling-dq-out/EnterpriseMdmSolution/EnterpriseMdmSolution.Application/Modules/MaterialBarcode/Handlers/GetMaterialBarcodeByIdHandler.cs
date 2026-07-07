using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialBarcode;

namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Handlers;

public sealed class GetMaterialBarcodeByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetMaterialBarcodeByIdQuery, MaterialBarcodeDto?>
{
    public async Task<MaterialBarcodeDto?> Handle(GetMaterialBarcodeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<MaterialBarcodeDto>(entity);
    }
}