using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialVendor;

namespace EnterpriseMdmSolution.Application.Modules.MaterialVendor.Handlers;

public sealed class GetMaterialVendorByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetMaterialVendorByIdQuery, MaterialVendorDto?>
{
    public async Task<MaterialVendorDto?> Handle(GetMaterialVendorByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<MaterialVendorDto>(entity);
    }
}