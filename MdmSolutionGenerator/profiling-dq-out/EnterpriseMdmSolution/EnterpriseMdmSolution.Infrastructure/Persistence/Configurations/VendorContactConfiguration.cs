using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class VendorContactConfiguration : IEntityTypeConfiguration<VendorContact>
{
    public void Configure(EntityTypeBuilder<VendorContact> builder)
    {
        builder.ToTable("VendorContacts");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VendorId)
            .HasColumnName("VendorId");
        builder.HasIndex(x => x.VendorId);

        builder.Property(x => x.FirstName)
            .HasColumnName("FirstName")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .HasColumnName("LastName")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasMaxLength(250);

        builder.Property(x => x.Phone)
            .HasColumnName("Phone")
            .HasMaxLength(30);

        builder.Property(x => x.MobilePhone)
            .HasColumnName("MobilePhone")
            .HasMaxLength(30);

        builder.Property(x => x.Designation)
            .HasColumnName("Designation")
            .HasMaxLength(100);

        builder.Property(x => x.Department)
            .HasColumnName("Department")
            .HasMaxLength(100);

        builder.Property(x => x.IsPrimary)
            .HasColumnName("IsPrimary");
        builder.HasOne(x => x.Vendor).WithMany(x => x.VendorContacts).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
    }
}
