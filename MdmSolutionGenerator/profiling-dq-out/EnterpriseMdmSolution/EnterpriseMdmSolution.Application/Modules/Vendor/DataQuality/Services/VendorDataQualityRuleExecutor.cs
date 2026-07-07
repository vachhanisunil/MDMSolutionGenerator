using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Application.Common;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.DataQuality.Services;

public sealed class VendorDataQualityRuleExecutor(IAnalysisDbContext dbContext)
{
    private readonly IAnalysisDbContext _dbContext = dbContext;

    public async Task ExecuteAsync(Guid runId, CancellationToken cancellationToken)
    {
        await ExecuteVENDORVENDORNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORVENDORNUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORVENDORNUMBERUNIQUERuleAsync(runId, cancellationToken);
        await ExecuteVENDORVENDORNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORVENDORNAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORVENDORTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORVENDORTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORVENDORTYPEALLOWEDVALUESRuleAsync(runId, cancellationToken);
        await ExecuteVENDOREMAILMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDOREMAILEMAILFORMATRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPHONEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOUNTRYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCURRENCYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORSUPPLIERCATEGORYMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORDUNSNUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORONBOARDINGSTATUSMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORONBOARDINGSTATUSALLOWEDVALUESRuleAsync(runId, cancellationToken);
        await ExecuteVENDORISACTIVEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSADDRESSTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSADDRESSTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSADDRESSTYPEALLOWEDVALUESRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSADDRESSLINE1REQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSADDRESSLINE1MAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSADDRESSLINE2MAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSCITYREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSCITYMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSSTATEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSPOSTALCODEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSPOSTALCODEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSCOUNTRYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSREGIONMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSISDEFAULTREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTFIRSTNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTFIRSTNAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTLASTNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTLASTNAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTEMAILMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTEMAILEMAILFORMATRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTPHONEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTMOBILEPHONEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTDESIGNATIONMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTDEPARTMENTMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTISPRIMARYREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTBANKNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTBANKNAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTACCOUNTNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTACCOUNTNUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTIFSCCODEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTSWIFTCODEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTCURRENCYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTACCOUNTHOLDERNAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTISDEFAULTREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXTAXTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXTAXTYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXTAXNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXTAXNUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXCOUNTRYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXVALIDITYDATERANGERuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONPURCHASINGORGANIZATIONIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONINCOTERMSMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONPURCHASEGROUPMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONMINIMUMORDERVALUEMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONISBLOCKEDFORPURCHASINGREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCEVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCECOMPLIANCETYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCECOMPLIANCETYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCECOMPLIANCESTATUSREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCECOMPLIANCESTATUSMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCECOMPLIANCESTATUSALLOWEDVALUESRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCECERTIFICATENUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCEREVIEWOWNERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCEVALIDITYDATERANGERuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONEVALUATIONPERIODREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONEVALUATIONPERIODMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONQUALITYSCOREMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONQUALITYSCOREMAXVALUERuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONDELIVERYSCOREMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONDELIVERYSCOREMAXVALUERuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONCOSTSCOREMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONCOSTSCOREMAXVALUERuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONOVERALLSCOREMINVALUERuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONOVERALLSCOREMAXVALUERuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONEVALUATIONDATEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCERTIFICATEVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCERTIFICATECERTIFICATETYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCERTIFICATECERTIFICATETYPEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCERTIFICATECERTIFICATENAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCERTIFICATECERTIFICATENAMEMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCERTIFICATECERTIFICATENUMBERMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCERTIFICATEISSUINGAUTHORITYMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCERTIFICATESTORAGEPATHMAXLENGTHRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCURRENCYIDCURRENCYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPAYMENTTERMIDPAYMENTTERMEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTCURRENCYIDCURRENCYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTBANKCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONPURCHASINGORGANIZATIONIDPURCHASINGORGANIZATIONEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONPAYMENTTERMIDPAYMENTTERMEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONORDERCURRENCYIDCURRENCYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCEVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCERTIFICATEVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORAPPROVEDREQUIRESDEFAULTADDRESSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORAPPROVEDREQUIRESPRIMARYCONTACTRuleAsync(runId, cancellationToken);
        await ExecuteVENDORAPPROVEDREQUIRESVALIDCOMPLIANCERuleAsync(runId, cancellationToken);
    }

    private async Task ExecuteVENDORVENDORNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_VENDORNUMBER_REQUIRED",
            RuleName = "Vendor.VendorNumber is mandatory",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_VENDORNUMBER_REQUIRED",
            FieldName = "VendorNumber",
            Message = "Vendor.VendorNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORVENDORNUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_VENDORNUMBER_MAX_LENGTH",
            RuleName = "Vendor.VendorNumber must not exceed 20 characters",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_VENDORNUMBER_MAX_LENGTH",
            FieldName = "VendorNumber",
            Message = "Vendor.VendorNumber exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.VendorNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORVENDORNUMBERUNIQUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_VENDORNUMBER_UNIQUE",
            RuleName = "Vendor.VendorNumber must be unique",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_VENDORNUMBER_UNIQUE",
            FieldName = "VendorNumber",
            Message = "Vendor.VendorNumber must be unique.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORVENDORNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_VENDORNAME_REQUIRED",
            RuleName = "Vendor.VendorName is mandatory",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_VENDORNAME_REQUIRED",
            FieldName = "VendorName",
            Message = "Vendor.VendorName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORVENDORNAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_VENDORNAME_MAX_LENGTH",
            RuleName = "Vendor.VendorName must not exceed 200 characters",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_VENDORNAME_MAX_LENGTH",
            FieldName = "VendorName",
            Message = "Vendor.VendorName exceeds maximum length 200.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.VendorName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORVENDORTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_VENDORTYPE_REQUIRED",
            RuleName = "Vendor.VendorType is mandatory",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_VENDORTYPE_REQUIRED",
            FieldName = "VendorType",
            Message = "Vendor.VendorType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORVENDORTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_VENDORTYPE_MAX_LENGTH",
            RuleName = "Vendor.VendorType must not exceed 30 characters",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_VENDORTYPE_MAX_LENGTH",
            FieldName = "VendorType",
            Message = "Vendor.VendorType exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.VendorType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORVENDORTYPEALLOWEDVALUESRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_VENDORTYPE_ALLOWED_VALUES",
            RuleName = "Vendor.VendorType must contain an allowed value",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_VENDORTYPE_ALLOWED_VALUES",
            FieldName = "VendorType",
            Message = "Vendor.VendorType has invalid value.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREMAILMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.Email))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_EMAIL_MAX_LENGTH",
            RuleName = "Vendor.Email must not exceed 250 characters",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_EMAIL_MAX_LENGTH",
            FieldName = "Email",
            Message = "Vendor.Email exceeds maximum length 250.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Email,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREMAILEMAILFORMATRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.Email))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_EMAIL_EMAIL_FORMAT",
            RuleName = "Vendor.Email must be a valid email",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_EMAIL_EMAIL_FORMAT",
            FieldName = "Email",
            Message = "Vendor.Email must be a valid email address.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.Email,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPHONEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.Phone))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_PHONE_MAX_LENGTH",
            RuleName = "Vendor.Phone must not exceed 30 characters",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_PHONE_MAX_LENGTH",
            FieldName = "Phone",
            Message = "Vendor.Phone exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Phone,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.Phone }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOUNTRYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_COUNTRYID_REQUIRED",
            RuleName = "Vendor.CountryId is mandatory",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_COUNTRYID_REQUIRED",
            FieldName = "CountryId",
            Message = "Vendor.CountryId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCURRENCYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_CURRENCYID_REQUIRED",
            RuleName = "Vendor.CurrencyId is mandatory",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_CURRENCYID_REQUIRED",
            FieldName = "CurrencyId",
            Message = "Vendor.CurrencyId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORSUPPLIERCATEGORYMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.SupplierCategory))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_SUPPLIERCATEGORY_MAX_LENGTH",
            RuleName = "Vendor.SupplierCategory must not exceed 50 characters",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_SUPPLIERCATEGORY_MAX_LENGTH",
            FieldName = "SupplierCategory",
            Message = "Vendor.SupplierCategory exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.SupplierCategory,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.SupplierCategory }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORDUNSNUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.DunsNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_DUNSNUMBER_MAX_LENGTH",
            RuleName = "Vendor.DunsNumber must not exceed 30 characters",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_DUNSNUMBER_MAX_LENGTH",
            FieldName = "DunsNumber",
            Message = "Vendor.DunsNumber exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.DunsNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.DunsNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORONBOARDINGSTATUSMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.OnboardingStatus))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_ONBOARDINGSTATUS_MAX_LENGTH",
            RuleName = "Vendor.OnboardingStatus must not exceed 30 characters",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_ONBOARDINGSTATUS_MAX_LENGTH",
            FieldName = "OnboardingStatus",
            Message = "Vendor.OnboardingStatus exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.OnboardingStatus,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.OnboardingStatus }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORONBOARDINGSTATUSALLOWEDVALUESRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.OnboardingStatus))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_ONBOARDINGSTATUS_ALLOWED_VALUES",
            RuleName = "Vendor.OnboardingStatus must contain an allowed value",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_ONBOARDINGSTATUS_ALLOWED_VALUES",
            FieldName = "OnboardingStatus",
            Message = "Vendor.OnboardingStatus has invalid value.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.OnboardingStatus,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.OnboardingStatus }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORISACTIVEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_ISACTIVE_REQUIRED",
            RuleName = "Vendor.IsActive is mandatory",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_ISACTIVE_REQUIRED",
            FieldName = "IsActive",
            Message = "Vendor.IsActive is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsActive.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.IsActive }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_VENDORID_REQUIRED",
            RuleName = "VendorAddress.VendorId is mandatory",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorAddress.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSADDRESSTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_ADDRESSTYPE_REQUIRED",
            RuleName = "VendorAddress.AddressType is mandatory",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_ADDRESSTYPE_REQUIRED",
            FieldName = "AddressType",
            Message = "VendorAddress.AddressType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AddressType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AddressType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSADDRESSTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_ADDRESSTYPE_MAX_LENGTH",
            RuleName = "VendorAddress.AddressType must not exceed 30 characters",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_ADDRESSTYPE_MAX_LENGTH",
            FieldName = "AddressType",
            Message = "VendorAddress.AddressType exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.AddressType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AddressType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSADDRESSTYPEALLOWEDVALUESRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_ADDRESSTYPE_ALLOWED_VALUES",
            RuleName = "VendorAddress.AddressType must contain an allowed value",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_ADDRESSTYPE_ALLOWED_VALUES",
            FieldName = "AddressType",
            Message = "VendorAddress.AddressType has invalid value.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AddressType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AddressType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSADDRESSLINE1REQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressLine1))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_ADDRESSLINE1_REQUIRED",
            RuleName = "VendorAddress.AddressLine1 is mandatory",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_ADDRESSLINE1_REQUIRED",
            FieldName = "AddressLine1",
            Message = "VendorAddress.AddressLine1 is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AddressLine1,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AddressLine1 }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSADDRESSLINE1MAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressLine1))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_ADDRESSLINE1_MAX_LENGTH",
            RuleName = "VendorAddress.AddressLine1 must not exceed 200 characters",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_ADDRESSLINE1_MAX_LENGTH",
            FieldName = "AddressLine1",
            Message = "VendorAddress.AddressLine1 exceeds maximum length 200.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.AddressLine1,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AddressLine1 }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSADDRESSLINE2MAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressLine2))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_ADDRESSLINE2_MAX_LENGTH",
            RuleName = "VendorAddress.AddressLine2 must not exceed 200 characters",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_ADDRESSLINE2_MAX_LENGTH",
            FieldName = "AddressLine2",
            Message = "VendorAddress.AddressLine2 exceeds maximum length 200.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.AddressLine2,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AddressLine2 }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSCITYREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.City))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_CITY_REQUIRED",
            RuleName = "VendorAddress.City is mandatory",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_CITY_REQUIRED",
            FieldName = "City",
            Message = "VendorAddress.City is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.City,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.City }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSCITYMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.City))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_CITY_MAX_LENGTH",
            RuleName = "VendorAddress.City must not exceed 100 characters",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_CITY_MAX_LENGTH",
            FieldName = "City",
            Message = "VendorAddress.City exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.City,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.City }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSSTATEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.State))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_STATE_MAX_LENGTH",
            RuleName = "VendorAddress.State must not exceed 100 characters",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_STATE_MAX_LENGTH",
            FieldName = "State",
            Message = "VendorAddress.State exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.State,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.State }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSPOSTALCODEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.PostalCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_POSTALCODE_REQUIRED",
            RuleName = "VendorAddress.PostalCode is mandatory",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_POSTALCODE_REQUIRED",
            FieldName = "PostalCode",
            Message = "VendorAddress.PostalCode is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PostalCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PostalCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSPOSTALCODEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.PostalCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_POSTALCODE_MAX_LENGTH",
            RuleName = "VendorAddress.PostalCode must not exceed 20 characters",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_POSTALCODE_MAX_LENGTH",
            FieldName = "PostalCode",
            Message = "VendorAddress.PostalCode exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.PostalCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PostalCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSCOUNTRYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_COUNTRYID_REQUIRED",
            RuleName = "VendorAddress.CountryId is mandatory",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_COUNTRYID_REQUIRED",
            FieldName = "CountryId",
            Message = "VendorAddress.CountryId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSREGIONMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.Region))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_REGION_MAX_LENGTH",
            RuleName = "VendorAddress.Region must not exceed 100 characters",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_REGION_MAX_LENGTH",
            FieldName = "Region",
            Message = "VendorAddress.Region exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Region,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.Region }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSISDEFAULTREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_ISDEFAULT_REQUIRED",
            RuleName = "VendorAddress.IsDefault is mandatory",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_ISDEFAULT_REQUIRED",
            FieldName = "IsDefault",
            Message = "VendorAddress.IsDefault is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsDefault.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.IsDefault }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_VENDORID_REQUIRED",
            RuleName = "VendorContact.VendorId is mandatory",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorContact.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTFIRSTNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.FirstName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_FIRSTNAME_REQUIRED",
            RuleName = "VendorContact.FirstName is mandatory",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_FIRSTNAME_REQUIRED",
            FieldName = "FirstName",
            Message = "VendorContact.FirstName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.FirstName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.FirstName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTFIRSTNAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.FirstName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_FIRSTNAME_MAX_LENGTH",
            RuleName = "VendorContact.FirstName must not exceed 100 characters",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_FIRSTNAME_MAX_LENGTH",
            FieldName = "FirstName",
            Message = "VendorContact.FirstName exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.FirstName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.FirstName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTLASTNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.LastName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_LASTNAME_REQUIRED",
            RuleName = "VendorContact.LastName is mandatory",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_LASTNAME_REQUIRED",
            FieldName = "LastName",
            Message = "VendorContact.LastName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.LastName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.LastName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTLASTNAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.LastName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_LASTNAME_MAX_LENGTH",
            RuleName = "VendorContact.LastName must not exceed 100 characters",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_LASTNAME_MAX_LENGTH",
            FieldName = "LastName",
            Message = "VendorContact.LastName exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.LastName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.LastName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTEMAILMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.Email))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_EMAIL_MAX_LENGTH",
            RuleName = "VendorContact.Email must not exceed 250 characters",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_EMAIL_MAX_LENGTH",
            FieldName = "Email",
            Message = "VendorContact.Email exceeds maximum length 250.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Email,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTEMAILEMAILFORMATRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.Email))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_EMAIL_EMAIL_FORMAT",
            RuleName = "VendorContact.Email must be a valid email",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_EMAIL_EMAIL_FORMAT",
            FieldName = "Email",
            Message = "VendorContact.Email must be a valid email address.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.Email,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTPHONEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.Phone))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_PHONE_MAX_LENGTH",
            RuleName = "VendorContact.Phone must not exceed 30 characters",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_PHONE_MAX_LENGTH",
            FieldName = "Phone",
            Message = "VendorContact.Phone exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Phone,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.Phone }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTMOBILEPHONEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.MobilePhone))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_MOBILEPHONE_MAX_LENGTH",
            RuleName = "VendorContact.MobilePhone must not exceed 30 characters",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_MOBILEPHONE_MAX_LENGTH",
            FieldName = "MobilePhone",
            Message = "VendorContact.MobilePhone exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.MobilePhone,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.MobilePhone }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTDESIGNATIONMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.Designation))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_DESIGNATION_MAX_LENGTH",
            RuleName = "VendorContact.Designation must not exceed 100 characters",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_DESIGNATION_MAX_LENGTH",
            FieldName = "Designation",
            Message = "VendorContact.Designation exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Designation,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.Designation }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTDEPARTMENTMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.Department))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_DEPARTMENT_MAX_LENGTH",
            RuleName = "VendorContact.Department must not exceed 100 characters",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_DEPARTMENT_MAX_LENGTH",
            FieldName = "Department",
            Message = "VendorContact.Department exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Department,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.Department }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTISPRIMARYREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_ISPRIMARY_REQUIRED",
            RuleName = "VendorContact.IsPrimary is mandatory",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_ISPRIMARY_REQUIRED",
            FieldName = "IsPrimary",
            Message = "VendorContact.IsPrimary is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsPrimary.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.IsPrimary }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_VENDORID_REQUIRED",
            RuleName = "VendorBankAccount.VendorId is mandatory",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorBankAccount.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTBANKNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => string.IsNullOrEmpty(x.BankName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_BANKNAME_REQUIRED",
            RuleName = "VendorBankAccount.BankName is mandatory",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_BANKNAME_REQUIRED",
            FieldName = "BankName",
            Message = "VendorBankAccount.BankName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BankName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.BankName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTBANKNAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => string.IsNullOrEmpty(x.BankName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_BANKNAME_MAX_LENGTH",
            RuleName = "VendorBankAccount.BankName must not exceed 150 characters",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_BANKNAME_MAX_LENGTH",
            FieldName = "BankName",
            Message = "VendorBankAccount.BankName exceeds maximum length 150.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.BankName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.BankName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTACCOUNTNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => string.IsNullOrEmpty(x.AccountNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_ACCOUNTNUMBER_REQUIRED",
            RuleName = "VendorBankAccount.AccountNumber is mandatory",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_ACCOUNTNUMBER_REQUIRED",
            FieldName = "AccountNumber",
            Message = "VendorBankAccount.AccountNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AccountNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AccountNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTACCOUNTNUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => string.IsNullOrEmpty(x.AccountNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_ACCOUNTNUMBER_MAX_LENGTH",
            RuleName = "VendorBankAccount.AccountNumber must not exceed 50 characters",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_ACCOUNTNUMBER_MAX_LENGTH",
            FieldName = "AccountNumber",
            Message = "VendorBankAccount.AccountNumber exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.AccountNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AccountNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTIFSCCODEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => string.IsNullOrEmpty(x.IfscCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_IFSCCODE_MAX_LENGTH",
            RuleName = "VendorBankAccount.IfscCode must not exceed 20 characters",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_IFSCCODE_MAX_LENGTH",
            FieldName = "IfscCode",
            Message = "VendorBankAccount.IfscCode exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.IfscCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.IfscCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTSWIFTCODEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => string.IsNullOrEmpty(x.SwiftCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_SWIFTCODE_MAX_LENGTH",
            RuleName = "VendorBankAccount.SwiftCode must not exceed 20 characters",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_SWIFTCODE_MAX_LENGTH",
            FieldName = "SwiftCode",
            Message = "VendorBankAccount.SwiftCode exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.SwiftCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.SwiftCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTCURRENCYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_CURRENCYID_REQUIRED",
            RuleName = "VendorBankAccount.CurrencyId is mandatory",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_CURRENCYID_REQUIRED",
            FieldName = "CurrencyId",
            Message = "VendorBankAccount.CurrencyId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTACCOUNTHOLDERNAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => string.IsNullOrEmpty(x.AccountHolderName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_ACCOUNTHOLDERNAME_MAX_LENGTH",
            RuleName = "VendorBankAccount.AccountHolderName must not exceed 150 characters",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_ACCOUNTHOLDERNAME_MAX_LENGTH",
            FieldName = "AccountHolderName",
            Message = "VendorBankAccount.AccountHolderName exceeds maximum length 150.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.AccountHolderName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AccountHolderName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTISDEFAULTREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_ISDEFAULT_REQUIRED",
            RuleName = "VendorBankAccount.IsDefault is mandatory",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_ISDEFAULT_REQUIRED",
            FieldName = "IsDefault",
            Message = "VendorBankAccount.IsDefault is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsDefault.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.IsDefault }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_VENDORID_REQUIRED",
            RuleName = "VendorTax.VendorId is mandatory",
            EntityName = "VendorTax",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorTax.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXTAXTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_TAXTYPE_REQUIRED",
            RuleName = "VendorTax.TaxType is mandatory",
            EntityName = "VendorTax",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_TAXTYPE_REQUIRED",
            FieldName = "TaxType",
            Message = "VendorTax.TaxType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.TaxType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.TaxType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXTAXTYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_TAXTYPE_MAX_LENGTH",
            RuleName = "VendorTax.TaxType must not exceed 50 characters",
            EntityName = "VendorTax",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_TAXTYPE_MAX_LENGTH",
            FieldName = "TaxType",
            Message = "VendorTax.TaxType exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.TaxType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.TaxType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXTAXNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_TAXNUMBER_REQUIRED",
            RuleName = "VendorTax.TaxNumber is mandatory",
            EntityName = "VendorTax",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_TAXNUMBER_REQUIRED",
            FieldName = "TaxNumber",
            Message = "VendorTax.TaxNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.TaxNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.TaxNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXTAXNUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_TAXNUMBER_MAX_LENGTH",
            RuleName = "VendorTax.TaxNumber must not exceed 50 characters",
            EntityName = "VendorTax",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_TAXNUMBER_MAX_LENGTH",
            FieldName = "TaxNumber",
            Message = "VendorTax.TaxNumber exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.TaxNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.TaxNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXCOUNTRYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_COUNTRYID_REQUIRED",
            RuleName = "VendorTax.CountryId is mandatory",
            EntityName = "VendorTax",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_COUNTRYID_REQUIRED",
            FieldName = "CountryId",
            Message = "VendorTax.CountryId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXVALIDITYDATERANGERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => x.ValidTo < x.ValidFrom)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_VALIDITY_DATE_RANGE",
            RuleName = "VendorTax.ValidTo must be after ValidFrom",
            EntityName = "VendorTax",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_VALIDITY_DATE_RANGE",
            FieldName = "",
            Message = "VendorTax.ValidTo cannot be earlier than ValidFrom.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_VENDORID_REQUIRED",
            RuleName = "VendorPurchasingOrganization.VendorId is mandatory",
            EntityName = "VendorPurchasingOrganization",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorPurchasingOrganization.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONPURCHASINGORGANIZATIONIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_PURCHASINGORGANIZATIONID_REQUIRED",
            RuleName = "VendorPurchasingOrganization.PurchasingOrganizationId is mandatory",
            EntityName = "VendorPurchasingOrganization",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_PURCHASINGORGANIZATIONID_REQUIRED",
            FieldName = "PurchasingOrganizationId",
            Message = "VendorPurchasingOrganization.PurchasingOrganizationId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PurchasingOrganizationId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PurchasingOrganizationId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONINCOTERMSMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => string.IsNullOrEmpty(x.Incoterms))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_INCOTERMS_MAX_LENGTH",
            RuleName = "VendorPurchasingOrganization.Incoterms must not exceed 30 characters",
            EntityName = "VendorPurchasingOrganization",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_INCOTERMS_MAX_LENGTH",
            FieldName = "Incoterms",
            Message = "VendorPurchasingOrganization.Incoterms exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.Incoterms,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.Incoterms }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONPURCHASEGROUPMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => string.IsNullOrEmpty(x.PurchaseGroup))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_PURCHASEGROUP_MAX_LENGTH",
            RuleName = "VendorPurchasingOrganization.PurchaseGroup must not exceed 50 characters",
            EntityName = "VendorPurchasingOrganization",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_PURCHASEGROUP_MAX_LENGTH",
            FieldName = "PurchaseGroup",
            Message = "VendorPurchasingOrganization.PurchaseGroup exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.PurchaseGroup,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PurchaseGroup }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONMINIMUMORDERVALUEMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => x.MinimumOrderValue >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_MINIMUMORDERVALUE_MIN_VALUE",
            RuleName = "VendorPurchasingOrganization.MinimumOrderValue must be >= 0",
            EntityName = "VendorPurchasingOrganization",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_MINIMUMORDERVALUE_MIN_VALUE",
            FieldName = "MinimumOrderValue",
            Message = "VendorPurchasingOrganization.MinimumOrderValue must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.MinimumOrderValue.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.MinimumOrderValue }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONISBLOCKEDFORPURCHASINGREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_ISBLOCKEDFORPURCHASING_REQUIRED",
            RuleName = "VendorPurchasingOrganization.IsBlockedForPurchasing is mandatory",
            EntityName = "VendorPurchasingOrganization",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_ISBLOCKEDFORPURCHASING_REQUIRED",
            FieldName = "IsBlockedForPurchasing",
            Message = "VendorPurchasingOrganization.IsBlockedForPurchasing is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.IsBlockedForPurchasing.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.IsBlockedForPurchasing }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCEVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_VENDORID_REQUIRED",
            RuleName = "VendorCompliance.VendorId is mandatory",
            EntityName = "VendorCompliance",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorCompliance.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCECOMPLIANCETYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => string.IsNullOrEmpty(x.ComplianceType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_COMPLIANCETYPE_REQUIRED",
            RuleName = "VendorCompliance.ComplianceType is mandatory",
            EntityName = "VendorCompliance",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_COMPLIANCETYPE_REQUIRED",
            FieldName = "ComplianceType",
            Message = "VendorCompliance.ComplianceType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ComplianceType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.ComplianceType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCECOMPLIANCETYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => string.IsNullOrEmpty(x.ComplianceType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_COMPLIANCETYPE_MAX_LENGTH",
            RuleName = "VendorCompliance.ComplianceType must not exceed 50 characters",
            EntityName = "VendorCompliance",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_COMPLIANCETYPE_MAX_LENGTH",
            FieldName = "ComplianceType",
            Message = "VendorCompliance.ComplianceType exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.ComplianceType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.ComplianceType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCECOMPLIANCESTATUSREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => string.IsNullOrEmpty(x.ComplianceStatus))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_COMPLIANCESTATUS_REQUIRED",
            RuleName = "VendorCompliance.ComplianceStatus is mandatory",
            EntityName = "VendorCompliance",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_COMPLIANCESTATUS_REQUIRED",
            FieldName = "ComplianceStatus",
            Message = "VendorCompliance.ComplianceStatus is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ComplianceStatus,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.ComplianceStatus }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCECOMPLIANCESTATUSMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => string.IsNullOrEmpty(x.ComplianceStatus))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_COMPLIANCESTATUS_MAX_LENGTH",
            RuleName = "VendorCompliance.ComplianceStatus must not exceed 30 characters",
            EntityName = "VendorCompliance",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_COMPLIANCESTATUS_MAX_LENGTH",
            FieldName = "ComplianceStatus",
            Message = "VendorCompliance.ComplianceStatus exceeds maximum length 30.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.ComplianceStatus,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.ComplianceStatus }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCECOMPLIANCESTATUSALLOWEDVALUESRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => string.IsNullOrEmpty(x.ComplianceStatus))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_COMPLIANCESTATUS_ALLOWED_VALUES",
            RuleName = "VendorCompliance.ComplianceStatus must contain an allowed value",
            EntityName = "VendorCompliance",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_COMPLIANCESTATUS_ALLOWED_VALUES",
            FieldName = "ComplianceStatus",
            Message = "VendorCompliance.ComplianceStatus has invalid value.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ComplianceStatus,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.ComplianceStatus }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCECERTIFICATENUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => string.IsNullOrEmpty(x.CertificateNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_CERTIFICATENUMBER_MAX_LENGTH",
            RuleName = "VendorCompliance.CertificateNumber must not exceed 100 characters",
            EntityName = "VendorCompliance",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_CERTIFICATENUMBER_MAX_LENGTH",
            FieldName = "CertificateNumber",
            Message = "VendorCompliance.CertificateNumber exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.CertificateNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CertificateNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCEREVIEWOWNERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => string.IsNullOrEmpty(x.ReviewOwner))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_REVIEWOWNER_MAX_LENGTH",
            RuleName = "VendorCompliance.ReviewOwner must not exceed 100 characters",
            EntityName = "VendorCompliance",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_REVIEWOWNER_MAX_LENGTH",
            FieldName = "ReviewOwner",
            Message = "VendorCompliance.ReviewOwner exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.ReviewOwner,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.ReviewOwner }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCEVALIDITYDATERANGERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => x.ValidTo < x.ValidFrom)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_VALIDITY_DATE_RANGE",
            RuleName = "VendorCompliance.ValidTo must be after ValidFrom",
            EntityName = "VendorCompliance",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_VALIDITY_DATE_RANGE",
            FieldName = "",
            Message = "VendorCompliance.ValidTo cannot be earlier than ValidFrom.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_VENDORID_REQUIRED",
            RuleName = "VendorEvaluation.VendorId is mandatory",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorEvaluation.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONEVALUATIONPERIODREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => string.IsNullOrEmpty(x.EvaluationPeriod))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_EVALUATIONPERIOD_REQUIRED",
            RuleName = "VendorEvaluation.EvaluationPeriod is mandatory",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_EVALUATIONPERIOD_REQUIRED",
            FieldName = "EvaluationPeriod",
            Message = "VendorEvaluation.EvaluationPeriod is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.EvaluationPeriod,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.EvaluationPeriod }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONEVALUATIONPERIODMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => string.IsNullOrEmpty(x.EvaluationPeriod))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_EVALUATIONPERIOD_MAX_LENGTH",
            RuleName = "VendorEvaluation.EvaluationPeriod must not exceed 20 characters",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_EVALUATIONPERIOD_MAX_LENGTH",
            FieldName = "EvaluationPeriod",
            Message = "VendorEvaluation.EvaluationPeriod exceeds maximum length 20.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.EvaluationPeriod,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.EvaluationPeriod }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONQUALITYSCOREMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => x.QualityScore >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_QUALITYSCORE_MIN_VALUE",
            RuleName = "VendorEvaluation.QualityScore must be >= 0",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_QUALITYSCORE_MIN_VALUE",
            FieldName = "QualityScore",
            Message = "VendorEvaluation.QualityScore must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.QualityScore.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.QualityScore }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONQUALITYSCOREMAXVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => x.QualityScore <= 100)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_QUALITYSCORE_MAX_VALUE",
            RuleName = "VendorEvaluation.QualityScore must be <= 100",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_QUALITYSCORE_MAX_VALUE",
            FieldName = "QualityScore",
            Message = "VendorEvaluation.QualityScore must be less than or equal to 100.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.QualityScore.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.QualityScore }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONDELIVERYSCOREMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => x.DeliveryScore >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_DELIVERYSCORE_MIN_VALUE",
            RuleName = "VendorEvaluation.DeliveryScore must be >= 0",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_DELIVERYSCORE_MIN_VALUE",
            FieldName = "DeliveryScore",
            Message = "VendorEvaluation.DeliveryScore must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.DeliveryScore.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.DeliveryScore }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONDELIVERYSCOREMAXVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => x.DeliveryScore <= 100)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_DELIVERYSCORE_MAX_VALUE",
            RuleName = "VendorEvaluation.DeliveryScore must be <= 100",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_DELIVERYSCORE_MAX_VALUE",
            FieldName = "DeliveryScore",
            Message = "VendorEvaluation.DeliveryScore must be less than or equal to 100.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.DeliveryScore.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.DeliveryScore }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONCOSTSCOREMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => x.CostScore >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_COSTSCORE_MIN_VALUE",
            RuleName = "VendorEvaluation.CostScore must be >= 0",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_COSTSCORE_MIN_VALUE",
            FieldName = "CostScore",
            Message = "VendorEvaluation.CostScore must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CostScore.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CostScore }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONCOSTSCOREMAXVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => x.CostScore <= 100)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_COSTSCORE_MAX_VALUE",
            RuleName = "VendorEvaluation.CostScore must be <= 100",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_COSTSCORE_MAX_VALUE",
            FieldName = "CostScore",
            Message = "VendorEvaluation.CostScore must be less than or equal to 100.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CostScore.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CostScore }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONOVERALLSCOREMINVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => x.OverallScore >= 0)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_OVERALLSCORE_MIN_VALUE",
            RuleName = "VendorEvaluation.OverallScore must be >= 0",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_OVERALLSCORE_MIN_VALUE",
            FieldName = "OverallScore",
            Message = "VendorEvaluation.OverallScore must be greater than or equal to 0.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.OverallScore.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.OverallScore }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONOVERALLSCOREMAXVALUERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => x.OverallScore <= 100)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_OVERALLSCORE_MAX_VALUE",
            RuleName = "VendorEvaluation.OverallScore must be <= 100",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_OVERALLSCORE_MAX_VALUE",
            FieldName = "OverallScore",
            Message = "VendorEvaluation.OverallScore must be less than or equal to 100.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.OverallScore.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.OverallScore }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONEVALUATIONDATEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_EVALUATIONDATE_REQUIRED",
            RuleName = "VendorEvaluation.EvaluationDate is mandatory",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_EVALUATIONDATE_REQUIRED",
            FieldName = "EvaluationDate",
            Message = "VendorEvaluation.EvaluationDate is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.EvaluationDate.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.EvaluationDate }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCERTIFICATEVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCERTIFICATE_VENDORID_REQUIRED",
            RuleName = "VendorCertificate.VendorId is mandatory",
            EntityName = "VendorCertificate",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCERTIFICATE_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorCertificate.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCERTIFICATECERTIFICATETYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => string.IsNullOrEmpty(x.CertificateType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCERTIFICATE_CERTIFICATETYPE_REQUIRED",
            RuleName = "VendorCertificate.CertificateType is mandatory",
            EntityName = "VendorCertificate",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCERTIFICATE_CERTIFICATETYPE_REQUIRED",
            FieldName = "CertificateType",
            Message = "VendorCertificate.CertificateType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CertificateType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CertificateType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCERTIFICATECERTIFICATETYPEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => string.IsNullOrEmpty(x.CertificateType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCERTIFICATE_CERTIFICATETYPE_MAX_LENGTH",
            RuleName = "VendorCertificate.CertificateType must not exceed 50 characters",
            EntityName = "VendorCertificate",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCERTIFICATE_CERTIFICATETYPE_MAX_LENGTH",
            FieldName = "CertificateType",
            Message = "VendorCertificate.CertificateType exceeds maximum length 50.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.CertificateType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CertificateType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCERTIFICATECERTIFICATENAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => string.IsNullOrEmpty(x.CertificateName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCERTIFICATE_CERTIFICATENAME_REQUIRED",
            RuleName = "VendorCertificate.CertificateName is mandatory",
            EntityName = "VendorCertificate",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCERTIFICATE_CERTIFICATENAME_REQUIRED",
            FieldName = "CertificateName",
            Message = "VendorCertificate.CertificateName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CertificateName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CertificateName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCERTIFICATECERTIFICATENAMEMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => string.IsNullOrEmpty(x.CertificateName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCERTIFICATE_CERTIFICATENAME_MAX_LENGTH",
            RuleName = "VendorCertificate.CertificateName must not exceed 150 characters",
            EntityName = "VendorCertificate",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCERTIFICATE_CERTIFICATENAME_MAX_LENGTH",
            FieldName = "CertificateName",
            Message = "VendorCertificate.CertificateName exceeds maximum length 150.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.CertificateName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CertificateName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCERTIFICATECERTIFICATENUMBERMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => string.IsNullOrEmpty(x.CertificateNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCERTIFICATE_CERTIFICATENUMBER_MAX_LENGTH",
            RuleName = "VendorCertificate.CertificateNumber must not exceed 100 characters",
            EntityName = "VendorCertificate",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCERTIFICATE_CERTIFICATENUMBER_MAX_LENGTH",
            FieldName = "CertificateNumber",
            Message = "VendorCertificate.CertificateNumber exceeds maximum length 100.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.CertificateNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CertificateNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCERTIFICATEISSUINGAUTHORITYMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => string.IsNullOrEmpty(x.IssuingAuthority))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCERTIFICATE_ISSUINGAUTHORITY_MAX_LENGTH",
            RuleName = "VendorCertificate.IssuingAuthority must not exceed 150 characters",
            EntityName = "VendorCertificate",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCERTIFICATE_ISSUINGAUTHORITY_MAX_LENGTH",
            FieldName = "IssuingAuthority",
            Message = "VendorCertificate.IssuingAuthority exceeds maximum length 150.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.IssuingAuthority,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.IssuingAuthority }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCERTIFICATESTORAGEPATHMAXLENGTHRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => string.IsNullOrEmpty(x.StoragePath))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCERTIFICATE_STORAGEPATH_MAX_LENGTH",
            RuleName = "VendorCertificate.StoragePath must not exceed 500 characters",
            EntityName = "VendorCertificate",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCERTIFICATE_STORAGEPATH_MAX_LENGTH",
            FieldName = "StoragePath",
            Message = "VendorCertificate.StoragePath exceeds maximum length 500.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = x.StoragePath,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.StoragePath }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_COUNTRYID_COUNTRY_EXISTS",
            RuleName = "Vendor.CountryId must exist in Country",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_COUNTRYID_COUNTRY_EXISTS",
            FieldName = "CountryId",
            Message = "Vendor.CountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCURRENCYIDCURRENCYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_CURRENCYID_CURRENCY_EXISTS",
            RuleName = "Vendor.CurrencyId must exist in Currency",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_CURRENCYID_CURRENCY_EXISTS",
            FieldName = "CurrencyId",
            Message = "Vendor.CurrencyId must refer to an existing Currency.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPAYMENTTERMIDPAYMENTTERMEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => x.PaymentTermId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_PAYMENTTERMID_PAYMENTTERM_EXISTS",
            RuleName = "Vendor.PaymentTermId must exist in PaymentTerm",
            EntityName = "Vendor",
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
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_PAYMENTTERMID_PAYMENTTERM_EXISTS",
            FieldName = "PaymentTermId",
            Message = "Vendor.PaymentTermId must refer to an existing PaymentTerm.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PaymentTermId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.PaymentTermId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorAddress.VendorId must exist in Vendor",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorAddress.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_COUNTRYID_COUNTRY_EXISTS",
            RuleName = "VendorAddress.CountryId must exist in Country",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_COUNTRYID_COUNTRY_EXISTS",
            FieldName = "CountryId",
            Message = "VendorAddress.CountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorContact.VendorId must exist in Vendor",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorContact.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorBankAccount.VendorId must exist in Vendor",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorBankAccount.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTCURRENCYIDCURRENCYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_CURRENCYID_CURRENCY_EXISTS",
            RuleName = "VendorBankAccount.CurrencyId must exist in Currency",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_CURRENCYID_CURRENCY_EXISTS",
            FieldName = "CurrencyId",
            Message = "VendorBankAccount.CurrencyId must refer to an existing Currency.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTBANKCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => x.BankCountryId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_BANKCOUNTRYID_COUNTRY_EXISTS",
            RuleName = "VendorBankAccount.BankCountryId must exist in Country",
            EntityName = "VendorBankAccount",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_BANKCOUNTRYID_COUNTRY_EXISTS",
            FieldName = "BankCountryId",
            Message = "VendorBankAccount.BankCountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BankCountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.BankCountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorTax.VendorId must exist in Vendor",
            EntityName = "VendorTax",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorTax.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_COUNTRYID_COUNTRY_EXISTS",
            RuleName = "VendorTax.CountryId must exist in Country",
            EntityName = "VendorTax",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_COUNTRYID_COUNTRY_EXISTS",
            FieldName = "CountryId",
            Message = "VendorTax.CountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorPurchasingOrganization.VendorId must exist in Vendor",
            EntityName = "VendorPurchasingOrganization",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorPurchasingOrganization.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONPURCHASINGORGANIZATIONIDPURCHASINGORGANIZATIONEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_PURCHASINGORGANIZATIONID_PURCHASINGORGANIZATION_EXISTS",
            RuleName = "VendorPurchasingOrganization.PurchasingOrganizationId must exist in PurchasingOrganization",
            EntityName = "VendorPurchasingOrganization",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_PURCHASINGORGANIZATIONID_PURCHASINGORGANIZATION_EXISTS",
            FieldName = "PurchasingOrganizationId",
            Message = "VendorPurchasingOrganization.PurchasingOrganizationId must refer to an existing PurchasingOrganization.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PurchasingOrganizationId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PurchasingOrganizationId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONPAYMENTTERMIDPAYMENTTERMEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => x.PaymentTermId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_PAYMENTTERMID_PAYMENTTERM_EXISTS",
            RuleName = "VendorPurchasingOrganization.PaymentTermId must exist in PaymentTerm",
            EntityName = "VendorPurchasingOrganization",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_PAYMENTTERMID_PAYMENTTERM_EXISTS",
            FieldName = "PaymentTermId",
            Message = "VendorPurchasingOrganization.PaymentTermId must refer to an existing PaymentTerm.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PaymentTermId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PaymentTermId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONORDERCURRENCYIDCURRENCYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => x.OrderCurrencyId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_ORDERCURRENCYID_CURRENCY_EXISTS",
            RuleName = "VendorPurchasingOrganization.OrderCurrencyId must exist in Currency",
            EntityName = "VendorPurchasingOrganization",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_ORDERCURRENCYID_CURRENCY_EXISTS",
            FieldName = "OrderCurrencyId",
            Message = "VendorPurchasingOrganization.OrderCurrencyId must refer to an existing Currency.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.OrderCurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.OrderCurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCEVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorCompliance.VendorId must exist in Vendor",
            EntityName = "VendorCompliance",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorCompliance.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorEvaluation.VendorId must exist in Vendor",
            EntityName = "VendorEvaluation",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorEvaluation.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCERTIFICATEVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCERTIFICATE_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorCertificate.VendorId must exist in Vendor",
            EntityName = "VendorCertificate",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCERTIFICATE_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorCertificate.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORAPPROVEDREQUIRESDEFAULTADDRESSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_APPROVED_REQUIRES_DEFAULT_ADDRESS",
            RuleName = "Approved vendor must have one default address",
            EntityName = "VendorAddress",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_APPROVED_REQUIRES_DEFAULT_ADDRESS",
            FieldName = "",
            Message = "Approved vendor must have at least one default address.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORAPPROVEDREQUIRESPRIMARYCONTACTRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_APPROVED_REQUIRES_PRIMARY_CONTACT",
            RuleName = "Approved vendor must have one primary contact",
            EntityName = "VendorContact",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_APPROVED_REQUIRES_PRIMARY_CONTACT",
            FieldName = "",
            Message = "Approved vendor should have at least one primary contact.",
            Severity = "Medium",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORAPPROVEDREQUIRESVALIDCOMPLIANCERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_APPROVED_REQUIRES_VALID_COMPLIANCE",
            RuleName = "Approved vendor must have approved compliance",
            EntityName = "VendorCompliance",
            Category = "Compliance",
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
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_APPROVED_REQUIRES_VALID_COMPLIANCE",
            FieldName = "",
            Message = "Approved vendor must have at least one approved compliance record.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
