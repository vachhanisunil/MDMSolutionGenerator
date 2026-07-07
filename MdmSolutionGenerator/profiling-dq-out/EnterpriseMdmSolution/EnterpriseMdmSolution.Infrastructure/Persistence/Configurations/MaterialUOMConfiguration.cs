using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class MaterialUOMConfiguration : IEntityTypeConfiguration<MaterialUOM>
{
    public void Configure(EntityTypeBuilder<MaterialUOM> builder)
    {
        builder.ToTable("MaterialUOMs");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.MaterialId)
            .HasColumnName("MaterialId");
        builder.HasIndex(x => x.MaterialId);

        builder.Property(x => x.UnitOfMeasureId)
            .HasColumnName("UnitOfMeasureId");
        builder.HasIndex(x => x.UnitOfMeasureId);

        builder.Property(x => x.ConversionNumerator)
            .HasColumnName("ConversionNumerator");

        builder.Property(x => x.ConversionDenominator)
            .HasColumnName("ConversionDenominator");

        builder.Property(x => x.Barcode)
            .HasColumnName("Barcode")
            .HasMaxLength(50);

        builder.Property(x => x.IsBaseUnit)
            .HasColumnName("IsBaseUnit");
        builder.HasOne(x => x.Material).WithMany(x => x.MaterialUOMs).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.UnitOfMeasure).WithMany(x => x.MaterialUOMs).HasForeignKey(x => x.UnitOfMeasureId).OnDelete(DeleteBehavior.Restrict);
    }
}
