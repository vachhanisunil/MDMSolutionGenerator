using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class CustomerAttachmentConfiguration : IEntityTypeConfiguration<CustomerAttachment>
{
    public void Configure(EntityTypeBuilder<CustomerAttachment> builder)
    {
        builder.ToTable("CustomerAttachments");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CustomerId)
            .HasColumnName("CustomerId");
        builder.HasIndex(x => x.CustomerId);

        builder.Property(x => x.DocumentType)
            .HasColumnName("DocumentType")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.FileName)
            .HasColumnName("FileName")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.ContentType)
            .HasColumnName("ContentType")
            .HasMaxLength(100);

        builder.Property(x => x.StoragePath)
            .HasColumnName("StoragePath")
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.UploadedOn)
            .HasColumnName("UploadedOn");
        builder.HasOne(x => x.Customer).WithMany(x => x.CustomerAttachments).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
    }
}
