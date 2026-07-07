using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class MaterialBarcodeConfiguration : IEntityTypeConfiguration<MaterialBarcode>
{
    public void Configure(EntityTypeBuilder<MaterialBarcode> builder)
    {
        builder.ToTable("MaterialBarcodes");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.MaterialId)
            .HasColumnName("MaterialId");
        builder.HasIndex(x => x.MaterialId);

        builder.Property(x => x.BarcodeType)
            .HasColumnName("BarcodeType")
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.BarcodeValue)
            .HasColumnName("BarcodeValue")
            .IsRequired()
            .HasMaxLength(100);
        builder.HasIndex(x => x.BarcodeValue).IsUnique();

        builder.Property(x => x.UnitOfMeasureId)
            .HasColumnName("UnitOfMeasureId");
        builder.HasIndex(x => x.UnitOfMeasureId);

        builder.Property(x => x.IsPrimary)
            .HasColumnName("IsPrimary");
        builder.HasOne(x => x.Material).WithMany(x => x.MaterialBarcodes).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.UnitOfMeasure).WithMany(x => x.MaterialBarcodes).HasForeignKey(x => x.UnitOfMeasureId).OnDelete(DeleteBehavior.Restrict);
    }
}
