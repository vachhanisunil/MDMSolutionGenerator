using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Persistence;

namespace EnterpriseMdmSolution.Analysis;

public sealed class AnalysisService(AppDbContext dbContext)
{
    private static readonly HashSet<string> SupportedBusinessObjects = new(["Customer", "Material", "Vendor"], StringComparer.OrdinalIgnoreCase);

    public async Task<BusinessObjectRunDto> RunAsync(string businessObjectName, CancellationToken cancellationToken)
    {
        if (!SupportedBusinessObjects.Contains(businessObjectName))
        {
            throw new InvalidOperationException($"Business object '{businessObjectName}' is not configured for analysis.");
        }

        var run = new BusinessObjectRun
        {
            RunId = Guid.NewGuid(),
            BusinessObjectName = businessObjectName,
            Status = "Running",
            StartedOn = DateTimeOffset.UtcNow
        };

        dbContext.BusinessObjectRuns.Add(run);
        if (businessObjectName.Equals("Customer", StringComparison.OrdinalIgnoreCase))
        {
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Customer",
                EntityName = "Customer",
                MetricName = "Customer total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.Customers.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Customer",
                EntityName = "CustomerAddress",
                MetricName = "CustomerAddress total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.CustomerAddresses.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Customer",
                EntityName = "CustomerContact",
                MetricName = "CustomerContact total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.CustomerContacts.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Customer",
                EntityName = "CustomerBankAccount",
                MetricName = "CustomerBankAccount total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.CustomerBankAccounts.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Customer",
                EntityName = "CustomerSalesArea",
                MetricName = "CustomerSalesArea total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.CustomerSalesAreas.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Customer",
                EntityName = "CustomerTax",
                MetricName = "CustomerTax total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.CustomerTaxs.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Customer",
                EntityName = "CustomerClassification",
                MetricName = "CustomerClassification total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.CustomerClassifications.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Customer",
                EntityName = "CustomerCreditProfile",
                MetricName = "CustomerCreditProfile total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.CustomerCreditProfiles.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Customer",
                EntityName = "CustomerPartnerFunction",
                MetricName = "CustomerPartnerFunction total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.CustomerPartnerFunctions.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Customer",
                EntityName = "CustomerAttachment",
                MetricName = "CustomerAttachment total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.CustomerAttachments.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
        }
        if (businessObjectName.Equals("Material", StringComparison.OrdinalIgnoreCase))
        {
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Material",
                EntityName = "Material",
                MetricName = "Material total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.Materials.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Material",
                EntityName = "MaterialPlant",
                MetricName = "MaterialPlant total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.MaterialPlants.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Material",
                EntityName = "MaterialPrice",
                MetricName = "MaterialPrice total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.MaterialPrices.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Material",
                EntityName = "MaterialStorage",
                MetricName = "MaterialStorage total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.MaterialStorages.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Material",
                EntityName = "MaterialClassification",
                MetricName = "MaterialClassification total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.MaterialClassifications.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Material",
                EntityName = "MaterialVendor",
                MetricName = "MaterialVendor total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.MaterialVendors.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Material",
                EntityName = "MaterialUOM",
                MetricName = "MaterialUOM total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.MaterialUOMs.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Material",
                EntityName = "MaterialQualityInspection",
                MetricName = "MaterialQualityInspection total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.MaterialQualityInspections.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Material",
                EntityName = "MaterialForecast",
                MetricName = "MaterialForecast total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.MaterialForecasts.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Material",
                EntityName = "MaterialBarcode",
                MetricName = "MaterialBarcode total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.MaterialBarcodes.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
        }
        if (businessObjectName.Equals("Vendor", StringComparison.OrdinalIgnoreCase))
        {
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Vendor",
                EntityName = "Vendor",
                MetricName = "Vendor total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.Vendors.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Vendor",
                EntityName = "VendorAddress",
                MetricName = "VendorAddress total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.VendorAddresses.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Vendor",
                EntityName = "VendorContact",
                MetricName = "VendorContact total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.VendorContacts.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Vendor",
                EntityName = "VendorBankAccount",
                MetricName = "VendorBankAccount total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.VendorBankAccounts.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Vendor",
                EntityName = "VendorTax",
                MetricName = "VendorTax total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.VendorTaxs.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Vendor",
                EntityName = "VendorPurchasingOrganization",
                MetricName = "VendorPurchasingOrganization total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Vendor",
                EntityName = "VendorCompliance",
                MetricName = "VendorCompliance total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.VendorCompliances.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Vendor",
                EntityName = "VendorEvaluation",
                MetricName = "VendorEvaluation total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.VendorEvaluations.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
                        dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "Vendor",
                EntityName = "VendorCertificate",
                MetricName = "VendorCertificate total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.VendorCertificates.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
        }
        run.Status = "Completed";
        run.CompletedOn = DateTimeOffset.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);
        return MapRun(run);
    }

    public async Task<IReadOnlyList<BusinessObjectRunDto>> GetRunsAsync(string businessObjectName, CancellationToken cancellationToken)
        => await dbContext.BusinessObjectRuns
            .Where(x => x.BusinessObjectName == businessObjectName)
            .OrderByDescending(x => x.StartedOn)
            .Select(x => MapRun(x))
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<DataProfilingSummary>> GetProfilingSummariesAsync(Guid runId, CancellationToken cancellationToken)
        => await dbContext.DataProfilingSummaries.Where(x => x.RunId == runId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<DataProfilingDrilldown>> GetProfilingDrilldownsAsync(Guid runId, Guid summaryId, CancellationToken cancellationToken)
        => await dbContext.DataProfilingDrilldowns.Where(x => x.RunId == runId && x.SummaryId == summaryId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<DataQualityRuleResult>> GetRuleResultsAsync(Guid runId, CancellationToken cancellationToken)
        => await dbContext.DataQualityRuleResults.Where(x => x.RunId == runId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<DataQualityDrilldown>> GetRuleDrilldownsAsync(Guid runId, Guid resultId, CancellationToken cancellationToken)
        => await dbContext.DataQualityDrilldowns.Where(x => x.RunId == runId && x.ResultId == resultId).ToListAsync(cancellationToken);

    private static BusinessObjectRunDto MapRun(BusinessObjectRun run)
        => new()
        {
            RunId = run.RunId,
            BusinessObjectName = run.BusinessObjectName,
            Status = run.Status,
            StartedOn = run.StartedOn,
            CompletedOn = run.CompletedOn
        };
}