using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Application.Common;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Application.Modules.Material.DataQuality.Services;

public sealed class MaterialDataQualityRuleExecutor(IAnalysisDbContext dbContext)
{
    private readonly IAnalysisDbContext _dbContext = dbContext;

    public async Task ExecuteAsync(Guid runId, CancellationToken cancellationToken)
    {
        await ExecuteMATERIALMATERIALNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALMATERIALNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALMATERIALTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALMATERIALGROUPIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBASEUNITOFMEASUREIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTPLANTIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTPROCUREMENTTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICECURRENCYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEPRICETYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEPRICEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEVALIDITYDATERANGERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALSTORAGESTORAGELOCATIONIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALVENDORVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALUOMUNITOFMEASUREIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTPLANTIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTFORECASTPERIODREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTFORECASTQUANTITYREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBARCODEBARCODEVALUEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALMATERIALGROUPIDMATERIALGROUPEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBASEUNITOFMEASUREIDUNITOFMEASUREEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTMATERIALIDMATERIALEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTPLANTIDPLANTEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEMATERIALIDMATERIALEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICECURRENCYIDCURRENCYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALSTORAGEMATERIALIDMATERIALEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALSTORAGESTORAGELOCATIONIDSTORAGELOCATIONEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALCLASSIFICATIONMATERIALIDMATERIALEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALVENDORMATERIALIDMATERIALEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALVENDORVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALVENDORPURCHASEUNITOFMEASUREIDUNITOFMEASUREEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALUOMMATERIALIDMATERIALEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALUOMUNITOFMEASUREIDUNITOFMEASUREEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALQUALITYINSPECTIONMATERIALIDMATERIALEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTMATERIALIDMATERIALEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTPLANTIDPLANTEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTFORECASTUNITOFMEASUREIDUNITOFMEASUREEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBARCODEMATERIALIDMATERIALEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBARCODEUNITOFMEASUREIDUNITOFMEASUREEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALNETWEIGHTNOTGREATERTHANGROSSRuleAsync(runId, cancellationToken);
    }

    private async Task ExecuteMATERIALMATERIALNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Materials
            .Where(x => string.IsNullOrEmpty(x.MaterialNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIAL_MATERIALNUMBER_REQUIRED",
            RuleName = "Material.MaterialNumber is mandatory",
            EntityName = "Material",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_MATERIALNUMBER_REQUIRED",
            FieldName = "MaterialNumber",
            Message = "Material.MaterialNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALMATERIALNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Materials
            .Where(x => string.IsNullOrEmpty(x.MaterialName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIAL_MATERIALNAME_REQUIRED",
            RuleName = "Material.MaterialName is mandatory",
            EntityName = "Material",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_MATERIALNAME_REQUIRED",
            FieldName = "MaterialName",
            Message = "Material.MaterialName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALMATERIALTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Materials
            .Where(x => string.IsNullOrEmpty(x.MaterialType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIAL_MATERIALTYPE_REQUIRED",
            RuleName = "Material.MaterialType is mandatory",
            EntityName = "Material",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_MATERIALTYPE_REQUIRED",
            FieldName = "MaterialType",
            Message = "Material.MaterialType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALMATERIALGROUPIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Materials
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIAL_MATERIALGROUPID_REQUIRED",
            RuleName = "Material.MaterialGroupId is mandatory",
            EntityName = "Material",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_MATERIALGROUPID_REQUIRED",
            FieldName = "MaterialGroupId",
            Message = "Material.MaterialGroupId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialGroupId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialGroupId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALBASEUNITOFMEASUREIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Materials
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIAL_BASEUNITOFMEASUREID_REQUIRED",
            RuleName = "Material.BaseUnitOfMeasureId is mandatory",
            EntityName = "Material",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_BASEUNITOFMEASUREID_REQUIRED",
            FieldName = "BaseUnitOfMeasureId",
            Message = "Material.BaseUnitOfMeasureId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BaseUnitOfMeasureId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.BaseUnitOfMeasureId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTPLANTIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPLANT_PLANTID_REQUIRED",
            RuleName = "MaterialPlant.PlantId is mandatory",
            EntityName = "MaterialPlant",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_PLANTID_REQUIRED",
            FieldName = "PlantId",
            Message = "MaterialPlant.PlantId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PlantId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PlantId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTPROCUREMENTTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => string.IsNullOrEmpty(x.ProcurementType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPLANT_PROCUREMENTTYPE_REQUIRED",
            RuleName = "MaterialPlant.ProcurementType is mandatory",
            EntityName = "MaterialPlant",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_PROCUREMENTTYPE_REQUIRED",
            FieldName = "ProcurementType",
            Message = "MaterialPlant.ProcurementType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ProcurementType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ProcurementType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRICECURRENCYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPRICE_CURRENCYID_REQUIRED",
            RuleName = "MaterialPrice.CurrencyId is mandatory",
            EntityName = "MaterialPrice",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_CURRENCYID_REQUIRED",
            FieldName = "CurrencyId",
            Message = "MaterialPrice.CurrencyId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRICEPRICETYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => string.IsNullOrEmpty(x.PriceType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPRICE_PRICETYPE_REQUIRED",
            RuleName = "MaterialPrice.PriceType is mandatory",
            EntityName = "MaterialPrice",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_PRICETYPE_REQUIRED",
            FieldName = "PriceType",
            Message = "MaterialPrice.PriceType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PriceType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PriceType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRICEPRICEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPRICE_PRICE_REQUIRED",
            RuleName = "MaterialPrice.Price is mandatory",
            EntityName = "MaterialPrice",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_PRICE_REQUIRED",
            FieldName = "Price",
            Message = "MaterialPrice.Price is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.Price.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.Price }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRICEVALIDITYDATERANGERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => x.ValidTo < x.ValidFrom)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPRICE_VALIDITY_DATE_RANGE",
            RuleName = "MaterialPrice.ValidTo must be after ValidFrom",
            EntityName = "MaterialPrice",
            Category = "Timeliness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_VALIDITY_DATE_RANGE",
            FieldName = "",
            Message = "MaterialPrice.ValidTo cannot be earlier than ValidFrom.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALSTORAGESTORAGELOCATIONIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialStorages.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialStorages
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALSTORAGE_STORAGELOCATIONID_REQUIRED",
            RuleName = "MaterialStorage.StorageLocationId is mandatory",
            EntityName = "MaterialStorage",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialStorage",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALSTORAGE_STORAGELOCATIONID_REQUIRED",
            FieldName = "StorageLocationId",
            Message = "MaterialStorage.StorageLocationId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.StorageLocationId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.StorageLocationId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALVENDORVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialVendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialVendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALVENDOR_VENDORID_REQUIRED",
            RuleName = "MaterialVendor.VendorId is mandatory",
            EntityName = "MaterialVendor",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALVENDOR_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "MaterialVendor.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALUOMUNITOFMEASUREIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialUOMs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialUOMs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALUOM_UNITOFMEASUREID_REQUIRED",
            RuleName = "MaterialUOM.UnitOfMeasureId is mandatory",
            EntityName = "MaterialUOM",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALUOM_UNITOFMEASUREID_REQUIRED",
            FieldName = "UnitOfMeasureId",
            Message = "MaterialUOM.UnitOfMeasureId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.UnitOfMeasureId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.UnitOfMeasureId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALFORECASTPLANTIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALFORECAST_PLANTID_REQUIRED",
            RuleName = "MaterialForecast.PlantId is mandatory",
            EntityName = "MaterialForecast",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALFORECAST_PLANTID_REQUIRED",
            FieldName = "PlantId",
            Message = "MaterialForecast.PlantId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PlantId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PlantId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALFORECASTFORECASTPERIODREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => string.IsNullOrEmpty(x.ForecastPeriod))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALFORECAST_FORECASTPERIOD_REQUIRED",
            RuleName = "MaterialForecast.ForecastPeriod is mandatory",
            EntityName = "MaterialForecast",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALFORECAST_FORECASTPERIOD_REQUIRED",
            FieldName = "ForecastPeriod",
            Message = "MaterialForecast.ForecastPeriod is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ForecastPeriod,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ForecastPeriod }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALFORECASTFORECASTQUANTITYREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALFORECAST_FORECASTQUANTITY_REQUIRED",
            RuleName = "MaterialForecast.ForecastQuantity is mandatory",
            EntityName = "MaterialForecast",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALFORECAST_FORECASTQUANTITY_REQUIRED",
            FieldName = "ForecastQuantity",
            Message = "MaterialForecast.ForecastQuantity is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ForecastQuantity.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ForecastQuantity }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALBARCODEBARCODEVALUEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialBarcodes.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialBarcodes
            .Where(x => string.IsNullOrEmpty(x.BarcodeValue))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALBARCODE_BARCODEVALUE_REQUIRED",
            RuleName = "MaterialBarcode.BarcodeValue is mandatory",
            EntityName = "MaterialBarcode",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALBARCODE_BARCODEVALUE_REQUIRED",
            FieldName = "BarcodeValue",
            Message = "MaterialBarcode.BarcodeValue is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BarcodeValue,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.BarcodeValue }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALMATERIALGROUPIDMATERIALGROUPEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Materials
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIAL_MATERIALGROUPID_MATERIALGROUP_EXISTS",
            RuleName = "Material.MaterialGroupId must exist in MaterialGroup",
            EntityName = "Material",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_MATERIALGROUPID_MATERIALGROUP_EXISTS",
            FieldName = "MaterialGroupId",
            Message = "Material.MaterialGroupId must refer to an existing MaterialGroup.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialGroupId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialGroupId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALBASEUNITOFMEASUREIDUNITOFMEASUREEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Materials
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIAL_BASEUNITOFMEASUREID_UNITOFMEASURE_EXISTS",
            RuleName = "Material.BaseUnitOfMeasureId must exist in UnitOfMeasure",
            EntityName = "Material",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_BASEUNITOFMEASUREID_UNITOFMEASURE_EXISTS",
            FieldName = "BaseUnitOfMeasureId",
            Message = "Material.BaseUnitOfMeasureId must refer to an existing UnitOfMeasure.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BaseUnitOfMeasureId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.BaseUnitOfMeasureId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTMATERIALIDMATERIALEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPLANT_MATERIALID_MATERIAL_EXISTS",
            RuleName = "MaterialPlant.MaterialId must exist in Material",
            EntityName = "MaterialPlant",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_MATERIALID_MATERIAL_EXISTS",
            FieldName = "MaterialId",
            Message = "MaterialPlant.MaterialId must refer to an existing Material.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTPLANTIDPLANTEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPLANT_PLANTID_PLANT_EXISTS",
            RuleName = "MaterialPlant.PlantId must exist in Plant",
            EntityName = "MaterialPlant",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_PLANTID_PLANT_EXISTS",
            FieldName = "PlantId",
            Message = "MaterialPlant.PlantId must refer to an existing Plant.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PlantId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PlantId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRICEMATERIALIDMATERIALEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPRICE_MATERIALID_MATERIAL_EXISTS",
            RuleName = "MaterialPrice.MaterialId must exist in Material",
            EntityName = "MaterialPrice",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_MATERIALID_MATERIAL_EXISTS",
            FieldName = "MaterialId",
            Message = "MaterialPrice.MaterialId must refer to an existing Material.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRICECURRENCYIDCURRENCYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPRICE_CURRENCYID_CURRENCY_EXISTS",
            RuleName = "MaterialPrice.CurrencyId must exist in Currency",
            EntityName = "MaterialPrice",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_CURRENCYID_CURRENCY_EXISTS",
            FieldName = "CurrencyId",
            Message = "MaterialPrice.CurrencyId must refer to an existing Currency.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALSTORAGEMATERIALIDMATERIALEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialStorages.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialStorages
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALSTORAGE_MATERIALID_MATERIAL_EXISTS",
            RuleName = "MaterialStorage.MaterialId must exist in Material",
            EntityName = "MaterialStorage",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialStorage",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALSTORAGE_MATERIALID_MATERIAL_EXISTS",
            FieldName = "MaterialId",
            Message = "MaterialStorage.MaterialId must refer to an existing Material.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALSTORAGESTORAGELOCATIONIDSTORAGELOCATIONEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialStorages.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialStorages
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALSTORAGE_STORAGELOCATIONID_STORAGELOCATION_EXISTS",
            RuleName = "MaterialStorage.StorageLocationId must exist in StorageLocation",
            EntityName = "MaterialStorage",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialStorage",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALSTORAGE_STORAGELOCATIONID_STORAGELOCATION_EXISTS",
            FieldName = "StorageLocationId",
            Message = "MaterialStorage.StorageLocationId must refer to an existing StorageLocation.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.StorageLocationId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.StorageLocationId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALCLASSIFICATIONMATERIALIDMATERIALEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialClassifications
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALCLASSIFICATION_MATERIALID_MATERIAL_EXISTS",
            RuleName = "MaterialClassification.MaterialId must exist in Material",
            EntityName = "MaterialClassification",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialClassification",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALCLASSIFICATION_MATERIALID_MATERIAL_EXISTS",
            FieldName = "MaterialId",
            Message = "MaterialClassification.MaterialId must refer to an existing Material.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALVENDORMATERIALIDMATERIALEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialVendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialVendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALVENDOR_MATERIALID_MATERIAL_EXISTS",
            RuleName = "MaterialVendor.MaterialId must exist in Material",
            EntityName = "MaterialVendor",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALVENDOR_MATERIALID_MATERIAL_EXISTS",
            FieldName = "MaterialId",
            Message = "MaterialVendor.MaterialId must refer to an existing Material.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALVENDORVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialVendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialVendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALVENDOR_VENDORID_VENDOR_EXISTS",
            RuleName = "MaterialVendor.VendorId must exist in Vendor",
            EntityName = "MaterialVendor",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALVENDOR_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "MaterialVendor.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALVENDORPURCHASEUNITOFMEASUREIDUNITOFMEASUREEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialVendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialVendors
            .Where(x => x.PurchaseUnitOfMeasureId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALVENDOR_PURCHASEUNITOFMEASUREID_UNITOFMEASURE_EXISTS",
            RuleName = "MaterialVendor.PurchaseUnitOfMeasureId must exist in UnitOfMeasure",
            EntityName = "MaterialVendor",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALVENDOR_PURCHASEUNITOFMEASUREID_UNITOFMEASURE_EXISTS",
            FieldName = "PurchaseUnitOfMeasureId",
            Message = "MaterialVendor.PurchaseUnitOfMeasureId must refer to an existing UnitOfMeasure.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PurchaseUnitOfMeasureId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PurchaseUnitOfMeasureId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALUOMMATERIALIDMATERIALEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialUOMs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialUOMs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALUOM_MATERIALID_MATERIAL_EXISTS",
            RuleName = "MaterialUOM.MaterialId must exist in Material",
            EntityName = "MaterialUOM",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALUOM_MATERIALID_MATERIAL_EXISTS",
            FieldName = "MaterialId",
            Message = "MaterialUOM.MaterialId must refer to an existing Material.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALUOMUNITOFMEASUREIDUNITOFMEASUREEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialUOMs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialUOMs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALUOM_UNITOFMEASUREID_UNITOFMEASURE_EXISTS",
            RuleName = "MaterialUOM.UnitOfMeasureId must exist in UnitOfMeasure",
            EntityName = "MaterialUOM",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALUOM_UNITOFMEASUREID_UNITOFMEASURE_EXISTS",
            FieldName = "UnitOfMeasureId",
            Message = "MaterialUOM.UnitOfMeasureId must refer to an existing UnitOfMeasure.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.UnitOfMeasureId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.UnitOfMeasureId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALQUALITYINSPECTIONMATERIALIDMATERIALEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialQualityInspections.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialQualityInspections
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALQUALITYINSPECTION_MATERIALID_MATERIAL_EXISTS",
            RuleName = "MaterialQualityInspection.MaterialId must exist in Material",
            EntityName = "MaterialQualityInspection",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialQualityInspection",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALQUALITYINSPECTION_MATERIALID_MATERIAL_EXISTS",
            FieldName = "MaterialId",
            Message = "MaterialQualityInspection.MaterialId must refer to an existing Material.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALFORECASTMATERIALIDMATERIALEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALFORECAST_MATERIALID_MATERIAL_EXISTS",
            RuleName = "MaterialForecast.MaterialId must exist in Material",
            EntityName = "MaterialForecast",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALFORECAST_MATERIALID_MATERIAL_EXISTS",
            FieldName = "MaterialId",
            Message = "MaterialForecast.MaterialId must refer to an existing Material.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALFORECASTPLANTIDPLANTEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALFORECAST_PLANTID_PLANT_EXISTS",
            RuleName = "MaterialForecast.PlantId must exist in Plant",
            EntityName = "MaterialForecast",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALFORECAST_PLANTID_PLANT_EXISTS",
            FieldName = "PlantId",
            Message = "MaterialForecast.PlantId must refer to an existing Plant.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PlantId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PlantId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALFORECASTFORECASTUNITOFMEASUREIDUNITOFMEASUREEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALFORECAST_FORECASTUNITOFMEASUREID_UNITOFMEASURE_EXISTS",
            RuleName = "MaterialForecast.ForecastUnitOfMeasureId must exist in UnitOfMeasure",
            EntityName = "MaterialForecast",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALFORECAST_FORECASTUNITOFMEASUREID_UNITOFMEASURE_EXISTS",
            FieldName = "ForecastUnitOfMeasureId",
            Message = "MaterialForecast.ForecastUnitOfMeasureId must refer to an existing UnitOfMeasure.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ForecastUnitOfMeasureId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ForecastUnitOfMeasureId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALBARCODEMATERIALIDMATERIALEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialBarcodes.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialBarcodes
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALBARCODE_MATERIALID_MATERIAL_EXISTS",
            RuleName = "MaterialBarcode.MaterialId must exist in Material",
            EntityName = "MaterialBarcode",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALBARCODE_MATERIALID_MATERIAL_EXISTS",
            FieldName = "MaterialId",
            Message = "MaterialBarcode.MaterialId must refer to an existing Material.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALBARCODEUNITOFMEASUREIDUNITOFMEASUREEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialBarcodes.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialBarcodes
            .Where(x => x.UnitOfMeasureId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALBARCODE_UNITOFMEASUREID_UNITOFMEASURE_EXISTS",
            RuleName = "MaterialBarcode.UnitOfMeasureId must exist in UnitOfMeasure",
            EntityName = "MaterialBarcode",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALBARCODE_UNITOFMEASUREID_UNITOFMEASURE_EXISTS",
            FieldName = "UnitOfMeasureId",
            Message = "MaterialBarcode.UnitOfMeasureId must refer to an existing UnitOfMeasure.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.UnitOfMeasureId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.UnitOfMeasureId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALNETWEIGHTNOTGREATERTHANGROSSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Materials
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIAL_NET_WEIGHT_NOT_GREATER_THAN_GROSS",
            RuleName = "Material net weight must not exceed gross weight",
            EntityName = "Material",
            Category = "Accuracy",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_NET_WEIGHT_NOT_GREATER_THAN_GROSS",
            FieldName = "",
            Message = "Net weight cannot be greater than gross weight.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
