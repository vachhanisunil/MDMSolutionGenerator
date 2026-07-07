using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class MaterialConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.ToTable("Materials");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.MaterialNumber)
            .HasColumnName("MaterialNumber")
            .IsRequired()
            .HasMaxLength(40);
        builder.HasIndex(x => x.MaterialNumber).IsUnique();

        builder.Property(x => x.MaterialName)
            .HasColumnName("MaterialName")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.MaterialType)
            .HasColumnName("MaterialType")
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.MaterialGroupId)
            .HasColumnName("MaterialGroupId");
        builder.HasIndex(x => x.MaterialGroupId);

        builder.Property(x => x.BaseUnitOfMeasureId)
            .HasColumnName("BaseUnitOfMeasureId");
        builder.HasIndex(x => x.BaseUnitOfMeasureId);

        builder.Property(x => x.GlobalTradeItemNumber)
            .HasColumnName("GlobalTradeItemNumber")
            .HasMaxLength(50);
        builder.HasIndex(x => x.GlobalTradeItemNumber);

        builder.Property(x => x.ProductHierarchy)
            .HasColumnName("ProductHierarchy")
            .HasMaxLength(50);

        builder.Property(x => x.GrossWeight)
            .HasColumnName("GrossWeight");

        builder.Property(x => x.NetWeight)
            .HasColumnName("NetWeight");

        builder.Property(x => x.WeightUnitOfMeasureId)
            .HasColumnName("WeightUnitOfMeasureId");
        builder.HasIndex(x => x.WeightUnitOfMeasureId);

        builder.Property(x => x.IsBatchManaged)
            .HasColumnName("IsBatchManaged");

        builder.Property(x => x.IsSerialManaged)
            .HasColumnName("IsSerialManaged");

        builder.Property(x => x.IsActive)
            .HasColumnName("IsActive");
        builder.HasOne(x => x.MaterialGroup).WithMany(x => x.Materials).HasForeignKey(x => x.MaterialGroupId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.UnitOfMeasure).WithMany(x => x.Materials).HasForeignKey(x => x.BaseUnitOfMeasureId).OnDelete(DeleteBehavior.Restrict);
    }
}
