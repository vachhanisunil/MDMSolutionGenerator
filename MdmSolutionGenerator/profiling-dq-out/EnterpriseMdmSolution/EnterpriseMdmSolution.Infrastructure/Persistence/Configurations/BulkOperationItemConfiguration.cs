using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class BulkOperationItemConfiguration : IEntityTypeConfiguration<BulkOperationItem>
{
    public void Configure(EntityTypeBuilder<BulkOperationItem> builder)
    {
        builder.ToTable("BulkOperationItems");
        builder.HasKey(x => x.ItemId);
        builder.Property(x => x.ItemId).ValueGeneratedNever();
    }
}