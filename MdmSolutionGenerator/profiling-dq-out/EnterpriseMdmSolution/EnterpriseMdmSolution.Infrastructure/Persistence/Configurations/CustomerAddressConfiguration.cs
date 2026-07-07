using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
{
    public void Configure(EntityTypeBuilder<CustomerAddress> builder)
    {
        builder.ToTable("CustomerAddresses");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CustomerId)
            .HasColumnName("CustomerId");
        builder.HasIndex(x => x.CustomerId);

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

        builder.Property(x => x.Latitude)
            .HasColumnName("Latitude");

        builder.Property(x => x.Longitude)
            .HasColumnName("Longitude");

        builder.Property(x => x.IsDefault)
            .HasColumnName("IsDefault");
        builder.HasOne(x => x.Customer).WithMany(x => x.CustomerAddresses).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Country).WithMany(x => x.CustomerAddresses).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
    }
}
