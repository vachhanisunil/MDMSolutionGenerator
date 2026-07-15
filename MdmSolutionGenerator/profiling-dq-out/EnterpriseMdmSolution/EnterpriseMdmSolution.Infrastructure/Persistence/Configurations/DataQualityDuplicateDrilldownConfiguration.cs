using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class DataQualityDuplicateDrilldownConfiguration : IEntityTypeConfiguration<DataQualityDuplicateDrilldown>
{
    public void Configure(EntityTypeBuilder<DataQualityDuplicateDrilldown> builder)
    {
        builder.ToTable("DataQualityDuplicateDrilldowns");
        builder.HasKey(x => x.DuplicateDrilldownId);
        builder.Property(x => x.DuplicateDrilldownId).ValueGeneratedNever();
    }
}