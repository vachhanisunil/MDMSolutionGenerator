using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class VendorConfiguration : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.ToTable("Vendors");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VendorNumber)
            .HasColumnName("VendorNumber")
            .IsRequired()
            .HasMaxLength(20);
        builder.HasIndex(x => x.VendorNumber).IsUnique();

        builder.Property(x => x.VendorName)
            .HasColumnName("VendorName")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.VendorType)
            .HasColumnName("VendorType")
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasMaxLength(250);

        builder.Property(x => x.Phone)
            .HasColumnName("Phone")
            .HasMaxLength(30);

        builder.Property(x => x.CountryId)
            .HasColumnName("CountryId");
        builder.HasIndex(x => x.CountryId);

        builder.Property(x => x.CurrencyId)
            .HasColumnName("CurrencyId");
        builder.HasIndex(x => x.CurrencyId);

        builder.Property(x => x.PaymentTermId)
            .HasColumnName("PaymentTermId");
        builder.HasIndex(x => x.PaymentTermId);

        builder.Property(x => x.SupplierCategory)
            .HasColumnName("SupplierCategory")
            .HasMaxLength(50);

        builder.Property(x => x.DunsNumber)
            .HasColumnName("DunsNumber")
            .HasMaxLength(30);
        builder.HasIndex(x => x.DunsNumber);

        builder.Property(x => x.OnboardingStatus)
            .HasColumnName("OnboardingStatus")
            .HasMaxLength(30);

        builder.Property(x => x.OnboardingDate)
            .HasColumnName("OnboardingDate");

        builder.Property(x => x.IsActive)
            .HasColumnName("IsActive");
        builder.HasOne(x => x.Country).WithMany(x => x.Vendors).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Currency).WithMany(x => x.Vendors).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.PaymentTerm).WithMany(x => x.Vendors).HasForeignKey(x => x.PaymentTermId).OnDelete(DeleteBehavior.Restrict);
    }
}
