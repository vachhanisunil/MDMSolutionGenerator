using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class VendorPurchasingOrganizationConfiguration : IEntityTypeConfiguration<VendorPurchasingOrganization>
{
    public void Configure(EntityTypeBuilder<VendorPurchasingOrganization> builder)
    {
        builder.ToTable("VendorPurchasingOrganizations");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VendorId)
            .HasColumnName("VendorId");
        builder.HasIndex(x => x.VendorId);

        builder.Property(x => x.PurchasingOrganizationId)
            .HasColumnName("PurchasingOrganizationId");
        builder.HasIndex(x => x.PurchasingOrganizationId);

        builder.Property(x => x.PaymentTermId)
            .HasColumnName("PaymentTermId");
        builder.HasIndex(x => x.PaymentTermId);

        builder.Property(x => x.Incoterms)
            .HasColumnName("Incoterms")
            .HasMaxLength(30);

        builder.Property(x => x.OrderCurrencyId)
            .HasColumnName("OrderCurrencyId");
        builder.HasIndex(x => x.OrderCurrencyId);

        builder.Property(x => x.PurchaseGroup)
            .HasColumnName("PurchaseGroup")
            .HasMaxLength(50);

        builder.Property(x => x.MinimumOrderValue)
            .HasColumnName("MinimumOrderValue");

        builder.Property(x => x.IsBlockedForPurchasing)
            .HasColumnName("IsBlockedForPurchasing");
        builder.HasOne(x => x.Vendor).WithMany(x => x.VendorPurchasingOrganizations).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.PurchasingOrganization).WithMany(x => x.VendorPurchasingOrganizations).HasForeignKey(x => x.PurchasingOrganizationId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.PaymentTerm).WithMany(x => x.VendorPurchasingOrganizations).HasForeignKey(x => x.PaymentTermId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Currency).WithMany(x => x.VendorPurchasingOrganizations).HasForeignKey(x => x.OrderCurrencyId).OnDelete(DeleteBehavior.Restrict);
    }
}
