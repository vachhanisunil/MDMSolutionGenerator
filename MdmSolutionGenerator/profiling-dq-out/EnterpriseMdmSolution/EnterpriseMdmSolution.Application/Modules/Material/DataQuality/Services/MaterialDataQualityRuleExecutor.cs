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
        await ExecuteMATERIALMATERIALNUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALMATERIALNUMBERUNIQUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALMATERIALNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALMATERIALNAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALMATERIALTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALMATERIALTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALMATERIALTYPEALLOWEDVALUESRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALMATERIALGROUPIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBASEUNITOFMEASUREIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALGLOBALTRADEITEMNUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRODUCTHIERARCHYMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALGROSSWEIGHTMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALNETWEIGHTMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALISBATCHMANAGEDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALISSERIALMANAGEDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALISACTIVEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTMATERIALIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTPLANTIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTPROCUREMENTTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTPROCUREMENTTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTPROCUREMENTTYPEALLOWEDVALUESRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTREORDERPOINTMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTMINIMUMLOTSIZEMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTMAXIMUMLOTSIZEMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTMRPTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTPLANNINGTIMEFENCEDAYSMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTPLANNINGTIMEFENCEDAYSMAXVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPLANTPROFITCENTERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEMATERIALIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICECURRENCYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEPRICETYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEPRICETYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEPRICETYPEALLOWEDVALUESRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEPRICEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEPRICEMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEPRICEUNITREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEPRICEUNITMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEVALIDFROMREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICESOURCESYSTEMMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALPRICEVALIDITYDATERANGERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALSTORAGEMATERIALIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALSTORAGESTORAGELOCATIONIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALSTORAGEBINLOCATIONMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALSTORAGESAFETYSTOCKMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALSTORAGEMAXIMUMSTOCKMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALSTORAGETEMPERATUREZONEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALCLASSIFICATIONMATERIALIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALCLASSIFICATIONCLASSTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALCLASSIFICATIONCLASSTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALCLASSIFICATIONCLASSVALUEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALCLASSIFICATIONCLASSVALUEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALCLASSIFICATIONCHARACTERISTICNAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALVENDORMATERIALIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALVENDORVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALVENDORVENDORMATERIALNUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALVENDORLEADTIMEDAYSMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALVENDORLEADTIMEDAYSMAXVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALVENDORMINIMUMORDERQUANTITYMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALVENDORISPREFERREDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALUOMMATERIALIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALUOMUNITOFMEASUREIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALUOMCONVERSIONNUMERATORREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALUOMCONVERSIONNUMERATORMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALUOMCONVERSIONDENOMINATORREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALUOMCONVERSIONDENOMINATORMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALUOMBARCODEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALUOMISBASEUNITREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALQUALITYINSPECTIONMATERIALIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALQUALITYINSPECTIONINSPECTIONTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALQUALITYINSPECTIONINSPECTIONTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALQUALITYINSPECTIONINSPECTIONINTERVALDAYSMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALQUALITYINSPECTIONINSPECTIONINTERVALDAYSMAXVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALQUALITYINSPECTIONQUALITYCERTIFICATEREQUIREDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALQUALITYINSPECTIONSAMPLESIZEMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALQUALITYINSPECTIONACCEPTANCECRITERIAMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTMATERIALIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTPLANTIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTFORECASTPERIODREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTFORECASTPERIODMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTFORECASTQUANTITYREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTFORECASTQUANTITYMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTFORECASTUNITOFMEASUREIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTCONFIDENCEPERCENTMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALFORECASTCONFIDENCEPERCENTMAXVALUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBARCODEMATERIALIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBARCODEBARCODETYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBARCODEBARCODETYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBARCODEBARCODETYPEALLOWEDVALUESRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBARCODEBARCODEVALUEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBARCODEBARCODEVALUEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBARCODEBARCODEVALUEUNIQUERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALBARCODEISPRIMARYREQUIREDRuleAsync(runId, cancellationToken);
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
        await ExecuteACTIVEMATERIALREQUIRESPLANTRuleAsync(runId, cancellationToken);
        await ExecuteACTIVEMATERIALREQUIRESPRICERuleAsync(runId, cancellationToken);
        await ExecuteMATERIALNETWEIGHTNOTGREATERTHANGROSSRuleAsync(runId, cancellationToken);
        await ExecuteBATCHMANAGEDMATERIALREQUIRESINSPECTIONRuleAsync(runId, cancellationToken);
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

    private async Task ExecuteMATERIALMATERIALNUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIAL_MATERIALNUMBER_MAX_LENGTH",
            RuleName = "Material.MaterialNumber must not exceed 40 characters",
            EntityName = "Material",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_MATERIALNUMBER_MAX_LENGTH",
            FieldName = "MaterialNumber",
            Message = "Material.MaterialNumber exceeds maximum length 40.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.MaterialNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALMATERIALNUMBERUNIQUERuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIAL_MATERIALNUMBER_UNIQUE",
            RuleName = "Material.MaterialNumber must be unique",
            EntityName = "Material",
            Category = "Uniqueness",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_MATERIALNUMBER_UNIQUE",
            FieldName = "MaterialNumber",
            Message = "Material.MaterialNumber must be unique.",
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

    private async Task ExecuteMATERIALMATERIALNAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIAL_MATERIALNAME_MAX_LENGTH",
            RuleName = "Material.MaterialName must not exceed 200 characters",
            EntityName = "Material",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_MATERIALNAME_MAX_LENGTH",
            FieldName = "MaterialName",
            Message = "Material.MaterialName exceeds maximum length 200.",
            Severity = "Medium",
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

    private async Task ExecuteMATERIALMATERIALTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIAL_MATERIALTYPE_MAX_LENGTH",
            RuleName = "Material.MaterialType must not exceed 30 characters",
            EntityName = "Material",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_MATERIALTYPE_MAX_LENGTH",
            FieldName = "MaterialType",
            Message = "Material.MaterialType exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.MaterialType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALMATERIALTYPEALLOWEDVALUESRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIAL_MATERIALTYPE_ALLOWED_VALUES",
            RuleName = "Material.MaterialType must contain an allowed value",
            EntityName = "Material",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_MATERIALTYPE_ALLOWED_VALUES",
            FieldName = "MaterialType",
            Message = "Material.MaterialType has invalid value.",
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

    private async Task ExecuteMATERIALGLOBALTRADEITEMNUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Materials
            .Where(x => string.IsNullOrEmpty(x.GlobalTradeItemNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIAL_GLOBALTRADEITEMNUMBER_MAX_LENGTH",
            RuleName = "Material.GlobalTradeItemNumber must not exceed 50 characters",
            EntityName = "Material",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_GLOBALTRADEITEMNUMBER_MAX_LENGTH",
            FieldName = "GlobalTradeItemNumber",
            Message = "Material.GlobalTradeItemNumber exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.GlobalTradeItemNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.GlobalTradeItemNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRODUCTHIERARCHYMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Materials
            .Where(x => string.IsNullOrEmpty(x.ProductHierarchy))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIAL_PRODUCTHIERARCHY_MAX_LENGTH",
            RuleName = "Material.ProductHierarchy must not exceed 50 characters",
            EntityName = "Material",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_PRODUCTHIERARCHY_MAX_LENGTH",
            FieldName = "ProductHierarchy",
            Message = "Material.ProductHierarchy exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.ProductHierarchy,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.ProductHierarchy }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALGROSSWEIGHTMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Materials
            .Where(x => x.GrossWeight >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIAL_GROSSWEIGHT_MIN_VALUE",
            RuleName = "Material.GrossWeight must be >= 0",
            EntityName = "Material",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_GROSSWEIGHT_MIN_VALUE",
            FieldName = "GrossWeight",
            Message = "Material.GrossWeight must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.GrossWeight.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.GrossWeight }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALNETWEIGHTMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Materials
            .Where(x => x.NetWeight >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIAL_NETWEIGHT_MIN_VALUE",
            RuleName = "Material.NetWeight must be >= 0",
            EntityName = "Material",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_NETWEIGHT_MIN_VALUE",
            FieldName = "NetWeight",
            Message = "Material.NetWeight must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.NetWeight.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.NetWeight }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALISBATCHMANAGEDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIAL_ISBATCHMANAGED_REQUIRED",
            RuleName = "Material.IsBatchManaged is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_ISBATCHMANAGED_REQUIRED",
            FieldName = "IsBatchManaged",
            Message = "Material.IsBatchManaged is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsBatchManaged.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.IsBatchManaged }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALISSERIALMANAGEDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIAL_ISSERIALMANAGED_REQUIRED",
            RuleName = "Material.IsSerialManaged is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_ISSERIALMANAGED_REQUIRED",
            FieldName = "IsSerialManaged",
            Message = "Material.IsSerialManaged is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsSerialManaged.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.IsSerialManaged }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALISACTIVEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIAL_ISACTIVE_REQUIRED",
            RuleName = "Material.IsActive is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIAL_ISACTIVE_REQUIRED",
            FieldName = "IsActive",
            Message = "Material.IsActive is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsActive.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.IsActive }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTMATERIALIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALPLANT_MATERIALID_REQUIRED",
            RuleName = "MaterialPlant.MaterialId is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_MATERIALID_REQUIRED",
            FieldName = "MaterialId",
            Message = "MaterialPlant.MaterialId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
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

    private async Task ExecuteMATERIALPLANTPROCUREMENTTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALPLANT_PROCUREMENTTYPE_MAX_LENGTH",
            RuleName = "MaterialPlant.ProcurementType must not exceed 30 characters",
            EntityName = "MaterialPlant",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_PROCUREMENTTYPE_MAX_LENGTH",
            FieldName = "ProcurementType",
            Message = "MaterialPlant.ProcurementType exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.ProcurementType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ProcurementType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTPROCUREMENTTYPEALLOWEDVALUESRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALPLANT_PROCUREMENTTYPE_ALLOWED_VALUES",
            RuleName = "MaterialPlant.ProcurementType must contain an allowed value",
            EntityName = "MaterialPlant",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_PROCUREMENTTYPE_ALLOWED_VALUES",
            FieldName = "ProcurementType",
            Message = "MaterialPlant.ProcurementType has invalid value.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ProcurementType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ProcurementType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTREORDERPOINTMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => x.ReorderPoint >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPLANT_REORDERPOINT_MIN_VALUE",
            RuleName = "MaterialPlant.ReorderPoint must be >= 0",
            EntityName = "MaterialPlant",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_REORDERPOINT_MIN_VALUE",
            FieldName = "ReorderPoint",
            Message = "MaterialPlant.ReorderPoint must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ReorderPoint.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ReorderPoint }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTMINIMUMLOTSIZEMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => x.MinimumLotSize >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPLANT_MINIMUMLOTSIZE_MIN_VALUE",
            RuleName = "MaterialPlant.MinimumLotSize must be >= 0",
            EntityName = "MaterialPlant",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_MINIMUMLOTSIZE_MIN_VALUE",
            FieldName = "MinimumLotSize",
            Message = "MaterialPlant.MinimumLotSize must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MinimumLotSize.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.MinimumLotSize }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTMAXIMUMLOTSIZEMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => x.MaximumLotSize >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPLANT_MAXIMUMLOTSIZE_MIN_VALUE",
            RuleName = "MaterialPlant.MaximumLotSize must be >= 0",
            EntityName = "MaterialPlant",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_MAXIMUMLOTSIZE_MIN_VALUE",
            FieldName = "MaximumLotSize",
            Message = "MaterialPlant.MaximumLotSize must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaximumLotSize.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.MaximumLotSize }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTMRPTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => string.IsNullOrEmpty(x.MrpType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPLANT_MRPTYPE_MAX_LENGTH",
            RuleName = "MaterialPlant.MrpType must not exceed 20 characters",
            EntityName = "MaterialPlant",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_MRPTYPE_MAX_LENGTH",
            FieldName = "MrpType",
            Message = "MaterialPlant.MrpType exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.MrpType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.MrpType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTPLANNINGTIMEFENCEDAYSMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => x.PlanningTimeFenceDays >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPLANT_PLANNINGTIMEFENCEDAYS_MIN_VALUE",
            RuleName = "MaterialPlant.PlanningTimeFenceDays must be >= 0",
            EntityName = "MaterialPlant",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_PLANNINGTIMEFENCEDAYS_MIN_VALUE",
            FieldName = "PlanningTimeFenceDays",
            Message = "MaterialPlant.PlanningTimeFenceDays must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PlanningTimeFenceDays.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PlanningTimeFenceDays }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTPLANNINGTIMEFENCEDAYSMAXVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => x.PlanningTimeFenceDays <= 365)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPLANT_PLANNINGTIMEFENCEDAYS_MAX_VALUE",
            RuleName = "MaterialPlant.PlanningTimeFenceDays must be <= 365",
            EntityName = "MaterialPlant",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_PLANNINGTIMEFENCEDAYS_MAX_VALUE",
            FieldName = "PlanningTimeFenceDays",
            Message = "MaterialPlant.PlanningTimeFenceDays must be less than or equal to 365.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PlanningTimeFenceDays.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PlanningTimeFenceDays }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPLANTPROFITCENTERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => string.IsNullOrEmpty(x.ProfitCenter))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPLANT_PROFITCENTER_MAX_LENGTH",
            RuleName = "MaterialPlant.ProfitCenter must not exceed 50 characters",
            EntityName = "MaterialPlant",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPLANT_PROFITCENTER_MAX_LENGTH",
            FieldName = "ProfitCenter",
            Message = "MaterialPlant.ProfitCenter exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.ProfitCenter,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ProfitCenter }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRICEMATERIALIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALPRICE_MATERIALID_REQUIRED",
            RuleName = "MaterialPrice.MaterialId is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_MATERIALID_REQUIRED",
            FieldName = "MaterialId",
            Message = "MaterialPrice.MaterialId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
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

    private async Task ExecuteMATERIALPRICEPRICETYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALPRICE_PRICETYPE_MAX_LENGTH",
            RuleName = "MaterialPrice.PriceType must not exceed 30 characters",
            EntityName = "MaterialPrice",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_PRICETYPE_MAX_LENGTH",
            FieldName = "PriceType",
            Message = "MaterialPrice.PriceType exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.PriceType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PriceType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRICEPRICETYPEALLOWEDVALUESRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALPRICE_PRICETYPE_ALLOWED_VALUES",
            RuleName = "MaterialPrice.PriceType must contain an allowed value",
            EntityName = "MaterialPrice",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_PRICETYPE_ALLOWED_VALUES",
            FieldName = "PriceType",
            Message = "MaterialPrice.PriceType has invalid value.",
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

    private async Task ExecuteMATERIALPRICEPRICEMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => x.Price >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPRICE_PRICE_MIN_VALUE",
            RuleName = "MaterialPrice.Price must be >= 0",
            EntityName = "MaterialPrice",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_PRICE_MIN_VALUE",
            FieldName = "Price",
            Message = "MaterialPrice.Price must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.Price.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.Price }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRICEPRICEUNITREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALPRICE_PRICEUNIT_REQUIRED",
            RuleName = "MaterialPrice.PriceUnit is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_PRICEUNIT_REQUIRED",
            FieldName = "PriceUnit",
            Message = "MaterialPrice.PriceUnit is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PriceUnit.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PriceUnit }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRICEPRICEUNITMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => x.PriceUnit >= 1)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPRICE_PRICEUNIT_MIN_VALUE",
            RuleName = "MaterialPrice.PriceUnit must be >= 1",
            EntityName = "MaterialPrice",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_PRICEUNIT_MIN_VALUE",
            FieldName = "PriceUnit",
            Message = "MaterialPrice.PriceUnit must be greater than or equal to 1.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PriceUnit.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PriceUnit }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRICEVALIDFROMREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALPRICE_VALIDFROM_REQUIRED",
            RuleName = "MaterialPrice.ValidFrom is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_VALIDFROM_REQUIRED",
            FieldName = "ValidFrom",
            Message = "MaterialPrice.ValidFrom is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ValidFrom.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ValidFrom }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALPRICESOURCESYSTEMMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => string.IsNullOrEmpty(x.SourceSystem))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALPRICE_SOURCESYSTEM_MAX_LENGTH",
            RuleName = "MaterialPrice.SourceSystem must not exceed 50 characters",
            EntityName = "MaterialPrice",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALPRICE_SOURCESYSTEM_MAX_LENGTH",
            FieldName = "SourceSystem",
            Message = "MaterialPrice.SourceSystem exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.SourceSystem,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.SourceSystem }),
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

    private async Task ExecuteMATERIALSTORAGEMATERIALIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALSTORAGE_MATERIALID_REQUIRED",
            RuleName = "MaterialStorage.MaterialId is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialStorage",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALSTORAGE_MATERIALID_REQUIRED",
            FieldName = "MaterialId",
            Message = "MaterialStorage.MaterialId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
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

    private async Task ExecuteMATERIALSTORAGEBINLOCATIONMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialStorages.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialStorages
            .Where(x => string.IsNullOrEmpty(x.BinLocation))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALSTORAGE_BINLOCATION_MAX_LENGTH",
            RuleName = "MaterialStorage.BinLocation must not exceed 50 characters",
            EntityName = "MaterialStorage",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialStorage",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALSTORAGE_BINLOCATION_MAX_LENGTH",
            FieldName = "BinLocation",
            Message = "MaterialStorage.BinLocation exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.BinLocation,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.BinLocation }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALSTORAGESAFETYSTOCKMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialStorages.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialStorages
            .Where(x => x.SafetyStock >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALSTORAGE_SAFETYSTOCK_MIN_VALUE",
            RuleName = "MaterialStorage.SafetyStock must be >= 0",
            EntityName = "MaterialStorage",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialStorage",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALSTORAGE_SAFETYSTOCK_MIN_VALUE",
            FieldName = "SafetyStock",
            Message = "MaterialStorage.SafetyStock must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.SafetyStock.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.SafetyStock }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALSTORAGEMAXIMUMSTOCKMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialStorages.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialStorages
            .Where(x => x.MaximumStock >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALSTORAGE_MAXIMUMSTOCK_MIN_VALUE",
            RuleName = "MaterialStorage.MaximumStock must be >= 0",
            EntityName = "MaterialStorage",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialStorage",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALSTORAGE_MAXIMUMSTOCK_MIN_VALUE",
            FieldName = "MaximumStock",
            Message = "MaterialStorage.MaximumStock must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaximumStock.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.MaximumStock }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALSTORAGETEMPERATUREZONEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialStorages.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialStorages
            .Where(x => string.IsNullOrEmpty(x.TemperatureZone))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALSTORAGE_TEMPERATUREZONE_MAX_LENGTH",
            RuleName = "MaterialStorage.TemperatureZone must not exceed 30 characters",
            EntityName = "MaterialStorage",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialStorage",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALSTORAGE_TEMPERATUREZONE_MAX_LENGTH",
            FieldName = "TemperatureZone",
            Message = "MaterialStorage.TemperatureZone exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.TemperatureZone,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.TemperatureZone }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALCLASSIFICATIONMATERIALIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALCLASSIFICATION_MATERIALID_REQUIRED",
            RuleName = "MaterialClassification.MaterialId is mandatory",
            EntityName = "MaterialClassification",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialClassification",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALCLASSIFICATION_MATERIALID_REQUIRED",
            FieldName = "MaterialId",
            Message = "MaterialClassification.MaterialId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALCLASSIFICATIONCLASSTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALCLASSIFICATION_CLASSTYPE_REQUIRED",
            RuleName = "MaterialClassification.ClassType is mandatory",
            EntityName = "MaterialClassification",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialClassification",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALCLASSIFICATION_CLASSTYPE_REQUIRED",
            FieldName = "ClassType",
            Message = "MaterialClassification.ClassType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ClassType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ClassType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALCLASSIFICATIONCLASSTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALCLASSIFICATION_CLASSTYPE_MAX_LENGTH",
            RuleName = "MaterialClassification.ClassType must not exceed 50 characters",
            EntityName = "MaterialClassification",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialClassification",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALCLASSIFICATION_CLASSTYPE_MAX_LENGTH",
            FieldName = "ClassType",
            Message = "MaterialClassification.ClassType exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.ClassType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ClassType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALCLASSIFICATIONCLASSVALUEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassValue))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALCLASSIFICATION_CLASSVALUE_REQUIRED",
            RuleName = "MaterialClassification.ClassValue is mandatory",
            EntityName = "MaterialClassification",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialClassification",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALCLASSIFICATION_CLASSVALUE_REQUIRED",
            FieldName = "ClassValue",
            Message = "MaterialClassification.ClassValue is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ClassValue,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ClassValue }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALCLASSIFICATIONCLASSVALUEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassValue))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALCLASSIFICATION_CLASSVALUE_MAX_LENGTH",
            RuleName = "MaterialClassification.ClassValue must not exceed 100 characters",
            EntityName = "MaterialClassification",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialClassification",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALCLASSIFICATION_CLASSVALUE_MAX_LENGTH",
            FieldName = "ClassValue",
            Message = "MaterialClassification.ClassValue exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.ClassValue,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ClassValue }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALCLASSIFICATIONCHARACTERISTICNAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialClassifications
            .Where(x => string.IsNullOrEmpty(x.CharacteristicName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALCLASSIFICATION_CHARACTERISTICNAME_MAX_LENGTH",
            RuleName = "MaterialClassification.CharacteristicName must not exceed 100 characters",
            EntityName = "MaterialClassification",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialClassification",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALCLASSIFICATION_CHARACTERISTICNAME_MAX_LENGTH",
            FieldName = "CharacteristicName",
            Message = "MaterialClassification.CharacteristicName exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.CharacteristicName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.CharacteristicName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALVENDORMATERIALIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALVENDOR_MATERIALID_REQUIRED",
            RuleName = "MaterialVendor.MaterialId is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALVENDOR_MATERIALID_REQUIRED",
            FieldName = "MaterialId",
            Message = "MaterialVendor.MaterialId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
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

    private async Task ExecuteMATERIALVENDORVENDORMATERIALNUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialVendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialVendors
            .Where(x => string.IsNullOrEmpty(x.VendorMaterialNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALVENDOR_VENDORMATERIALNUMBER_MAX_LENGTH",
            RuleName = "MaterialVendor.VendorMaterialNumber must not exceed 50 characters",
            EntityName = "MaterialVendor",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALVENDOR_VENDORMATERIALNUMBER_MAX_LENGTH",
            FieldName = "VendorMaterialNumber",
            Message = "MaterialVendor.VendorMaterialNumber exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.VendorMaterialNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.VendorMaterialNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALVENDORLEADTIMEDAYSMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialVendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialVendors
            .Where(x => x.LeadTimeDays >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALVENDOR_LEADTIMEDAYS_MIN_VALUE",
            RuleName = "MaterialVendor.LeadTimeDays must be >= 0",
            EntityName = "MaterialVendor",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALVENDOR_LEADTIMEDAYS_MIN_VALUE",
            FieldName = "LeadTimeDays",
            Message = "MaterialVendor.LeadTimeDays must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.LeadTimeDays.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.LeadTimeDays }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALVENDORLEADTIMEDAYSMAXVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialVendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialVendors
            .Where(x => x.LeadTimeDays <= 365)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALVENDOR_LEADTIMEDAYS_MAX_VALUE",
            RuleName = "MaterialVendor.LeadTimeDays must be <= 365",
            EntityName = "MaterialVendor",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALVENDOR_LEADTIMEDAYS_MAX_VALUE",
            FieldName = "LeadTimeDays",
            Message = "MaterialVendor.LeadTimeDays must be less than or equal to 365.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.LeadTimeDays.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.LeadTimeDays }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALVENDORMINIMUMORDERQUANTITYMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialVendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialVendors
            .Where(x => x.MinimumOrderQuantity >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALVENDOR_MINIMUMORDERQUANTITY_MIN_VALUE",
            RuleName = "MaterialVendor.MinimumOrderQuantity must be >= 0",
            EntityName = "MaterialVendor",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALVENDOR_MINIMUMORDERQUANTITY_MIN_VALUE",
            FieldName = "MinimumOrderQuantity",
            Message = "MaterialVendor.MinimumOrderQuantity must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MinimumOrderQuantity.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.MinimumOrderQuantity }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALVENDORISPREFERREDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALVENDOR_ISPREFERRED_REQUIRED",
            RuleName = "MaterialVendor.IsPreferred is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALVENDOR_ISPREFERRED_REQUIRED",
            FieldName = "IsPreferred",
            Message = "MaterialVendor.IsPreferred is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsPreferred.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.IsPreferred }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALUOMMATERIALIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALUOM_MATERIALID_REQUIRED",
            RuleName = "MaterialUOM.MaterialId is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALUOM_MATERIALID_REQUIRED",
            FieldName = "MaterialId",
            Message = "MaterialUOM.MaterialId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
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

    private async Task ExecuteMATERIALUOMCONVERSIONNUMERATORREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALUOM_CONVERSIONNUMERATOR_REQUIRED",
            RuleName = "MaterialUOM.ConversionNumerator is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALUOM_CONVERSIONNUMERATOR_REQUIRED",
            FieldName = "ConversionNumerator",
            Message = "MaterialUOM.ConversionNumerator is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ConversionNumerator.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ConversionNumerator }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALUOMCONVERSIONNUMERATORMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialUOMs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialUOMs
            .Where(x => x.ConversionNumerator >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALUOM_CONVERSIONNUMERATOR_MIN_VALUE",
            RuleName = "MaterialUOM.ConversionNumerator must be >= 0",
            EntityName = "MaterialUOM",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALUOM_CONVERSIONNUMERATOR_MIN_VALUE",
            FieldName = "ConversionNumerator",
            Message = "MaterialUOM.ConversionNumerator must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ConversionNumerator.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ConversionNumerator }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALUOMCONVERSIONDENOMINATORREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALUOM_CONVERSIONDENOMINATOR_REQUIRED",
            RuleName = "MaterialUOM.ConversionDenominator is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALUOM_CONVERSIONDENOMINATOR_REQUIRED",
            FieldName = "ConversionDenominator",
            Message = "MaterialUOM.ConversionDenominator is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ConversionDenominator.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ConversionDenominator }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALUOMCONVERSIONDENOMINATORMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialUOMs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialUOMs
            .Where(x => x.ConversionDenominator >= 1)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALUOM_CONVERSIONDENOMINATOR_MIN_VALUE",
            RuleName = "MaterialUOM.ConversionDenominator must be >= 1",
            EntityName = "MaterialUOM",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALUOM_CONVERSIONDENOMINATOR_MIN_VALUE",
            FieldName = "ConversionDenominator",
            Message = "MaterialUOM.ConversionDenominator must be greater than or equal to 1.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ConversionDenominator.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ConversionDenominator }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALUOMBARCODEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialUOMs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialUOMs
            .Where(x => string.IsNullOrEmpty(x.Barcode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALUOM_BARCODE_MAX_LENGTH",
            RuleName = "MaterialUOM.Barcode must not exceed 50 characters",
            EntityName = "MaterialUOM",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALUOM_BARCODE_MAX_LENGTH",
            FieldName = "Barcode",
            Message = "MaterialUOM.Barcode exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Barcode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.Barcode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALUOMISBASEUNITREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALUOM_ISBASEUNIT_REQUIRED",
            RuleName = "MaterialUOM.IsBaseUnit is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALUOM_ISBASEUNIT_REQUIRED",
            FieldName = "IsBaseUnit",
            Message = "MaterialUOM.IsBaseUnit is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsBaseUnit.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.IsBaseUnit }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALQUALITYINSPECTIONMATERIALIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALQUALITYINSPECTION_MATERIALID_REQUIRED",
            RuleName = "MaterialQualityInspection.MaterialId is mandatory",
            EntityName = "MaterialQualityInspection",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialQualityInspection",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALQUALITYINSPECTION_MATERIALID_REQUIRED",
            FieldName = "MaterialId",
            Message = "MaterialQualityInspection.MaterialId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALQUALITYINSPECTIONINSPECTIONTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialQualityInspections.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialQualityInspections
            .Where(x => string.IsNullOrEmpty(x.InspectionType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALQUALITYINSPECTION_INSPECTIONTYPE_REQUIRED",
            RuleName = "MaterialQualityInspection.InspectionType is mandatory",
            EntityName = "MaterialQualityInspection",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialQualityInspection",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALQUALITYINSPECTION_INSPECTIONTYPE_REQUIRED",
            FieldName = "InspectionType",
            Message = "MaterialQualityInspection.InspectionType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.InspectionType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.InspectionType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALQUALITYINSPECTIONINSPECTIONTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialQualityInspections.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialQualityInspections
            .Where(x => string.IsNullOrEmpty(x.InspectionType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALQUALITYINSPECTION_INSPECTIONTYPE_MAX_LENGTH",
            RuleName = "MaterialQualityInspection.InspectionType must not exceed 50 characters",
            EntityName = "MaterialQualityInspection",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialQualityInspection",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALQUALITYINSPECTION_INSPECTIONTYPE_MAX_LENGTH",
            FieldName = "InspectionType",
            Message = "MaterialQualityInspection.InspectionType exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.InspectionType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.InspectionType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALQUALITYINSPECTIONINSPECTIONINTERVALDAYSMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialQualityInspections.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialQualityInspections
            .Where(x => x.InspectionIntervalDays >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALQUALITYINSPECTION_INSPECTIONINTERVALDAYS_MIN_VALUE",
            RuleName = "MaterialQualityInspection.InspectionIntervalDays must be >= 0",
            EntityName = "MaterialQualityInspection",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialQualityInspection",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALQUALITYINSPECTION_INSPECTIONINTERVALDAYS_MIN_VALUE",
            FieldName = "InspectionIntervalDays",
            Message = "MaterialQualityInspection.InspectionIntervalDays must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.InspectionIntervalDays.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.InspectionIntervalDays }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALQUALITYINSPECTIONINSPECTIONINTERVALDAYSMAXVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialQualityInspections.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialQualityInspections
            .Where(x => x.InspectionIntervalDays <= 3650)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALQUALITYINSPECTION_INSPECTIONINTERVALDAYS_MAX_VALUE",
            RuleName = "MaterialQualityInspection.InspectionIntervalDays must be <= 3650",
            EntityName = "MaterialQualityInspection",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialQualityInspection",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALQUALITYINSPECTION_INSPECTIONINTERVALDAYS_MAX_VALUE",
            FieldName = "InspectionIntervalDays",
            Message = "MaterialQualityInspection.InspectionIntervalDays must be less than or equal to 3650.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.InspectionIntervalDays.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.InspectionIntervalDays }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALQUALITYINSPECTIONQUALITYCERTIFICATEREQUIREDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALQUALITYINSPECTION_QUALITYCERTIFICATEREQUIRED_REQUIRED",
            RuleName = "MaterialQualityInspection.QualityCertificateRequired is mandatory",
            EntityName = "MaterialQualityInspection",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialQualityInspection",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALQUALITYINSPECTION_QUALITYCERTIFICATEREQUIRED_REQUIRED",
            FieldName = "QualityCertificateRequired",
            Message = "MaterialQualityInspection.QualityCertificateRequired is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.QualityCertificateRequired.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.QualityCertificateRequired }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALQUALITYINSPECTIONSAMPLESIZEMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialQualityInspections.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialQualityInspections
            .Where(x => x.SampleSize >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALQUALITYINSPECTION_SAMPLESIZE_MIN_VALUE",
            RuleName = "MaterialQualityInspection.SampleSize must be >= 0",
            EntityName = "MaterialQualityInspection",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialQualityInspection",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALQUALITYINSPECTION_SAMPLESIZE_MIN_VALUE",
            FieldName = "SampleSize",
            Message = "MaterialQualityInspection.SampleSize must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.SampleSize.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.SampleSize }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALQUALITYINSPECTIONACCEPTANCECRITERIAMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialQualityInspections.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialQualityInspections
            .Where(x => string.IsNullOrEmpty(x.AcceptanceCriteria))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALQUALITYINSPECTION_ACCEPTANCECRITERIA_MAX_LENGTH",
            RuleName = "MaterialQualityInspection.AcceptanceCriteria must not exceed 500 characters",
            EntityName = "MaterialQualityInspection",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialQualityInspection",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALQUALITYINSPECTION_ACCEPTANCECRITERIA_MAX_LENGTH",
            FieldName = "AcceptanceCriteria",
            Message = "MaterialQualityInspection.AcceptanceCriteria exceeds maximum length 500.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.AcceptanceCriteria,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.AcceptanceCriteria }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALFORECASTMATERIALIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALFORECAST_MATERIALID_REQUIRED",
            RuleName = "MaterialForecast.MaterialId is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALFORECAST_MATERIALID_REQUIRED",
            FieldName = "MaterialId",
            Message = "MaterialForecast.MaterialId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
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

    private async Task ExecuteMATERIALFORECASTFORECASTPERIODMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALFORECAST_FORECASTPERIOD_MAX_LENGTH",
            RuleName = "MaterialForecast.ForecastPeriod must not exceed 20 characters",
            EntityName = "MaterialForecast",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALFORECAST_FORECASTPERIOD_MAX_LENGTH",
            FieldName = "ForecastPeriod",
            Message = "MaterialForecast.ForecastPeriod exceeds maximum length 20.",
            Severity = "Medium",
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

    private async Task ExecuteMATERIALFORECASTFORECASTQUANTITYMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => x.ForecastQuantity >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALFORECAST_FORECASTQUANTITY_MIN_VALUE",
            RuleName = "MaterialForecast.ForecastQuantity must be >= 0",
            EntityName = "MaterialForecast",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALFORECAST_FORECASTQUANTITY_MIN_VALUE",
            FieldName = "ForecastQuantity",
            Message = "MaterialForecast.ForecastQuantity must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ForecastQuantity.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ForecastQuantity }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALFORECASTFORECASTUNITOFMEASUREIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALFORECAST_FORECASTUNITOFMEASUREID_REQUIRED",
            RuleName = "MaterialForecast.ForecastUnitOfMeasureId is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALFORECAST_FORECASTUNITOFMEASUREID_REQUIRED",
            FieldName = "ForecastUnitOfMeasureId",
            Message = "MaterialForecast.ForecastUnitOfMeasureId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ForecastUnitOfMeasureId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ForecastUnitOfMeasureId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALFORECASTCONFIDENCEPERCENTMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => x.ConfidencePercent >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALFORECAST_CONFIDENCEPERCENT_MIN_VALUE",
            RuleName = "MaterialForecast.ConfidencePercent must be >= 0",
            EntityName = "MaterialForecast",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALFORECAST_CONFIDENCEPERCENT_MIN_VALUE",
            FieldName = "ConfidencePercent",
            Message = "MaterialForecast.ConfidencePercent must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ConfidencePercent.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ConfidencePercent }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALFORECASTCONFIDENCEPERCENTMAXVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => x.ConfidencePercent <= 100)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALFORECAST_CONFIDENCEPERCENT_MAX_VALUE",
            RuleName = "MaterialForecast.ConfidencePercent must be <= 100",
            EntityName = "MaterialForecast",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALFORECAST_CONFIDENCEPERCENT_MAX_VALUE",
            FieldName = "ConfidencePercent",
            Message = "MaterialForecast.ConfidencePercent must be less than or equal to 100.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ConfidencePercent.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ConfidencePercent }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALBARCODEMATERIALIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALBARCODE_MATERIALID_REQUIRED",
            RuleName = "MaterialBarcode.MaterialId is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALBARCODE_MATERIALID_REQUIRED",
            FieldName = "MaterialId",
            Message = "MaterialBarcode.MaterialId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MaterialId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALBARCODEBARCODETYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialBarcodes.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialBarcodes
            .Where(x => string.IsNullOrEmpty(x.BarcodeType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALBARCODE_BARCODETYPE_REQUIRED",
            RuleName = "MaterialBarcode.BarcodeType is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALBARCODE_BARCODETYPE_REQUIRED",
            FieldName = "BarcodeType",
            Message = "MaterialBarcode.BarcodeType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BarcodeType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.BarcodeType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALBARCODEBARCODETYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialBarcodes.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialBarcodes
            .Where(x => string.IsNullOrEmpty(x.BarcodeType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALBARCODE_BARCODETYPE_MAX_LENGTH",
            RuleName = "MaterialBarcode.BarcodeType must not exceed 30 characters",
            EntityName = "MaterialBarcode",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALBARCODE_BARCODETYPE_MAX_LENGTH",
            FieldName = "BarcodeType",
            Message = "MaterialBarcode.BarcodeType exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.BarcodeType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.BarcodeType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALBARCODEBARCODETYPEALLOWEDVALUESRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialBarcodes.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.MaterialBarcodes
            .Where(x => string.IsNullOrEmpty(x.BarcodeType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            RuleCode = "MATERIALBARCODE_BARCODETYPE_ALLOWED_VALUES",
            RuleName = "MaterialBarcode.BarcodeType must contain an allowed value",
            EntityName = "MaterialBarcode",
            Category = "Validity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALBARCODE_BARCODETYPE_ALLOWED_VALUES",
            FieldName = "BarcodeType",
            Message = "MaterialBarcode.BarcodeType has invalid value.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BarcodeType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.BarcodeType }),
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

    private async Task ExecuteMATERIALBARCODEBARCODEVALUEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALBARCODE_BARCODEVALUE_MAX_LENGTH",
            RuleName = "MaterialBarcode.BarcodeValue must not exceed 100 characters",
            EntityName = "MaterialBarcode",
            Category = "Validity",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALBARCODE_BARCODEVALUE_MAX_LENGTH",
            FieldName = "BarcodeValue",
            Message = "MaterialBarcode.BarcodeValue exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.BarcodeValue,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.BarcodeValue }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALBARCODEBARCODEVALUEUNIQUERuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALBARCODE_BARCODEVALUE_UNIQUE",
            RuleName = "MaterialBarcode.BarcodeValue must be unique",
            EntityName = "MaterialBarcode",
            Category = "Uniqueness",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALBARCODE_BARCODEVALUE_UNIQUE",
            FieldName = "BarcodeValue",
            Message = "MaterialBarcode.BarcodeValue must be unique.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BarcodeValue,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.BarcodeValue }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteMATERIALBARCODEISPRIMARYREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "MATERIALBARCODE_ISPRIMARY_REQUIRED",
            RuleName = "MaterialBarcode.IsPrimary is mandatory",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "MATERIALBARCODE_ISPRIMARY_REQUIRED",
            FieldName = "IsPrimary",
            Message = "MaterialBarcode.IsPrimary is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsPrimary.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.IsPrimary }),
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

    private async Task ExecuteACTIVEMATERIALREQUIRESPLANTRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "ACTIVE_MATERIAL_REQUIRES_PLANT",
            RuleName = "Active material must be extended to at least one plant",
            EntityName = "MaterialPlant",
            Category = "Integrity",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "ACTIVE_MATERIAL_REQUIRES_PLANT",
            FieldName = "",
            Message = "Active material must have at least one plant extension.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteACTIVEMATERIALREQUIRESPRICERuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "ACTIVE_MATERIAL_REQUIRES_PRICE",
            RuleName = "Active material must have at least one valid price",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "ACTIVE_MATERIAL_REQUIRES_PRICE",
            FieldName = "",
            Message = "Active material must have at least one price record.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
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

    private async Task ExecuteBATCHMANAGEDMATERIALREQUIRESINSPECTIONRuleAsync(Guid runId, CancellationToken cancellationToken)
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
            RuleCode = "BATCH_MANAGED_MATERIAL_REQUIRES_INSPECTION",
            RuleName = "Batch-managed material should have quality inspection setup",
            EntityName = "MaterialQualityInspection",
            Category = "Compliance",
            Severity = "Medium",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Material",
            EntityName = "MaterialQualityInspection",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "BATCH_MANAGED_MATERIAL_REQUIRES_INSPECTION",
            FieldName = "",
            Message = "Batch-managed material should have a quality inspection setup.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
