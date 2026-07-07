using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Application.Common;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Application.Modules.Material.DataQuality.Services;

public sealed class MaterialProfiler(IAnalysisDbContext dbContext)
{
    private readonly IAnalysisDbContext _dbContext = dbContext;

    public async Task ExecuteAsync(Guid runId, CancellationToken cancellationToken)
    {
        await ProfileMaterialMaterialNumberNullCountAsync(runId, cancellationToken);
        await ProfileMaterialMaterialNameNullCountAsync(runId, cancellationToken);
        await ProfileMaterialMaterialTypeNullCountAsync(runId, cancellationToken);
        await ProfileMaterialPlantProcurementTypeNullCountAsync(runId, cancellationToken);
        await ProfileMaterialPricePriceTypeNullCountAsync(runId, cancellationToken);
        await ProfileMaterialClassificationClassTypeNullCountAsync(runId, cancellationToken);
        await ProfileMaterialClassificationClassValueNullCountAsync(runId, cancellationToken);
        await ProfileMaterialQualityInspectionInspectionTypeNullCountAsync(runId, cancellationToken);
        await ProfileMaterialForecastForecastPeriodNullCountAsync(runId, cancellationToken);
        await ProfileMaterialBarcodeBarcodeTypeNullCountAsync(runId, cancellationToken);
        await ProfileMaterialBarcodeBarcodeValueNullCountAsync(runId, cancellationToken);
    }

    private async Task ProfileMaterialMaterialNumberNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Materials
            .Where(x => string.IsNullOrEmpty(x.MaterialNumber))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            ColumnName = "MaterialNumber",
            SummaryCode = "MATERIAL_MATERIAL_MATERIALNUMBER_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "Material MaterialNumber missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIAL_MATERIALNUMBER_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Material",
                EntityName = "Material",
                RootRecordId = x.Id.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "MaterialNumber",
                SummaryCode = "MATERIAL_MATERIAL_MATERIALNUMBER_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.MaterialNumber,
                Message = "Material MaterialNumber missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialNumber }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialMaterialNameNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Materials
            .Where(x => string.IsNullOrEmpty(x.MaterialName))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            ColumnName = "MaterialName",
            SummaryCode = "MATERIAL_MATERIAL_MATERIALNAME_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "Material MaterialName missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIAL_MATERIALNAME_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Material",
                EntityName = "Material",
                RootRecordId = x.Id.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "MaterialName",
                SummaryCode = "MATERIAL_MATERIAL_MATERIALNAME_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.MaterialName,
                Message = "Material MaterialName missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialName }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialMaterialTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Materials
            .Where(x => string.IsNullOrEmpty(x.MaterialType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            ColumnName = "MaterialType",
            SummaryCode = "MATERIAL_MATERIAL_MATERIALTYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "Material MaterialType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIAL_MATERIALTYPE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Material",
                EntityName = "Material",
                RootRecordId = x.Id.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "MaterialType",
                SummaryCode = "MATERIAL_MATERIAL_MATERIALTYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.MaterialType,
                Message = "Material MaterialType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialPlantProcurementTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => string.IsNullOrEmpty(x.ProcurementType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            ColumnName = "ProcurementType",
            SummaryCode = "MATERIAL_MATERIALPLANT_PROCUREMENTTYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "MaterialPlant ProcurementType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIALPLANT_PROCUREMENTTYPE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Material",
                EntityName = "MaterialPlant",
                RootRecordId = x.MaterialId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "ProcurementType",
                SummaryCode = "MATERIAL_MATERIALPLANT_PROCUREMENTTYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.ProcurementType,
                Message = "MaterialPlant ProcurementType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ProcurementType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialPricePriceTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => string.IsNullOrEmpty(x.PriceType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            ColumnName = "PriceType",
            SummaryCode = "MATERIAL_MATERIALPRICE_PRICETYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "MaterialPrice PriceType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIALPRICE_PRICETYPE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Material",
                EntityName = "MaterialPrice",
                RootRecordId = x.MaterialId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "PriceType",
                SummaryCode = "MATERIAL_MATERIALPRICE_PRICETYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.PriceType,
                Message = "MaterialPrice PriceType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PriceType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialClassificationClassTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialClassifications.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialClassification",
            ColumnName = "ClassType",
            SummaryCode = "MATERIAL_MATERIALCLASSIFICATION_CLASSTYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "MaterialClassification ClassType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIALCLASSIFICATION_CLASSTYPE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Material",
                EntityName = "MaterialClassification",
                RootRecordId = x.MaterialId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "ClassType",
                SummaryCode = "MATERIAL_MATERIALCLASSIFICATION_CLASSTYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.ClassType,
                Message = "MaterialClassification ClassType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ClassType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialClassificationClassValueNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialClassifications.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassValue))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialClassification",
            ColumnName = "ClassValue",
            SummaryCode = "MATERIAL_MATERIALCLASSIFICATION_CLASSVALUE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "MaterialClassification ClassValue missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIALCLASSIFICATION_CLASSVALUE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Material",
                EntityName = "MaterialClassification",
                RootRecordId = x.MaterialId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "ClassValue",
                SummaryCode = "MATERIAL_MATERIALCLASSIFICATION_CLASSVALUE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.ClassValue,
                Message = "MaterialClassification ClassValue missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ClassValue }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialQualityInspectionInspectionTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialQualityInspections.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialQualityInspections
            .Where(x => string.IsNullOrEmpty(x.InspectionType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialQualityInspection",
            ColumnName = "InspectionType",
            SummaryCode = "MATERIAL_MATERIALQUALITYINSPECTION_INSPECTIONTYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "MaterialQualityInspection InspectionType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIALQUALITYINSPECTION_INSPECTIONTYPE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Material",
                EntityName = "MaterialQualityInspection",
                RootRecordId = x.MaterialId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "InspectionType",
                SummaryCode = "MATERIAL_MATERIALQUALITYINSPECTION_INSPECTIONTYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.InspectionType,
                Message = "MaterialQualityInspection InspectionType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.InspectionType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialForecastForecastPeriodNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => string.IsNullOrEmpty(x.ForecastPeriod))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            ColumnName = "ForecastPeriod",
            SummaryCode = "MATERIAL_MATERIALFORECAST_FORECASTPERIOD_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "MaterialForecast ForecastPeriod missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIALFORECAST_FORECASTPERIOD_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Material",
                EntityName = "MaterialForecast",
                RootRecordId = x.MaterialId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "ForecastPeriod",
                SummaryCode = "MATERIAL_MATERIALFORECAST_FORECASTPERIOD_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.ForecastPeriod,
                Message = "MaterialForecast ForecastPeriod missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ForecastPeriod }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialBarcodeBarcodeTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialBarcodes.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialBarcodes
            .Where(x => string.IsNullOrEmpty(x.BarcodeType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            ColumnName = "BarcodeType",
            SummaryCode = "MATERIAL_MATERIALBARCODE_BARCODETYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "MaterialBarcode BarcodeType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIALBARCODE_BARCODETYPE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Material",
                EntityName = "MaterialBarcode",
                RootRecordId = x.MaterialId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "BarcodeType",
                SummaryCode = "MATERIAL_MATERIALBARCODE_BARCODETYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.BarcodeType,
                Message = "MaterialBarcode BarcodeType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.BarcodeType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialBarcodeBarcodeValueNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialBarcodes.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialBarcodes
            .Where(x => string.IsNullOrEmpty(x.BarcodeValue))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            ColumnName = "BarcodeValue",
            SummaryCode = "MATERIAL_MATERIALBARCODE_BARCODEVALUE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "MaterialBarcode BarcodeValue missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIALBARCODE_BARCODEVALUE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Material",
                EntityName = "MaterialBarcode",
                RootRecordId = x.MaterialId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "BarcodeValue",
                SummaryCode = "MATERIAL_MATERIALBARCODE_BARCODEVALUE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.BarcodeValue,
                Message = "MaterialBarcode BarcodeValue missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.BarcodeValue }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
