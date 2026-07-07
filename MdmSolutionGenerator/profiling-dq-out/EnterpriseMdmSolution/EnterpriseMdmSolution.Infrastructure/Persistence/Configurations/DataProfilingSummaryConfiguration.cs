using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class DataProfilingSummaryConfiguration : IEntityTypeConfiguration<DataProfilingSummary>
{
    public void Configure(EntityTypeBuilder<DataProfilingSummary> builder)
    {
        builder.ToTable("DataProfilingSummaries");
        builder.HasKey(x => x.SummaryId);
        builder.Property(x => x.SummaryId).ValueGeneratedNever();
    }
}