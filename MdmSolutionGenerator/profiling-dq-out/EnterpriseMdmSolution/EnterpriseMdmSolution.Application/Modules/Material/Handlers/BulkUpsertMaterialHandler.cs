using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Material;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class BulkUpsertMaterialHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpsertMaterialCommand, BulkMaterialOperationResultDto>
{
    public async Task<BulkMaterialOperationResultDto> Handle(BulkUpsertMaterialCommand request, CancellationToken cancellationToken)
    {
        var changedEntities = new List<Entity>();
        var createdCount = 0;
        var updatedCount = 0;

        foreach (var requestedItem in request.Input.Items)
        {
            Entity? existingEntity = null;
            if (!EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
            {
                existingEntity = await repository.GetByIdAsync(requestedItem.Id, new[] { "MaterialPlants", "MaterialPrices", "MaterialStorages", "MaterialClassifications", "MaterialVendors", "MaterialUOMs", "MaterialQualityInspections", "MaterialForecasts", "MaterialBarcodes" }, cancellationToken);
            }

            if (existingEntity is null)
            {
                var newEntity = mapper.Map<Entity>(requestedItem);
                foreach (var childItem in requestedItem.MaterialPlants)
                {
                    newEntity.MaterialPlants.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialPlant>(childItem));
                }
                foreach (var childItem in requestedItem.MaterialPrices)
                {
                    newEntity.MaterialPrices.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialPrice>(childItem));
                }
                foreach (var childItem in requestedItem.MaterialStorages)
                {
                    newEntity.MaterialStorages.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialStorage>(childItem));
                }
                foreach (var childItem in requestedItem.MaterialClassifications)
                {
                    newEntity.MaterialClassifications.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialClassification>(childItem));
                }
                foreach (var childItem in requestedItem.MaterialVendors)
                {
                    newEntity.MaterialVendors.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialVendor>(childItem));
                }
                foreach (var childItem in requestedItem.MaterialUOMs)
                {
                    newEntity.MaterialUOMs.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialUOM>(childItem));
                }
                foreach (var childItem in requestedItem.MaterialQualityInspections)
                {
                    newEntity.MaterialQualityInspections.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection>(childItem));
                }
                foreach (var childItem in requestedItem.MaterialForecasts)
                {
                    newEntity.MaterialForecasts.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialForecast>(childItem));
                }
                foreach (var childItem in requestedItem.MaterialBarcodes)
                {
                    newEntity.MaterialBarcodes.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialBarcode>(childItem));
                }
                await repository.AddAsync(newEntity, cancellationToken);
                changedEntities.Add(newEntity);
                createdCount++;
                continue;
            }

            mapper.Map(requestedItem, existingEntity);
        SyncMaterialPlants(existingEntity.MaterialPlants, requestedItem.MaterialPlants);

        void SyncMaterialPlants(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialPlant> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs.UpdateMaterialPlantDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialPlant>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialPlant>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialPrices(existingEntity.MaterialPrices, requestedItem.MaterialPrices);

        void SyncMaterialPrices(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialPrice> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs.UpdateMaterialPriceDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialPrice>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialPrice>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialStorages(existingEntity.MaterialStorages, requestedItem.MaterialStorages);

        void SyncMaterialStorages(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialStorage> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs.UpdateMaterialStorageDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialStorage>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialStorage>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialClassifications(existingEntity.MaterialClassifications, requestedItem.MaterialClassifications);

        void SyncMaterialClassifications(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialClassification> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs.UpdateMaterialClassificationDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialClassification>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialClassification>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialVendors(existingEntity.MaterialVendors, requestedItem.MaterialVendors);

        void SyncMaterialVendors(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialVendor> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs.UpdateMaterialVendorDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialVendor>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialVendor>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialUOMs(existingEntity.MaterialUOMs, requestedItem.MaterialUOMs);

        void SyncMaterialUOMs(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialUOM> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs.UpdateMaterialUOMDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialUOM>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialUOM>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialQualityInspections(existingEntity.MaterialQualityInspections, requestedItem.MaterialQualityInspections);

        void SyncMaterialQualityInspections(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs.UpdateMaterialQualityInspectionDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialForecasts(existingEntity.MaterialForecasts, requestedItem.MaterialForecasts);

        void SyncMaterialForecasts(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialForecast> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs.UpdateMaterialForecastDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialForecast>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialForecast>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialBarcodes(existingEntity.MaterialBarcodes, requestedItem.MaterialBarcodes);

        void SyncMaterialBarcodes(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialBarcode> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs.UpdateMaterialBarcodeDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialBarcode>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialBarcode>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
            repository.Update(existingEntity);
            changedEntities.Add(existingEntity);
            updatedCount++;
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkMaterialOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = createdCount,
            UpdatedCount = updatedCount,
            Items = mapper.Map<IReadOnlyList<MaterialDto>>(changedEntities)
        };
    }
}