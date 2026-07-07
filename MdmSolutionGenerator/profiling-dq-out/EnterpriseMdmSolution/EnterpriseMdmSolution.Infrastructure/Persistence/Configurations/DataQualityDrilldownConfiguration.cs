using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class DataQualityDrilldownConfiguration : IEntityTypeConfiguration<DataQualityDrilldown>
{
    public void Configure(EntityTypeBuilder<DataQualityDrilldown> builder)
    {
        builder.ToTable("DataQualityDrilldowns");
        builder.HasKey(x => x.DrilldownId);
        builder.Property(x => x.DrilldownId).ValueGeneratedNever();
    }
}