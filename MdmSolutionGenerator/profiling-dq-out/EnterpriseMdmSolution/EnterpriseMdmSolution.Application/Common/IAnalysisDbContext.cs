using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Application.Common;

public interface IAnalysisDbContext
{
    DbSet<Customer> Customers { get; }
    DbSet<CustomerAddress> CustomerAddresses { get; }
    DbSet<CustomerContact> CustomerContacts { get; }
    DbSet<CustomerBankAccount> CustomerBankAccounts { get; }
    DbSet<CustomerSalesArea> CustomerSalesAreas { get; }
    DbSet<CustomerTax> CustomerTaxs { get; }
    DbSet<CustomerClassification> CustomerClassifications { get; }
    DbSet<CustomerCreditProfile> CustomerCreditProfiles { get; }
    DbSet<CustomerPartnerFunction> CustomerPartnerFunctions { get; }
    DbSet<CustomerAttachment> CustomerAttachments { get; }
    DbSet<Material> Materials { get; }
    DbSet<MaterialPlant> MaterialPlants { get; }
    DbSet<MaterialPrice> MaterialPrices { get; }
    DbSet<MaterialStorage> MaterialStorages { get; }
    DbSet<MaterialClassification> MaterialClassifications { get; }
    DbSet<MaterialVendor> MaterialVendors { get; }
    DbSet<MaterialUOM> MaterialUOMs { get; }
    DbSet<MaterialQualityInspection> MaterialQualityInspections { get; }
    DbSet<MaterialForecast> MaterialForecasts { get; }
    DbSet<MaterialBarcode> MaterialBarcodes { get; }
    DbSet<Vendor> Vendors { get; }
    DbSet<VendorAddress> VendorAddresses { get; }
    DbSet<VendorContact> VendorContacts { get; }
    DbSet<VendorBankAccount> VendorBankAccounts { get; }
    DbSet<VendorTax> VendorTaxs { get; }
    DbSet<VendorPurchasingOrganization> VendorPurchasingOrganizations { get; }
    DbSet<VendorCompliance> VendorCompliances { get; }
    DbSet<VendorEvaluation> VendorEvaluations { get; }
    DbSet<VendorCertificate> VendorCertificates { get; }
    DbSet<Country> Countries { get; }
    DbSet<Currency> Currencies { get; }
    DbSet<UnitOfMeasure> UnitOfMeasures { get; }
    DbSet<Plant> Plants { get; }
    DbSet<StorageLocation> StorageLocations { get; }
    DbSet<MaterialGroup> MaterialGroups { get; }
    DbSet<SalesOrganization> SalesOrganizations { get; }
    DbSet<PurchasingOrganization> PurchasingOrganizations { get; }
    DbSet<PaymentTerm> PaymentTerms { get; }
    DbSet<BusinessObjectRun> BusinessObjectRuns { get; }
    DbSet<DataProfilingSummary> DataProfilingSummaries { get; }
    DbSet<DataProfilingDrilldown> DataProfilingDrilldowns { get; }
    DbSet<DataQualityRuleResult> DataQualityRuleResults { get; }
    DbSet<DataQualityRuleSummary> DataQualityRuleSummaries { get; }
    DbSet<DataQualityDrilldown> DataQualityDrilldowns { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}