using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class DataQualityRuleSummaryConfiguration : IEntityTypeConfiguration<DataQualityRuleSummary>
{
    public void Configure(EntityTypeBuilder<DataQualityRuleSummary> builder)
    {
        builder.ToTable("DataQualityRuleSummaries");
        builder.HasKey(x => x.RuleSummaryId);
        builder.Property(x => x.RuleSummaryId).ValueGeneratedNever();
    }
}