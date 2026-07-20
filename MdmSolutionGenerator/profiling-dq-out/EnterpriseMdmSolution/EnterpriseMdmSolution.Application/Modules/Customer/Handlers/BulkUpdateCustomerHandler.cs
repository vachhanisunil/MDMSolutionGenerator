using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Customer;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class BulkUpdateCustomerHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpdateCustomerCommand, BulkCustomerOperationResultDto>
{
    public async Task<BulkCustomerOperationResultDto> Handle(BulkUpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var updatedEntities = new List<Entity>();
        var notFoundIds = new List<int>();

        foreach (var requestedItem in request.Input.Items)
        {
            var existingEntity = await repository.GetByIdAsync(requestedItem.Id, new[] { "CustomerAddresses", "CustomerContacts", "CustomerBankAccounts", "CustomerSalesAreas", "CustomerTaxs", "CustomerClassifications", "CustomerCreditProfiles", "CustomerPartnerFunctions", "CustomerAttachments" }, cancellationToken);
            if (existingEntity is null)
            {
                notFoundIds.Add(requestedItem.Id);
                continue;
            }

            mapper.Map(requestedItem, existingEntity);
        SyncCustomerAddresses(existingEntity.CustomerAddresses, requestedItem.CustomerAddresses);

        void SyncCustomerAddresses(ICollection<EnterpriseMdmSolution.Core.Entities.CustomerAddress> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs.UpdateCustomerAddressDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerAddress>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerAddress>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncCustomerContacts(existingEntity.CustomerContacts, requestedItem.CustomerContacts);

        void SyncCustomerContacts(ICollection<EnterpriseMdmSolution.Core.Entities.CustomerContact> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs.UpdateCustomerContactDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerContact>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerContact>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncCustomerBankAccounts(existingEntity.CustomerBankAccounts, requestedItem.CustomerBankAccounts);

        void SyncCustomerBankAccounts(ICollection<EnterpriseMdmSolution.Core.Entities.CustomerBankAccount> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs.UpdateCustomerBankAccountDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerBankAccount>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerBankAccount>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncCustomerSalesAreas(existingEntity.CustomerSalesAreas, requestedItem.CustomerSalesAreas);

        void SyncCustomerSalesAreas(ICollection<EnterpriseMdmSolution.Core.Entities.CustomerSalesArea> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs.UpdateCustomerSalesAreaDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerSalesArea>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerSalesArea>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncCustomerTaxs(existingEntity.CustomerTaxs, requestedItem.CustomerTaxs);

        void SyncCustomerTaxs(ICollection<EnterpriseMdmSolution.Core.Entities.CustomerTax> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs.UpdateCustomerTaxDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerTax>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerTax>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncCustomerClassifications(existingEntity.CustomerClassifications, requestedItem.CustomerClassifications);

        void SyncCustomerClassifications(ICollection<EnterpriseMdmSolution.Core.Entities.CustomerClassification> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs.UpdateCustomerClassificationDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerClassification>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerClassification>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncCustomerCreditProfiles(existingEntity.CustomerCreditProfiles, requestedItem.CustomerCreditProfiles);

        void SyncCustomerCreditProfiles(ICollection<EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs.UpdateCustomerCreditProfileDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncCustomerPartnerFunctions(existingEntity.CustomerPartnerFunctions, requestedItem.CustomerPartnerFunctions);

        void SyncCustomerPartnerFunctions(ICollection<EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs.UpdateCustomerPartnerFunctionDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncCustomerAttachments(existingEntity.CustomerAttachments, requestedItem.CustomerAttachments);

        void SyncCustomerAttachments(ICollection<EnterpriseMdmSolution.Core.Entities.CustomerAttachment> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs.UpdateCustomerAttachmentDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerAttachment>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerAttachment>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
            repository.Update(existingEntity);
            updatedEntities.Add(existingEntity);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkCustomerOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            UpdatedCount = updatedEntities.Count,
            NotFoundIds = notFoundIds,
            Items = mapper.Map<IReadOnlyList<CustomerDto>>(updatedEntities)
        };
    }
}