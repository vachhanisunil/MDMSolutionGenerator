using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Customer;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class UpdateCustomerHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateCustomerCommand, CustomerDto?>
{
    public async Task<CustomerDto?> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, new[] { "CustomerAddresses", "CustomerContacts", "CustomerBankAccounts", "CustomerSalesAreas", "CustomerTaxs", "CustomerClassifications", "CustomerCreditProfiles", "CustomerPartnerFunctions", "CustomerAttachments" }, cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);
        repository.ReplaceCollection(entity.CustomerAddresses, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.CustomerAddress>>(request.Input.CustomerAddresses));
        repository.ReplaceCollection(entity.CustomerContacts, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.CustomerContact>>(request.Input.CustomerContacts));
        repository.ReplaceCollection(entity.CustomerBankAccounts, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.CustomerBankAccount>>(request.Input.CustomerBankAccounts));
        repository.ReplaceCollection(entity.CustomerSalesAreas, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.CustomerSalesArea>>(request.Input.CustomerSalesAreas));
        repository.ReplaceCollection(entity.CustomerTaxs, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.CustomerTax>>(request.Input.CustomerTaxs));
        repository.ReplaceCollection(entity.CustomerClassifications, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.CustomerClassification>>(request.Input.CustomerClassifications));
        repository.ReplaceCollection(entity.CustomerCreditProfiles, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile>>(request.Input.CustomerCreditProfiles));
        repository.ReplaceCollection(entity.CustomerPartnerFunctions, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction>>(request.Input.CustomerPartnerFunctions));
        repository.ReplaceCollection(entity.CustomerAttachments, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.CustomerAttachment>>(request.Input.CustomerAttachments));
        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerDto>(entity);
    }
}