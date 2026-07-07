using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class CustomerClassificationConfiguration : IEntityTypeConfiguration<CustomerClassification>
{
    public void Configure(EntityTypeBuilder<CustomerClassification> builder)
    {
        builder.ToTable("CustomerClassifications");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CustomerId)
            .HasColumnName("CustomerId");
        builder.HasIndex(x => x.CustomerId);

        builder.Property(x => x.ClassificationType)
            .HasColumnName("ClassificationType")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ClassificationValue)
            .HasColumnName("ClassificationValue")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.ClassificationGroup)
            .HasColumnName("ClassificationGroup")
            .HasMaxLength(50);
        builder.HasOne(x => x.Customer).WithMany(x => x.CustomerClassifications).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
    }
}
