using System.Text.Json;
using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Customer;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class ExecuteBulkCustomerJobHandler(
    IRepository<BulkOperationJob> jobRepository,
    IRepository<BulkOperationItem> itemRepository,
    IRepository<Entity> repository,
    IMapper mapper)
    : IRequestHandler<ExecuteBulkCustomerJobCommand>
{
    public async Task Handle(ExecuteBulkCustomerJobCommand request, CancellationToken cancellationToken)
    {
        var job = await jobRepository.GetByIdAsync(request.JobId, cancellationToken);
        if (job is null || job.BusinessObjectName != "Customer")
        {
            return;
        }

        var items = (await itemRepository.ListAsync(cancellationToken))
            .Where(x => x.JobId == job.JobId)
            .OrderBy(x => x.SequenceNumber)
            .ToList();

        try
        {
            job.Status = "Running";
            job.StartedOn = DateTimeOffset.UtcNow;
            jobRepository.Update(job);
            await jobRepository.SaveChangesAsync(cancellationToken);

            switch (job.Operation)
            {
                case "BulkCreate":
                    await ExecuteCreateAsync(job, items, cancellationToken);
                    break;
                case "BulkUpsert":
                    await ExecuteUpsertAsync(job, items, cancellationToken);
                    break;
                case "BulkDelete":
                    await ExecuteDeleteAsync(job, items, cancellationToken);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported bulk operation '{job.Operation}'.");
            }

            job.Status = job.FailedCount == 0 ? "Completed" : "CompletedWithErrors";
            job.CompletedOn = DateTimeOffset.UtcNow;
            jobRepository.Update(job);
            await jobRepository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            job.Status = "Failed";
            job.ErrorMessage = exception.Message;
            job.CompletedOn = DateTimeOffset.UtcNow;
            jobRepository.Update(job);
            await jobRepository.SaveChangesAsync(CancellationToken.None);
        }
    }

    private async Task ExecuteCreateAsync(BulkOperationJob job, IReadOnlyList<BulkOperationItem> jobItems, CancellationToken cancellationToken)
    {
        foreach (var jobItem in jobItems)
        {
            try
            {
                var input = JsonSerializer.Deserialize<CreateCustomerDto>(jobItem.InputSnapshotJson) ?? throw new InvalidOperationException("Bulk item payload is invalid.");
                var entity = mapper.Map<Entity>(input);
                await repository.AddAsync(entity, cancellationToken);
                await repository.SaveChangesAsync(cancellationToken);
                job.CreatedCount++;
                MarkSucceeded(jobItem, entity);
            }
            catch (Exception exception)
            {
                MarkFailed(job, jobItem, exception);
            }
        }
    }

    private async Task ExecuteUpsertAsync(BulkOperationJob job, IReadOnlyList<BulkOperationItem> jobItems, CancellationToken cancellationToken)
    {
        foreach (var jobItem in jobItems)
        {
            try
            {
                var input = JsonSerializer.Deserialize<UpdateCustomerDto>(jobItem.InputSnapshotJson) ?? throw new InvalidOperationException("Bulk item payload is invalid.");
                Entity? existingEntity = null;
                if (!EqualityComparer<int>.Default.Equals(input.Id, 0))
                {
                    existingEntity = await repository.GetByIdAsync(input.Id, new[] { "CustomerAddresses", "CustomerContacts", "CustomerBankAccounts", "CustomerSalesAreas", "CustomerTaxs", "CustomerClassifications", "CustomerCreditProfiles", "CustomerPartnerFunctions", "CustomerAttachments" }, cancellationToken);
                }

                if (existingEntity is null)
                {
                    var newEntity = mapper.Map<Entity>(input);
                foreach (var childItem in input.CustomerAddresses)
                {
                    newEntity.CustomerAddresses.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerAddress>(childItem));
                }
                foreach (var childItem in input.CustomerContacts)
                {
                    newEntity.CustomerContacts.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerContact>(childItem));
                }
                foreach (var childItem in input.CustomerBankAccounts)
                {
                    newEntity.CustomerBankAccounts.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerBankAccount>(childItem));
                }
                foreach (var childItem in input.CustomerSalesAreas)
                {
                    newEntity.CustomerSalesAreas.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerSalesArea>(childItem));
                }
                foreach (var childItem in input.CustomerTaxs)
                {
                    newEntity.CustomerTaxs.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerTax>(childItem));
                }
                foreach (var childItem in input.CustomerClassifications)
                {
                    newEntity.CustomerClassifications.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerClassification>(childItem));
                }
                foreach (var childItem in input.CustomerCreditProfiles)
                {
                    newEntity.CustomerCreditProfiles.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile>(childItem));
                }
                foreach (var childItem in input.CustomerPartnerFunctions)
                {
                    newEntity.CustomerPartnerFunctions.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction>(childItem));
                }
                foreach (var childItem in input.CustomerAttachments)
                {
                    newEntity.CustomerAttachments.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.CustomerAttachment>(childItem));
                }
                    await repository.AddAsync(newEntity, cancellationToken);
                    await repository.SaveChangesAsync(cancellationToken);
                    job.CreatedCount++;
                    MarkSucceeded(jobItem, newEntity);
                    continue;
                }

                mapper.Map(input, existingEntity);
        SyncCustomerAddresses(existingEntity.CustomerAddresses, input.CustomerAddresses);

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
        SyncCustomerContacts(existingEntity.CustomerContacts, input.CustomerContacts);

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
        SyncCustomerBankAccounts(existingEntity.CustomerBankAccounts, input.CustomerBankAccounts);

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
        SyncCustomerSalesAreas(existingEntity.CustomerSalesAreas, input.CustomerSalesAreas);

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
        SyncCustomerTaxs(existingEntity.CustomerTaxs, input.CustomerTaxs);

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
        SyncCustomerClassifications(existingEntity.CustomerClassifications, input.CustomerClassifications);

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
        SyncCustomerCreditProfiles(existingEntity.CustomerCreditProfiles, input.CustomerCreditProfiles);

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
        SyncCustomerPartnerFunctions(existingEntity.CustomerPartnerFunctions, input.CustomerPartnerFunctions);

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
        SyncCustomerAttachments(existingEntity.CustomerAttachments, input.CustomerAttachments);

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
                await repository.SaveChangesAsync(cancellationToken);
                job.UpdatedCount++;
                MarkSucceeded(jobItem, existingEntity);
            }
            catch (Exception exception)
            {
                MarkFailed(job, jobItem, exception);
            }
        }
    }

    private async Task ExecuteDeleteAsync(BulkOperationJob job, IReadOnlyList<BulkOperationItem> jobItems, CancellationToken cancellationToken)
    {
        foreach (var jobItem in jobItems)
        {
            try
            {
                var id = JsonSerializer.Deserialize<int>(jobItem.InputSnapshotJson);
                var entity = await repository.GetByIdAsync(id!, cancellationToken);
                if (entity is null)
                {
                    MarkNotFound(job, jobItem, id.ToString());
                    continue;
                }

                repository.Delete(entity);
                await repository.SaveChangesAsync(cancellationToken);
                job.DeletedCount++;
                jobItem.Status = "Succeeded";
                jobItem.RecordId = id.ToString();
            }
            catch (Exception exception)
            {
                MarkFailed(job, jobItem, exception);
            }
        }
    }

    private void MarkSucceeded(BulkOperationItem jobItem, Entity entity)
    {
        jobItem.Status = "Succeeded";
        jobItem.RecordId = entity.Id.ToString();
        jobItem.ResultSnapshotJson = JsonSerializer.Serialize(mapper.Map<CustomerDto>(entity));
        itemRepository.Update(jobItem);
    }

    private static void MarkNotFound(BulkOperationJob job, BulkOperationItem jobItem, string? recordId)
    {
        job.FailedCount++;
        jobItem.Status = "NotFound";
        jobItem.RecordId = recordId;
        jobItem.ErrorMessage = "Record was not found.";
    }

    private static void MarkFailed(BulkOperationJob job, BulkOperationItem jobItem, Exception exception)
    {
        job.FailedCount++;
        jobItem.Status = "Failed";
        jobItem.ErrorMessage = exception.Message;
    }
}