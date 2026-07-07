using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class MaterialVendorConfiguration : IEntityTypeConfiguration<MaterialVendor>
{
    public void Configure(EntityTypeBuilder<MaterialVendor> builder)
    {
        builder.ToTable("MaterialVendors");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.MaterialId)
            .HasColumnName("MaterialId");
        builder.HasIndex(x => x.MaterialId);

        builder.Property(x => x.VendorId)
            .HasColumnName("VendorId");
        builder.HasIndex(x => x.VendorId);

        builder.Property(x => x.VendorMaterialNumber)
            .HasColumnName("VendorMaterialNumber")
            .HasMaxLength(50);

        builder.Property(x => x.LeadTimeDays)
            .HasColumnName("LeadTimeDays");

        builder.Property(x => x.MinimumOrderQuantity)
            .HasColumnName("MinimumOrderQuantity");

        builder.Property(x => x.PurchaseUnitOfMeasureId)
            .HasColumnName("PurchaseUnitOfMeasureId");
        builder.HasIndex(x => x.PurchaseUnitOfMeasureId);

        builder.Property(x => x.IsPreferred)
            .HasColumnName("IsPreferred");
        builder.HasOne(x => x.Material).WithMany(x => x.MaterialVendors).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Vendor).WithMany(x => x.MaterialVendors).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.UnitOfMeasure).WithMany(x => x.MaterialVendors).HasForeignKey(x => x.PurchaseUnitOfMeasureId).OnDelete(DeleteBehavior.Restrict);
    }
}
