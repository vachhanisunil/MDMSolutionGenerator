using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class DataQualityRuleResultConfiguration : IEntityTypeConfiguration<DataQualityRuleResult>
{
    public void Configure(EntityTypeBuilder<DataQualityRuleResult> builder)
    {
        builder.ToTable("DataQualityRuleResults");
        builder.HasKey(x => x.ResultId);
        builder.Property(x => x.ResultId).ValueGeneratedNever();
    }
}