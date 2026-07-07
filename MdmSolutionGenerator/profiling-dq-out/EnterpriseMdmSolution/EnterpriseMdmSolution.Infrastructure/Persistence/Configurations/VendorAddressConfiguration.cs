using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class VendorAddressConfiguration : IEntityTypeConfiguration<VendorAddress>
{
    public void Configure(EntityTypeBuilder<VendorAddress> builder)
    {
        builder.ToTable("VendorAddresses");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VendorId)
            .HasColumnName("VendorId");
        builder.HasIndex(x => x.VendorId);

        builder.Property(x => x.AddressType)
            .HasColumnName("AddressType")
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.AddressLine1)
            .HasColumnName("AddressLine1")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.AddressLine2)
            .HasColumnName("AddressLine2")
            .HasMaxLength(200);

        builder.Property(x => x.City)
            .HasColumnName("City")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.State)
            .HasColumnName("State")
            .HasMaxLength(100);

        builder.Property(x => x.PostalCode)
            .HasColumnName("PostalCode")
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.CountryId)
            .HasColumnName("CountryId");
        builder.HasIndex(x => x.CountryId);

        builder.Property(x => x.Region)
            .HasColumnName("Region")
            .HasMaxLength(100);

        builder.Property(x => x.IsDefault)
            .HasColumnName("IsDefault");
        builder.HasOne(x => x.Vendor).WithMany(x => x.VendorAddresses).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Country).WithMany(x => x.VendorAddresses).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
    }
}
