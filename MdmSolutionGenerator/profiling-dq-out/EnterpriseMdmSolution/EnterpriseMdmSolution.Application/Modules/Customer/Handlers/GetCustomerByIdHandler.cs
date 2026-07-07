using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Application.Modules.Customer.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Customer;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class GetCustomerByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
{
    public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, new[] { "CustomerAddresses", "CustomerContacts", "CustomerBankAccounts", "CustomerSalesAreas", "CustomerTaxs", "CustomerClassifications", "CustomerCreditProfiles", "CustomerPartnerFunctions", "CustomerAttachments" }, cancellationToken);
        return entity is null ? null : mapper.Map<CustomerDto>(entity);
    }
}