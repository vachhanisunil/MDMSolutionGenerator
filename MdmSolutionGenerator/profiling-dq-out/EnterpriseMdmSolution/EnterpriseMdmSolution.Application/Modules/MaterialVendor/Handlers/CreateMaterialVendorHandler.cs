using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialVendor;

namespace EnterpriseMdmSolution.Application.Modules.MaterialVendor.Handlers;

public sealed class CreateMaterialVendorHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateMaterialVendorCommand, MaterialVendorDto>
{
    public async Task<MaterialVendorDto> Handle(CreateMaterialVendorCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<MaterialVendorDto>(entity);
    }
}