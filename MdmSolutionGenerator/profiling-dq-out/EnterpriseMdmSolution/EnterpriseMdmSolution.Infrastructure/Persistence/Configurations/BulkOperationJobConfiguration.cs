using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class BulkOperationJobConfiguration : IEntityTypeConfiguration<BulkOperationJob>
{
    public void Configure(EntityTypeBuilder<BulkOperationJob> builder)
    {
        builder.ToTable("BulkOperationJobs");
        builder.HasKey(x => x.JobId);
        builder.Property(x => x.JobId).ValueGeneratedNever();
    }
}