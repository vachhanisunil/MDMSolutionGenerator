using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class VendorTaxConfiguration : IEntityTypeConfiguration<VendorTax>
{
    public void Configure(EntityTypeBuilder<VendorTax> builder)
    {
        builder.ToTable("VendorTaxs");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VendorId)
            .HasColumnName("VendorId");
        builder.HasIndex(x => x.VendorId);

        builder.Property(x => x.TaxType)
            .HasColumnName("TaxType")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.TaxNumber)
            .HasColumnName("TaxNumber")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.CountryId)
            .HasColumnName("CountryId");
        builder.HasIndex(x => x.CountryId);

        builder.Property(x => x.ValidFrom)
            .HasColumnName("ValidFrom");

        builder.Property(x => x.ValidTo)
            .HasColumnName("ValidTo");

        builder.Property(x => x.IsTaxWithholdingApplicable)
            .HasColumnName("IsTaxWithholdingApplicable");
        builder.HasOne(x => x.Vendor).WithMany(x => x.VendorTaxs).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Country).WithMany(x => x.VendorTaxs).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
    }
}
