using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class DataProfilingDrilldownConfiguration : IEntityTypeConfiguration<DataProfilingDrilldown>
{
    public void Configure(EntityTypeBuilder<DataProfilingDrilldown> builder)
    {
        builder.ToTable("DataProfilingDrilldowns");
        builder.HasKey(x => x.DrilldownId);
        builder.Property(x => x.DrilldownId).ValueGeneratedNever();
    }
}