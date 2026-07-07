using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class BusinessObjectRunConfiguration : IEntityTypeConfiguration<BusinessObjectRun>
{
    public void Configure(EntityTypeBuilder<BusinessObjectRun> builder)
    {
        builder.ToTable("BusinessObjectRuns");
        builder.HasKey(x => x.RunId);
        builder.Property(x => x.RunId).ValueGeneratedNever();
    }
}