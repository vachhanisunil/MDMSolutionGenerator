using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Application.Common;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAnalysisDbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerAddress> CustomerAddresses => Set<CustomerAddress>();
    public DbSet<CustomerContact> CustomerContacts => Set<CustomerContact>();
    public DbSet<CustomerBankAccount> CustomerBankAccounts => Set<CustomerBankAccount>();
    public DbSet<CustomerSalesArea> CustomerSalesAreas => Set<CustomerSalesArea>();
    public DbSet<CustomerTax> CustomerTaxs => Set<CustomerTax>();
    public DbSet<CustomerClassification> CustomerClassifications => Set<CustomerClassification>();
    public DbSet<CustomerCreditProfile> CustomerCreditProfiles => Set<CustomerCreditProfile>();
    public DbSet<CustomerPartnerFunction> CustomerPartnerFunctions => Set<CustomerPartnerFunction>();
    public DbSet<CustomerAttachment> CustomerAttachments => Set<CustomerAttachment>();
    public DbSet<Material> Materials => Set<Material>();
    public DbSet<MaterialPlant> MaterialPlants => Set<MaterialPlant>();
    public DbSet<MaterialPrice> MaterialPrices => Set<MaterialPrice>();
    public DbSet<MaterialStorage> MaterialStorages => Set<MaterialStorage>();
    public DbSet<MaterialClassification> MaterialClassifications => Set<MaterialClassification>();
    public DbSet<MaterialVendor> MaterialVendors => Set<MaterialVendor>();
    public DbSet<MaterialUOM> MaterialUOMs => Set<MaterialUOM>();
    public DbSet<MaterialQualityInspection> MaterialQualityInspections => Set<MaterialQualityInspection>();
    public DbSet<MaterialForecast> MaterialForecasts => Set<MaterialForecast>();
    public DbSet<MaterialBarcode> MaterialBarcodes => Set<MaterialBarcode>();
    public DbSet<Vendor> Vendors => Set<Vendor>();
    public DbSet<VendorAddress> VendorAddresses => Set<VendorAddress>();
    public DbSet<VendorContact> VendorContacts => Set<VendorContact>();
    public DbSet<VendorBankAccount> VendorBankAccounts => Set<VendorBankAccount>();
    public DbSet<VendorTax> VendorTaxs => Set<VendorTax>();
    public DbSet<VendorPurchasingOrganization> VendorPurchasingOrganizations => Set<VendorPurchasingOrganization>();
    public DbSet<VendorCompliance> VendorCompliances => Set<VendorCompliance>();
    public DbSet<VendorEvaluation> VendorEvaluations => Set<VendorEvaluation>();
    public DbSet<VendorCertificate> VendorCertificates => Set<VendorCertificate>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<UnitOfMeasure> UnitOfMeasures => Set<UnitOfMeasure>();
    public DbSet<Plant> Plants => Set<Plant>();
    public DbSet<StorageLocation> StorageLocations => Set<StorageLocation>();
    public DbSet<MaterialGroup> MaterialGroups => Set<MaterialGroup>();
    public DbSet<SalesOrganization> SalesOrganizations => Set<SalesOrganization>();
    public DbSet<PurchasingOrganization> PurchasingOrganizations => Set<PurchasingOrganization>();
    public DbSet<PaymentTerm> PaymentTerms => Set<PaymentTerm>();
    public DbSet<BusinessObjectRun> BusinessObjectRuns => Set<BusinessObjectRun>();
    public DbSet<DataProfilingSummary> DataProfilingSummaries => Set<DataProfilingSummary>();
    public DbSet<DataProfilingDrilldown> DataProfilingDrilldowns => Set<DataProfilingDrilldown>();
    public DbSet<DataQualityRuleResult> DataQualityRuleResults => Set<DataQualityRuleResult>();
    public DbSet<DataQualityRuleSummary> DataQualityRuleSummaries => Set<DataQualityRuleSummary>();
    public DbSet<DataQualityDrilldown> DataQualityDrilldowns => Set<DataQualityDrilldown>();
    public DbSet<DataQualityDuplicateDrilldown> DataQualityDuplicateDrilldowns => Set<DataQualityDuplicateDrilldown>();
    public DbSet<DuplicateCandidateRow> DuplicateCandidateRows => Set<DuplicateCandidateRow>();



    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditValues();
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    private void ApplyAuditValues()
    {
        var now = DateTimeOffset.UtcNow;
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedOn = now;
                entry.Entity.CreatedBy ??= "system";
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedOn = now;
                entry.Entity.ModifiedBy ??= "system";
            }
        }
    }
}