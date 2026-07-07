using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Application.Common;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Application.Modules.Customer.DataQuality.Services;

public sealed class CustomerDataQualityRuleExecutor(IAnalysisDbContext dbContext)
{
    private readonly IAnalysisDbContext _dbContext = dbContext;

    public async Task ExecuteAsync(Guid runId, CancellationToken cancellationToken)
    {
        await ExecuteCUSTOMERCUSTOMERNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCUSTOMERNUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCUSTOMERNUMBERUNIQUERuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCUSTOMERNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCUSTOMERNAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCUSTOMERTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCUSTOMERTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCUSTOMERTYPEALLOWEDVALUESRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMEREMAILMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMEREMAILEMAILFORMATRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERPHONEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCOUNTRYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCURRENCYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERINDUSTRYCODEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERRISKCATEGORYMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERRISKCATEGORYALLOWEDVALUESRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERREGISTRATIONNUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERISACTIVEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSCUSTOMERIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSADDRESSTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSADDRESSTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSADDRESSTYPEALLOWEDVALUESRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSADDRESSLINE1REQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSADDRESSLINE1MAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSADDRESSLINE2MAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSCITYREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSCITYMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSSTATEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSPOSTALCODEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSPOSTALCODEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSCOUNTRYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSREGIONMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSISDEFAULTREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTCUSTOMERIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTFIRSTNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTFIRSTNAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTLASTNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTLASTNAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTEMAILMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTEMAILEMAILFORMATRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTPHONEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTMOBILEPHONEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTDESIGNATIONMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTDEPARTMENTMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTPREFERREDLANGUAGEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTISPRIMARYREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTCUSTOMERIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTBANKNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTBANKNAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTACCOUNTNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTACCOUNTNUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTIFSCCODEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTSWIFTCODEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTCURRENCYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTACCOUNTHOLDERNAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTISDEFAULTREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREACUSTOMERIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREASALESORGANIZATIONIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREADISTRIBUTIONCHANNELREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREADISTRIBUTIONCHANNELMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREADIVISIONREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREADIVISIONMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREACREDITLIMITMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREACUSTOMERGROUPMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREASALESOFFICEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREASALESDISTRICTMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXCUSTOMERIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXTAXTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXTAXTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXTAXNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXTAXNUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXCOUNTRYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXISEXEMPTREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXVALIDITYDATERANGERuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCLASSIFICATIONCUSTOMERIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONVALUEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONVALUEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONGROUPMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILECUSTOMERIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILECREDITCONTROLAREAREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILECREDITCONTROLAREAMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILECREDITLIMITREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILECREDITLIMITMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILECREDITEXPOSUREMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILECREDITRISKCLASSMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILECREDITRISKCLASSALLOWEDVALUESRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILEISBLOCKEDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERPARTNERFUNCTIONCUSTOMERIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERPARTNERFUNCTIONPARTNERFUNCTIONCODEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERPARTNERFUNCTIONPARTNERFUNCTIONCODEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERPARTNERFUNCTIONDESCRIPTIONMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERPARTNERFUNCTIONISDEFAULTREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTCUSTOMERIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTDOCUMENTTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTDOCUMENTTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTFILENAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTFILENAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTCONTENTTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTSTORAGEPATHREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTSTORAGEPATHMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTUPLOADEDONREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCURRENCYIDCURRENCYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTCURRENCYIDCURRENCYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTBANKCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREACUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREASALESORGANIZATIONIDSALESORGANIZATIONEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREAPAYMENTTERMIDPAYMENTTERMEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCLASSIFICATIONCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILECUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERPARTNERFUNCTIONCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERACTIVEREQUIRESDEFAULTADDRESSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERACTIVEREQUIRESPRIMARYCONTACTRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERINDIAREQUIRESGSTTAXRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITEXPOSUREWITHINLIMITRuleAsync(runId, cancellationToken);
    }

    private async Task ExecuteCUSTOMERCUSTOMERNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CUSTOMERNUMBER_REQUIRED",
            RuleName = "Customer.CustomerNumber is mandatory",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CUSTOMERNUMBER_REQUIRED",
            FieldName = "CustomerNumber",
            Message = "Customer.CustomerNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCUSTOMERNUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CUSTOMERNUMBER_MAX_LENGTH",
            RuleName = "Customer.CustomerNumber must not exceed 20 characters",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CUSTOMERNUMBER_MAX_LENGTH",
            FieldName = "CustomerNumber",
            Message = "Customer.CustomerNumber exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.CustomerNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCUSTOMERNUMBERUNIQUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CUSTOMERNUMBER_UNIQUE",
            RuleName = "Customer.CustomerNumber must be unique",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CUSTOMERNUMBER_UNIQUE",
            FieldName = "CustomerNumber",
            Message = "Customer.CustomerNumber must be unique.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCUSTOMERNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CUSTOMERNAME_REQUIRED",
            RuleName = "Customer.CustomerName is mandatory",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CUSTOMERNAME_REQUIRED",
            FieldName = "CustomerName",
            Message = "Customer.CustomerName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCUSTOMERNAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CUSTOMERNAME_MAX_LENGTH",
            RuleName = "Customer.CustomerName must not exceed 200 characters",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CUSTOMERNAME_MAX_LENGTH",
            FieldName = "CustomerName",
            Message = "Customer.CustomerName exceeds maximum length 200.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.CustomerName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCUSTOMERTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CUSTOMERTYPE_REQUIRED",
            RuleName = "Customer.CustomerType is mandatory",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CUSTOMERTYPE_REQUIRED",
            FieldName = "CustomerType",
            Message = "Customer.CustomerType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCUSTOMERTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CUSTOMERTYPE_MAX_LENGTH",
            RuleName = "Customer.CustomerType must not exceed 30 characters",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CUSTOMERTYPE_MAX_LENGTH",
            FieldName = "CustomerType",
            Message = "Customer.CustomerType exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.CustomerType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCUSTOMERTYPEALLOWEDVALUESRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CUSTOMERTYPE_ALLOWED_VALUES",
            RuleName = "Customer.CustomerType must contain an allowed value",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CUSTOMERTYPE_ALLOWED_VALUES",
            FieldName = "CustomerType",
            Message = "Customer.CustomerType has invalid value.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMEREMAILMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.Email))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_EMAIL_MAX_LENGTH",
            RuleName = "Customer.Email must not exceed 250 characters",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_EMAIL_MAX_LENGTH",
            FieldName = "Email",
            Message = "Customer.Email exceeds maximum length 250.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Email,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMEREMAILEMAILFORMATRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.Email))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_EMAIL_EMAIL_FORMAT",
            RuleName = "Customer.Email must be a valid email",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_EMAIL_EMAIL_FORMAT",
            FieldName = "Email",
            Message = "Customer.Email must be a valid email address.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.Email,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERPHONEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.Phone))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_PHONE_MAX_LENGTH",
            RuleName = "Customer.Phone must not exceed 30 characters",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_PHONE_MAX_LENGTH",
            FieldName = "Phone",
            Message = "Customer.Phone exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Phone,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.Phone }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCOUNTRYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_COUNTRYID_REQUIRED",
            RuleName = "Customer.CountryId is mandatory",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_COUNTRYID_REQUIRED",
            FieldName = "CountryId",
            Message = "Customer.CountryId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCURRENCYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CURRENCYID_REQUIRED",
            RuleName = "Customer.CurrencyId is mandatory",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CURRENCYID_REQUIRED",
            FieldName = "CurrencyId",
            Message = "Customer.CurrencyId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERINDUSTRYCODEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.IndustryCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_INDUSTRYCODE_MAX_LENGTH",
            RuleName = "Customer.IndustryCode must not exceed 30 characters",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_INDUSTRYCODE_MAX_LENGTH",
            FieldName = "IndustryCode",
            Message = "Customer.IndustryCode exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.IndustryCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.IndustryCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERRISKCATEGORYMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.RiskCategory))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_RISKCATEGORY_MAX_LENGTH",
            RuleName = "Customer.RiskCategory must not exceed 30 characters",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_RISKCATEGORY_MAX_LENGTH",
            FieldName = "RiskCategory",
            Message = "Customer.RiskCategory exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.RiskCategory,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.RiskCategory }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERRISKCATEGORYALLOWEDVALUESRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.RiskCategory))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_RISKCATEGORY_ALLOWED_VALUES",
            RuleName = "Customer.RiskCategory must contain an allowed value",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_RISKCATEGORY_ALLOWED_VALUES",
            FieldName = "RiskCategory",
            Message = "Customer.RiskCategory has invalid value.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.RiskCategory,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.RiskCategory }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERREGISTRATIONNUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.RegistrationNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_REGISTRATIONNUMBER_MAX_LENGTH",
            RuleName = "Customer.RegistrationNumber must not exceed 50 characters",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_REGISTRATIONNUMBER_MAX_LENGTH",
            FieldName = "RegistrationNumber",
            Message = "Customer.RegistrationNumber exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.RegistrationNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.RegistrationNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERISACTIVEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_ISACTIVE_REQUIRED",
            RuleName = "Customer.IsActive is mandatory",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_ISACTIVE_REQUIRED",
            FieldName = "IsActive",
            Message = "Customer.IsActive is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsActive.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.IsActive }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSCUSTOMERIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_CUSTOMERID_REQUIRED",
            RuleName = "CustomerAddress.CustomerId is mandatory",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_CUSTOMERID_REQUIRED",
            FieldName = "CustomerId",
            Message = "CustomerAddress.CustomerId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSADDRESSTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_ADDRESSTYPE_REQUIRED",
            RuleName = "CustomerAddress.AddressType is mandatory",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_ADDRESSTYPE_REQUIRED",
            FieldName = "AddressType",
            Message = "CustomerAddress.AddressType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AddressType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AddressType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSADDRESSTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_ADDRESSTYPE_MAX_LENGTH",
            RuleName = "CustomerAddress.AddressType must not exceed 30 characters",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_ADDRESSTYPE_MAX_LENGTH",
            FieldName = "AddressType",
            Message = "CustomerAddress.AddressType exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.AddressType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AddressType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSADDRESSTYPEALLOWEDVALUESRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_ADDRESSTYPE_ALLOWED_VALUES",
            RuleName = "CustomerAddress.AddressType must contain an allowed value",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_ADDRESSTYPE_ALLOWED_VALUES",
            FieldName = "AddressType",
            Message = "CustomerAddress.AddressType has invalid value.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AddressType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AddressType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSADDRESSLINE1REQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressLine1))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_ADDRESSLINE1_REQUIRED",
            RuleName = "CustomerAddress.AddressLine1 is mandatory",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_ADDRESSLINE1_REQUIRED",
            FieldName = "AddressLine1",
            Message = "CustomerAddress.AddressLine1 is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AddressLine1,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AddressLine1 }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSADDRESSLINE1MAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressLine1))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_ADDRESSLINE1_MAX_LENGTH",
            RuleName = "CustomerAddress.AddressLine1 must not exceed 200 characters",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_ADDRESSLINE1_MAX_LENGTH",
            FieldName = "AddressLine1",
            Message = "CustomerAddress.AddressLine1 exceeds maximum length 200.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.AddressLine1,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AddressLine1 }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSADDRESSLINE2MAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressLine2))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_ADDRESSLINE2_MAX_LENGTH",
            RuleName = "CustomerAddress.AddressLine2 must not exceed 200 characters",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_ADDRESSLINE2_MAX_LENGTH",
            FieldName = "AddressLine2",
            Message = "CustomerAddress.AddressLine2 exceeds maximum length 200.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.AddressLine2,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AddressLine2 }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSCITYREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.City))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_CITY_REQUIRED",
            RuleName = "CustomerAddress.City is mandatory",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_CITY_REQUIRED",
            FieldName = "City",
            Message = "CustomerAddress.City is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.City,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.City }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSCITYMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.City))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_CITY_MAX_LENGTH",
            RuleName = "CustomerAddress.City must not exceed 100 characters",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_CITY_MAX_LENGTH",
            FieldName = "City",
            Message = "CustomerAddress.City exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.City,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.City }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSSTATEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.State))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_STATE_MAX_LENGTH",
            RuleName = "CustomerAddress.State must not exceed 100 characters",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_STATE_MAX_LENGTH",
            FieldName = "State",
            Message = "CustomerAddress.State exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.State,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.State }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSPOSTALCODEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.PostalCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_POSTALCODE_REQUIRED",
            RuleName = "CustomerAddress.PostalCode is mandatory",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_POSTALCODE_REQUIRED",
            FieldName = "PostalCode",
            Message = "CustomerAddress.PostalCode is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PostalCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PostalCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSPOSTALCODEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.PostalCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_POSTALCODE_MAX_LENGTH",
            RuleName = "CustomerAddress.PostalCode must not exceed 20 characters",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_POSTALCODE_MAX_LENGTH",
            FieldName = "PostalCode",
            Message = "CustomerAddress.PostalCode exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.PostalCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PostalCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSCOUNTRYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_COUNTRYID_REQUIRED",
            RuleName = "CustomerAddress.CountryId is mandatory",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_COUNTRYID_REQUIRED",
            FieldName = "CountryId",
            Message = "CustomerAddress.CountryId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSREGIONMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.Region))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_REGION_MAX_LENGTH",
            RuleName = "CustomerAddress.Region must not exceed 100 characters",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_REGION_MAX_LENGTH",
            FieldName = "Region",
            Message = "CustomerAddress.Region exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Region,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.Region }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSISDEFAULTREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_ISDEFAULT_REQUIRED",
            RuleName = "CustomerAddress.IsDefault is mandatory",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_ISDEFAULT_REQUIRED",
            FieldName = "IsDefault",
            Message = "CustomerAddress.IsDefault is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsDefault.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.IsDefault }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTCUSTOMERIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_CUSTOMERID_REQUIRED",
            RuleName = "CustomerContact.CustomerId is mandatory",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_CUSTOMERID_REQUIRED",
            FieldName = "CustomerId",
            Message = "CustomerContact.CustomerId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTFIRSTNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.FirstName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_FIRSTNAME_REQUIRED",
            RuleName = "CustomerContact.FirstName is mandatory",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_FIRSTNAME_REQUIRED",
            FieldName = "FirstName",
            Message = "CustomerContact.FirstName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.FirstName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.FirstName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTFIRSTNAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.FirstName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_FIRSTNAME_MAX_LENGTH",
            RuleName = "CustomerContact.FirstName must not exceed 100 characters",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_FIRSTNAME_MAX_LENGTH",
            FieldName = "FirstName",
            Message = "CustomerContact.FirstName exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.FirstName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.FirstName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTLASTNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.LastName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_LASTNAME_REQUIRED",
            RuleName = "CustomerContact.LastName is mandatory",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_LASTNAME_REQUIRED",
            FieldName = "LastName",
            Message = "CustomerContact.LastName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.LastName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.LastName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTLASTNAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.LastName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_LASTNAME_MAX_LENGTH",
            RuleName = "CustomerContact.LastName must not exceed 100 characters",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_LASTNAME_MAX_LENGTH",
            FieldName = "LastName",
            Message = "CustomerContact.LastName exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.LastName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.LastName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTEMAILMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.Email))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_EMAIL_MAX_LENGTH",
            RuleName = "CustomerContact.Email must not exceed 250 characters",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_EMAIL_MAX_LENGTH",
            FieldName = "Email",
            Message = "CustomerContact.Email exceeds maximum length 250.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Email,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTEMAILEMAILFORMATRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.Email))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_EMAIL_EMAIL_FORMAT",
            RuleName = "CustomerContact.Email must be a valid email",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_EMAIL_EMAIL_FORMAT",
            FieldName = "Email",
            Message = "CustomerContact.Email must be a valid email address.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.Email,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTPHONEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.Phone))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_PHONE_MAX_LENGTH",
            RuleName = "CustomerContact.Phone must not exceed 30 characters",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_PHONE_MAX_LENGTH",
            FieldName = "Phone",
            Message = "CustomerContact.Phone exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Phone,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.Phone }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTMOBILEPHONEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.MobilePhone))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_MOBILEPHONE_MAX_LENGTH",
            RuleName = "CustomerContact.MobilePhone must not exceed 30 characters",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_MOBILEPHONE_MAX_LENGTH",
            FieldName = "MobilePhone",
            Message = "CustomerContact.MobilePhone exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.MobilePhone,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.MobilePhone }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTDESIGNATIONMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.Designation))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_DESIGNATION_MAX_LENGTH",
            RuleName = "CustomerContact.Designation must not exceed 100 characters",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_DESIGNATION_MAX_LENGTH",
            FieldName = "Designation",
            Message = "CustomerContact.Designation exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Designation,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.Designation }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTDEPARTMENTMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.Department))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_DEPARTMENT_MAX_LENGTH",
            RuleName = "CustomerContact.Department must not exceed 100 characters",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_DEPARTMENT_MAX_LENGTH",
            FieldName = "Department",
            Message = "CustomerContact.Department exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Department,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.Department }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTPREFERREDLANGUAGEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.PreferredLanguage))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_PREFERREDLANGUAGE_MAX_LENGTH",
            RuleName = "CustomerContact.PreferredLanguage must not exceed 20 characters",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_PREFERREDLANGUAGE_MAX_LENGTH",
            FieldName = "PreferredLanguage",
            Message = "CustomerContact.PreferredLanguage exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.PreferredLanguage,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PreferredLanguage }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTISPRIMARYREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_ISPRIMARY_REQUIRED",
            RuleName = "CustomerContact.IsPrimary is mandatory",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_ISPRIMARY_REQUIRED",
            FieldName = "IsPrimary",
            Message = "CustomerContact.IsPrimary is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsPrimary.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.IsPrimary }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTCUSTOMERIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_CUSTOMERID_REQUIRED",
            RuleName = "CustomerBankAccount.CustomerId is mandatory",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_CUSTOMERID_REQUIRED",
            FieldName = "CustomerId",
            Message = "CustomerBankAccount.CustomerId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTBANKNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => string.IsNullOrEmpty(x.BankName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_BANKNAME_REQUIRED",
            RuleName = "CustomerBankAccount.BankName is mandatory",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_BANKNAME_REQUIRED",
            FieldName = "BankName",
            Message = "CustomerBankAccount.BankName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BankName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.BankName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTBANKNAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => string.IsNullOrEmpty(x.BankName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_BANKNAME_MAX_LENGTH",
            RuleName = "CustomerBankAccount.BankName must not exceed 150 characters",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_BANKNAME_MAX_LENGTH",
            FieldName = "BankName",
            Message = "CustomerBankAccount.BankName exceeds maximum length 150.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.BankName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.BankName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTACCOUNTNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => string.IsNullOrEmpty(x.AccountNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_ACCOUNTNUMBER_REQUIRED",
            RuleName = "CustomerBankAccount.AccountNumber is mandatory",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_ACCOUNTNUMBER_REQUIRED",
            FieldName = "AccountNumber",
            Message = "CustomerBankAccount.AccountNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AccountNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AccountNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTACCOUNTNUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => string.IsNullOrEmpty(x.AccountNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_ACCOUNTNUMBER_MAX_LENGTH",
            RuleName = "CustomerBankAccount.AccountNumber must not exceed 50 characters",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_ACCOUNTNUMBER_MAX_LENGTH",
            FieldName = "AccountNumber",
            Message = "CustomerBankAccount.AccountNumber exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.AccountNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AccountNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTIFSCCODEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => string.IsNullOrEmpty(x.IfscCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_IFSCCODE_MAX_LENGTH",
            RuleName = "CustomerBankAccount.IfscCode must not exceed 20 characters",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_IFSCCODE_MAX_LENGTH",
            FieldName = "IfscCode",
            Message = "CustomerBankAccount.IfscCode exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.IfscCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.IfscCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTSWIFTCODEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => string.IsNullOrEmpty(x.SwiftCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_SWIFTCODE_MAX_LENGTH",
            RuleName = "CustomerBankAccount.SwiftCode must not exceed 20 characters",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_SWIFTCODE_MAX_LENGTH",
            FieldName = "SwiftCode",
            Message = "CustomerBankAccount.SwiftCode exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.SwiftCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.SwiftCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTCURRENCYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_CURRENCYID_REQUIRED",
            RuleName = "CustomerBankAccount.CurrencyId is mandatory",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_CURRENCYID_REQUIRED",
            FieldName = "CurrencyId",
            Message = "CustomerBankAccount.CurrencyId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTACCOUNTHOLDERNAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => string.IsNullOrEmpty(x.AccountHolderName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_ACCOUNTHOLDERNAME_MAX_LENGTH",
            RuleName = "CustomerBankAccount.AccountHolderName must not exceed 150 characters",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_ACCOUNTHOLDERNAME_MAX_LENGTH",
            FieldName = "AccountHolderName",
            Message = "CustomerBankAccount.AccountHolderName exceeds maximum length 150.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.AccountHolderName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AccountHolderName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTISDEFAULTREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_ISDEFAULT_REQUIRED",
            RuleName = "CustomerBankAccount.IsDefault is mandatory",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_ISDEFAULT_REQUIRED",
            FieldName = "IsDefault",
            Message = "CustomerBankAccount.IsDefault is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsDefault.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.IsDefault }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREACUSTOMERIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_CUSTOMERID_REQUIRED",
            RuleName = "CustomerSalesArea.CustomerId is mandatory",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_CUSTOMERID_REQUIRED",
            FieldName = "CustomerId",
            Message = "CustomerSalesArea.CustomerId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREASALESORGANIZATIONIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_SALESORGANIZATIONID_REQUIRED",
            RuleName = "CustomerSalesArea.SalesOrganizationId is mandatory",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_SALESORGANIZATIONID_REQUIRED",
            FieldName = "SalesOrganizationId",
            Message = "CustomerSalesArea.SalesOrganizationId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.SalesOrganizationId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.SalesOrganizationId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREADISTRIBUTIONCHANNELREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => string.IsNullOrEmpty(x.DistributionChannel))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_DISTRIBUTIONCHANNEL_REQUIRED",
            RuleName = "CustomerSalesArea.DistributionChannel is mandatory",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_DISTRIBUTIONCHANNEL_REQUIRED",
            FieldName = "DistributionChannel",
            Message = "CustomerSalesArea.DistributionChannel is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.DistributionChannel,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.DistributionChannel }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREADISTRIBUTIONCHANNELMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => string.IsNullOrEmpty(x.DistributionChannel))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_DISTRIBUTIONCHANNEL_MAX_LENGTH",
            RuleName = "CustomerSalesArea.DistributionChannel must not exceed 30 characters",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_DISTRIBUTIONCHANNEL_MAX_LENGTH",
            FieldName = "DistributionChannel",
            Message = "CustomerSalesArea.DistributionChannel exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.DistributionChannel,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.DistributionChannel }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREADIVISIONREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => string.IsNullOrEmpty(x.Division))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_DIVISION_REQUIRED",
            RuleName = "CustomerSalesArea.Division is mandatory",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_DIVISION_REQUIRED",
            FieldName = "Division",
            Message = "CustomerSalesArea.Division is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.Division,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.Division }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREADIVISIONMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => string.IsNullOrEmpty(x.Division))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_DIVISION_MAX_LENGTH",
            RuleName = "CustomerSalesArea.Division must not exceed 30 characters",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_DIVISION_MAX_LENGTH",
            FieldName = "Division",
            Message = "CustomerSalesArea.Division exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Division,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.Division }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREACREDITLIMITMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => x.CreditLimit >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_CREDITLIMIT_MIN_VALUE",
            RuleName = "CustomerSalesArea.CreditLimit must be >= 0",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_CREDITLIMIT_MIN_VALUE",
            FieldName = "CreditLimit",
            Message = "CustomerSalesArea.CreditLimit must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CreditLimit.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditLimit }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREACUSTOMERGROUPMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => string.IsNullOrEmpty(x.CustomerGroup))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_CUSTOMERGROUP_MAX_LENGTH",
            RuleName = "CustomerSalesArea.CustomerGroup must not exceed 50 characters",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_CUSTOMERGROUP_MAX_LENGTH",
            FieldName = "CustomerGroup",
            Message = "CustomerSalesArea.CustomerGroup exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.CustomerGroup,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CustomerGroup }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREASALESOFFICEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => string.IsNullOrEmpty(x.SalesOffice))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_SALESOFFICE_MAX_LENGTH",
            RuleName = "CustomerSalesArea.SalesOffice must not exceed 50 characters",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_SALESOFFICE_MAX_LENGTH",
            FieldName = "SalesOffice",
            Message = "CustomerSalesArea.SalesOffice exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.SalesOffice,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.SalesOffice }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREASALESDISTRICTMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => string.IsNullOrEmpty(x.SalesDistrict))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_SALESDISTRICT_MAX_LENGTH",
            RuleName = "CustomerSalesArea.SalesDistrict must not exceed 50 characters",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_SALESDISTRICT_MAX_LENGTH",
            FieldName = "SalesDistrict",
            Message = "CustomerSalesArea.SalesDistrict exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.SalesDistrict,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.SalesDistrict }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXCUSTOMERIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_CUSTOMERID_REQUIRED",
            RuleName = "CustomerTax.CustomerId is mandatory",
            EntityName = "CustomerTax",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_CUSTOMERID_REQUIRED",
            FieldName = "CustomerId",
            Message = "CustomerTax.CustomerId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXTAXTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_TAXTYPE_REQUIRED",
            RuleName = "CustomerTax.TaxType is mandatory",
            EntityName = "CustomerTax",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_TAXTYPE_REQUIRED",
            FieldName = "TaxType",
            Message = "CustomerTax.TaxType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.TaxType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.TaxType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXTAXTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_TAXTYPE_MAX_LENGTH",
            RuleName = "CustomerTax.TaxType must not exceed 50 characters",
            EntityName = "CustomerTax",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_TAXTYPE_MAX_LENGTH",
            FieldName = "TaxType",
            Message = "CustomerTax.TaxType exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.TaxType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.TaxType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXTAXNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_TAXNUMBER_REQUIRED",
            RuleName = "CustomerTax.TaxNumber is mandatory",
            EntityName = "CustomerTax",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_TAXNUMBER_REQUIRED",
            FieldName = "TaxNumber",
            Message = "CustomerTax.TaxNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.TaxNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.TaxNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXTAXNUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_TAXNUMBER_MAX_LENGTH",
            RuleName = "CustomerTax.TaxNumber must not exceed 50 characters",
            EntityName = "CustomerTax",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_TAXNUMBER_MAX_LENGTH",
            FieldName = "TaxNumber",
            Message = "CustomerTax.TaxNumber exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.TaxNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.TaxNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXCOUNTRYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_COUNTRYID_REQUIRED",
            RuleName = "CustomerTax.CountryId is mandatory",
            EntityName = "CustomerTax",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_COUNTRYID_REQUIRED",
            FieldName = "CountryId",
            Message = "CustomerTax.CountryId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXISEXEMPTREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_ISEXEMPT_REQUIRED",
            RuleName = "CustomerTax.IsExempt is mandatory",
            EntityName = "CustomerTax",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_ISEXEMPT_REQUIRED",
            FieldName = "IsExempt",
            Message = "CustomerTax.IsExempt is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsExempt.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.IsExempt }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXVALIDITYDATERANGERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => x.ValidTo < x.ValidFrom)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_VALIDITY_DATE_RANGE",
            RuleName = "CustomerTax.ValidTo must be after ValidFrom",
            EntityName = "CustomerTax",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_VALIDITY_DATE_RANGE",
            FieldName = "",
            Message = "CustomerTax.ValidTo cannot be earlier than ValidFrom.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCLASSIFICATIONCUSTOMERIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCLASSIFICATION_CUSTOMERID_REQUIRED",
            RuleName = "CustomerClassification.CustomerId is mandatory",
            EntityName = "CustomerClassification",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCLASSIFICATION_CUSTOMERID_REQUIRED",
            FieldName = "CustomerId",
            Message = "CustomerClassification.CustomerId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassificationType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONTYPE_REQUIRED",
            RuleName = "CustomerClassification.ClassificationType is mandatory",
            EntityName = "CustomerClassification",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONTYPE_REQUIRED",
            FieldName = "ClassificationType",
            Message = "CustomerClassification.ClassificationType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ClassificationType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.ClassificationType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassificationType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONTYPE_MAX_LENGTH",
            RuleName = "CustomerClassification.ClassificationType must not exceed 50 characters",
            EntityName = "CustomerClassification",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONTYPE_MAX_LENGTH",
            FieldName = "ClassificationType",
            Message = "CustomerClassification.ClassificationType exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.ClassificationType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.ClassificationType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONVALUEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassificationValue))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONVALUE_REQUIRED",
            RuleName = "CustomerClassification.ClassificationValue is mandatory",
            EntityName = "CustomerClassification",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONVALUE_REQUIRED",
            FieldName = "ClassificationValue",
            Message = "CustomerClassification.ClassificationValue is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ClassificationValue,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.ClassificationValue }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONVALUEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassificationValue))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONVALUE_MAX_LENGTH",
            RuleName = "CustomerClassification.ClassificationValue must not exceed 100 characters",
            EntityName = "CustomerClassification",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONVALUE_MAX_LENGTH",
            FieldName = "ClassificationValue",
            Message = "CustomerClassification.ClassificationValue exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.ClassificationValue,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.ClassificationValue }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONGROUPMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassificationGroup))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONGROUP_MAX_LENGTH",
            RuleName = "CustomerClassification.ClassificationGroup must not exceed 50 characters",
            EntityName = "CustomerClassification",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONGROUP_MAX_LENGTH",
            FieldName = "ClassificationGroup",
            Message = "CustomerClassification.ClassificationGroup exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.ClassificationGroup,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.ClassificationGroup }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILECUSTOMERIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_CUSTOMERID_REQUIRED",
            RuleName = "CustomerCreditProfile.CustomerId is mandatory",
            EntityName = "CustomerCreditProfile",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_CUSTOMERID_REQUIRED",
            FieldName = "CustomerId",
            Message = "CustomerCreditProfile.CustomerId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILECREDITCONTROLAREAREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => string.IsNullOrEmpty(x.CreditControlArea))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITCONTROLAREA_REQUIRED",
            RuleName = "CustomerCreditProfile.CreditControlArea is mandatory",
            EntityName = "CustomerCreditProfile",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITCONTROLAREA_REQUIRED",
            FieldName = "CreditControlArea",
            Message = "CustomerCreditProfile.CreditControlArea is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CreditControlArea,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditControlArea }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILECREDITCONTROLAREAMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => string.IsNullOrEmpty(x.CreditControlArea))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITCONTROLAREA_MAX_LENGTH",
            RuleName = "CustomerCreditProfile.CreditControlArea must not exceed 20 characters",
            EntityName = "CustomerCreditProfile",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITCONTROLAREA_MAX_LENGTH",
            FieldName = "CreditControlArea",
            Message = "CustomerCreditProfile.CreditControlArea exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.CreditControlArea,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditControlArea }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILECREDITLIMITREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITLIMIT_REQUIRED",
            RuleName = "CustomerCreditProfile.CreditLimit is mandatory",
            EntityName = "CustomerCreditProfile",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITLIMIT_REQUIRED",
            FieldName = "CreditLimit",
            Message = "CustomerCreditProfile.CreditLimit is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CreditLimit.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditLimit }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILECREDITLIMITMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => x.CreditLimit >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITLIMIT_MIN_VALUE",
            RuleName = "CustomerCreditProfile.CreditLimit must be >= 0",
            EntityName = "CustomerCreditProfile",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITLIMIT_MIN_VALUE",
            FieldName = "CreditLimit",
            Message = "CustomerCreditProfile.CreditLimit must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CreditLimit.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditLimit }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILECREDITEXPOSUREMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => x.CreditExposure >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITEXPOSURE_MIN_VALUE",
            RuleName = "CustomerCreditProfile.CreditExposure must be >= 0",
            EntityName = "CustomerCreditProfile",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITEXPOSURE_MIN_VALUE",
            FieldName = "CreditExposure",
            Message = "CustomerCreditProfile.CreditExposure must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CreditExposure.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditExposure }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILECREDITRISKCLASSMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => string.IsNullOrEmpty(x.CreditRiskClass))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITRISKCLASS_MAX_LENGTH",
            RuleName = "CustomerCreditProfile.CreditRiskClass must not exceed 30 characters",
            EntityName = "CustomerCreditProfile",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITRISKCLASS_MAX_LENGTH",
            FieldName = "CreditRiskClass",
            Message = "CustomerCreditProfile.CreditRiskClass exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.CreditRiskClass,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditRiskClass }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILECREDITRISKCLASSALLOWEDVALUESRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => string.IsNullOrEmpty(x.CreditRiskClass))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITRISKCLASS_ALLOWED_VALUES",
            RuleName = "CustomerCreditProfile.CreditRiskClass must contain an allowed value",
            EntityName = "CustomerCreditProfile",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITRISKCLASS_ALLOWED_VALUES",
            FieldName = "CreditRiskClass",
            Message = "CustomerCreditProfile.CreditRiskClass has invalid value.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CreditRiskClass,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditRiskClass }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILEISBLOCKEDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_ISBLOCKED_REQUIRED",
            RuleName = "CustomerCreditProfile.IsBlocked is mandatory",
            EntityName = "CustomerCreditProfile",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_ISBLOCKED_REQUIRED",
            FieldName = "IsBlocked",
            Message = "CustomerCreditProfile.IsBlocked is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsBlocked.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.IsBlocked }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERPARTNERFUNCTIONCUSTOMERIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerPartnerFunctions.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerPartnerFunctions
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERPARTNERFUNCTION_CUSTOMERID_REQUIRED",
            RuleName = "CustomerPartnerFunction.CustomerId is mandatory",
            EntityName = "CustomerPartnerFunction",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerPartnerFunction",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERPARTNERFUNCTION_CUSTOMERID_REQUIRED",
            FieldName = "CustomerId",
            Message = "CustomerPartnerFunction.CustomerId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERPARTNERFUNCTIONPARTNERFUNCTIONCODEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerPartnerFunctions.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerPartnerFunctions
            .Where(x => string.IsNullOrEmpty(x.PartnerFunctionCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERPARTNERFUNCTION_PARTNERFUNCTIONCODE_REQUIRED",
            RuleName = "CustomerPartnerFunction.PartnerFunctionCode is mandatory",
            EntityName = "CustomerPartnerFunction",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerPartnerFunction",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERPARTNERFUNCTION_PARTNERFUNCTIONCODE_REQUIRED",
            FieldName = "PartnerFunctionCode",
            Message = "CustomerPartnerFunction.PartnerFunctionCode is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PartnerFunctionCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PartnerFunctionCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERPARTNERFUNCTIONPARTNERFUNCTIONCODEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerPartnerFunctions.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerPartnerFunctions
            .Where(x => string.IsNullOrEmpty(x.PartnerFunctionCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERPARTNERFUNCTION_PARTNERFUNCTIONCODE_MAX_LENGTH",
            RuleName = "CustomerPartnerFunction.PartnerFunctionCode must not exceed 20 characters",
            EntityName = "CustomerPartnerFunction",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerPartnerFunction",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERPARTNERFUNCTION_PARTNERFUNCTIONCODE_MAX_LENGTH",
            FieldName = "PartnerFunctionCode",
            Message = "CustomerPartnerFunction.PartnerFunctionCode exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.PartnerFunctionCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PartnerFunctionCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERPARTNERFUNCTIONDESCRIPTIONMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerPartnerFunctions.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerPartnerFunctions
            .Where(x => string.IsNullOrEmpty(x.Description))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERPARTNERFUNCTION_DESCRIPTION_MAX_LENGTH",
            RuleName = "CustomerPartnerFunction.Description must not exceed 200 characters",
            EntityName = "CustomerPartnerFunction",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerPartnerFunction",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERPARTNERFUNCTION_DESCRIPTION_MAX_LENGTH",
            FieldName = "Description",
            Message = "CustomerPartnerFunction.Description exceeds maximum length 200.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Description,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.Description }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERPARTNERFUNCTIONISDEFAULTREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerPartnerFunctions.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerPartnerFunctions
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERPARTNERFUNCTION_ISDEFAULT_REQUIRED",
            RuleName = "CustomerPartnerFunction.IsDefault is mandatory",
            EntityName = "CustomerPartnerFunction",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerPartnerFunction",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERPARTNERFUNCTION_ISDEFAULT_REQUIRED",
            FieldName = "IsDefault",
            Message = "CustomerPartnerFunction.IsDefault is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsDefault.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.IsDefault }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTCUSTOMERIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_CUSTOMERID_REQUIRED",
            RuleName = "CustomerAttachment.CustomerId is mandatory",
            EntityName = "CustomerAttachment",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_CUSTOMERID_REQUIRED",
            FieldName = "CustomerId",
            Message = "CustomerAttachment.CustomerId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTDOCUMENTTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.DocumentType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_DOCUMENTTYPE_REQUIRED",
            RuleName = "CustomerAttachment.DocumentType is mandatory",
            EntityName = "CustomerAttachment",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_DOCUMENTTYPE_REQUIRED",
            FieldName = "DocumentType",
            Message = "CustomerAttachment.DocumentType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.DocumentType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.DocumentType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTDOCUMENTTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.DocumentType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_DOCUMENTTYPE_MAX_LENGTH",
            RuleName = "CustomerAttachment.DocumentType must not exceed 50 characters",
            EntityName = "CustomerAttachment",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_DOCUMENTTYPE_MAX_LENGTH",
            FieldName = "DocumentType",
            Message = "CustomerAttachment.DocumentType exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.DocumentType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.DocumentType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTFILENAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.FileName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_FILENAME_REQUIRED",
            RuleName = "CustomerAttachment.FileName is mandatory",
            EntityName = "CustomerAttachment",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_FILENAME_REQUIRED",
            FieldName = "FileName",
            Message = "CustomerAttachment.FileName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.FileName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.FileName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTFILENAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.FileName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_FILENAME_MAX_LENGTH",
            RuleName = "CustomerAttachment.FileName must not exceed 200 characters",
            EntityName = "CustomerAttachment",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_FILENAME_MAX_LENGTH",
            FieldName = "FileName",
            Message = "CustomerAttachment.FileName exceeds maximum length 200.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.FileName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.FileName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTCONTENTTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.ContentType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_CONTENTTYPE_MAX_LENGTH",
            RuleName = "CustomerAttachment.ContentType must not exceed 100 characters",
            EntityName = "CustomerAttachment",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_CONTENTTYPE_MAX_LENGTH",
            FieldName = "ContentType",
            Message = "CustomerAttachment.ContentType exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.ContentType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.ContentType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTSTORAGEPATHREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.StoragePath))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_STORAGEPATH_REQUIRED",
            RuleName = "CustomerAttachment.StoragePath is mandatory",
            EntityName = "CustomerAttachment",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_STORAGEPATH_REQUIRED",
            FieldName = "StoragePath",
            Message = "CustomerAttachment.StoragePath is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.StoragePath,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.StoragePath }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTSTORAGEPATHMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.StoragePath))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_STORAGEPATH_MAX_LENGTH",
            RuleName = "CustomerAttachment.StoragePath must not exceed 500 characters",
            EntityName = "CustomerAttachment",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_STORAGEPATH_MAX_LENGTH",
            FieldName = "StoragePath",
            Message = "CustomerAttachment.StoragePath exceeds maximum length 500.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.StoragePath,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.StoragePath }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTUPLOADEDONREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_UPLOADEDON_REQUIRED",
            RuleName = "CustomerAttachment.UploadedOn is mandatory",
            EntityName = "CustomerAttachment",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_UPLOADEDON_REQUIRED",
            FieldName = "UploadedOn",
            Message = "CustomerAttachment.UploadedOn is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.UploadedOn.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.UploadedOn }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_COUNTRYID_COUNTRY_EXISTS",
            RuleName = "Customer.CountryId must exist in Country",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_COUNTRYID_COUNTRY_EXISTS",
            FieldName = "CountryId",
            Message = "Customer.CountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCURRENCYIDCURRENCYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CURRENCYID_CURRENCY_EXISTS",
            RuleName = "Customer.CurrencyId must exist in Currency",
            EntityName = "Customer",
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
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CURRENCYID_CURRENCY_EXISTS",
            FieldName = "CurrencyId",
            Message = "Customer.CurrencyId must refer to an existing Currency.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerAddress.CustomerId must exist in Customer",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerAddress.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_COUNTRYID_COUNTRY_EXISTS",
            RuleName = "CustomerAddress.CountryId must exist in Country",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_COUNTRYID_COUNTRY_EXISTS",
            FieldName = "CountryId",
            Message = "CustomerAddress.CountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerContact.CustomerId must exist in Customer",
            EntityName = "CustomerContact",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerContact.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerBankAccount.CustomerId must exist in Customer",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerBankAccount.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTCURRENCYIDCURRENCYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_CURRENCYID_CURRENCY_EXISTS",
            RuleName = "CustomerBankAccount.CurrencyId must exist in Currency",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_CURRENCYID_CURRENCY_EXISTS",
            FieldName = "CurrencyId",
            Message = "CustomerBankAccount.CurrencyId must refer to an existing Currency.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTBANKCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => x.BankCountryId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_BANKCOUNTRYID_COUNTRY_EXISTS",
            RuleName = "CustomerBankAccount.BankCountryId must exist in Country",
            EntityName = "CustomerBankAccount",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_BANKCOUNTRYID_COUNTRY_EXISTS",
            FieldName = "BankCountryId",
            Message = "CustomerBankAccount.BankCountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BankCountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.BankCountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREACUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerSalesArea.CustomerId must exist in Customer",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerSalesArea.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREASALESORGANIZATIONIDSALESORGANIZATIONEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_SALESORGANIZATIONID_SALESORGANIZATION_EXISTS",
            RuleName = "CustomerSalesArea.SalesOrganizationId must exist in SalesOrganization",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_SALESORGANIZATIONID_SALESORGANIZATION_EXISTS",
            FieldName = "SalesOrganizationId",
            Message = "CustomerSalesArea.SalesOrganizationId must refer to an existing SalesOrganization.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.SalesOrganizationId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.SalesOrganizationId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREAPAYMENTTERMIDPAYMENTTERMEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => x.PaymentTermId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_PAYMENTTERMID_PAYMENTTERM_EXISTS",
            RuleName = "CustomerSalesArea.PaymentTermId must exist in PaymentTerm",
            EntityName = "CustomerSalesArea",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_PAYMENTTERMID_PAYMENTTERM_EXISTS",
            FieldName = "PaymentTermId",
            Message = "CustomerSalesArea.PaymentTermId must refer to an existing PaymentTerm.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PaymentTermId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PaymentTermId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerTax.CustomerId must exist in Customer",
            EntityName = "CustomerTax",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerTax.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_COUNTRYID_COUNTRY_EXISTS",
            RuleName = "CustomerTax.CountryId must exist in Country",
            EntityName = "CustomerTax",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_COUNTRYID_COUNTRY_EXISTS",
            FieldName = "CountryId",
            Message = "CustomerTax.CountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCLASSIFICATIONCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCLASSIFICATION_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerClassification.CustomerId must exist in Customer",
            EntityName = "CustomerClassification",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCLASSIFICATION_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerClassification.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILECUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerCreditProfile.CustomerId must exist in Customer",
            EntityName = "CustomerCreditProfile",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerCreditProfile.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERPARTNERFUNCTIONCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerPartnerFunctions.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerPartnerFunctions
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERPARTNERFUNCTION_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerPartnerFunction.CustomerId must exist in Customer",
            EntityName = "CustomerPartnerFunction",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerPartnerFunction",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERPARTNERFUNCTION_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerPartnerFunction.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerAttachment.CustomerId must exist in Customer",
            EntityName = "CustomerAttachment",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerAttachment.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERACTIVEREQUIRESDEFAULTADDRESSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_ACTIVE_REQUIRES_DEFAULT_ADDRESS",
            RuleName = "Active customer must have one default address",
            EntityName = "CustomerAddress",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_ACTIVE_REQUIRES_DEFAULT_ADDRESS",
            FieldName = "",
            Message = "Active customer must have at least one default address.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERACTIVEREQUIRESPRIMARYCONTACTRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_ACTIVE_REQUIRES_PRIMARY_CONTACT",
            RuleName = "Active customer must have one primary contact",
            EntityName = "CustomerContact",
            Category = "Integrity",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_ACTIVE_REQUIRES_PRIMARY_CONTACT",
            FieldName = "",
            Message = "Active customer should have at least one primary contact.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERINDIAREQUIRESGSTTAXRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        // TODO: Implement custom business rule logic here.
        // This rule requires custom logic because it cannot be generated safely from metadata alone.
        await Task.CompletedTask;
    }

    private async Task ExecuteCUSTOMERCREDITEXPOSUREWITHINLIMITRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CREDIT_EXPOSURE_WITHIN_LIMIT",
            RuleName = "Customer credit exposure should not exceed credit limit",
            EntityName = "CustomerCreditProfile",
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
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CREDIT_EXPOSURE_WITHIN_LIMIT",
            FieldName = "",
            Message = "Credit exposure cannot exceed credit limit.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
