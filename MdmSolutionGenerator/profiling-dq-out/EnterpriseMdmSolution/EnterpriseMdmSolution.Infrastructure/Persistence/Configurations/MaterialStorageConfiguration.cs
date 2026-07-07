using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class MaterialStorageConfiguration : IEntityTypeConfiguration<MaterialStorage>
{
    public void Configure(EntityTypeBuilder<MaterialStorage> builder)
    {
        builder.ToTable("MaterialStorages");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.MaterialId)
            .HasColumnName("MaterialId");
        builder.HasIndex(x => x.MaterialId);

        builder.Property(x => x.StorageLocationId)
            .HasColumnName("StorageLocationId");
        builder.HasIndex(x => x.StorageLocationId);

        builder.Property(x => x.BinLocation)
            .HasColumnName("BinLocation")
            .HasMaxLength(50);

        builder.Property(x => x.SafetyStock)
            .HasColumnName("SafetyStock");

        builder.Property(x => x.MaximumStock)
            .HasColumnName("MaximumStock");

        builder.Property(x => x.TemperatureZone)
            .HasColumnName("TemperatureZone")
            .HasMaxLength(30);

        builder.Property(x => x.HazardousStorageRequired)
            .HasColumnName("HazardousStorageRequired");
        builder.HasOne(x => x.Material).WithMany(x => x.MaterialStorages).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.StorageLocation).WithMany(x => x.MaterialStorages).HasForeignKey(x => x.StorageLocationId).OnDelete(DeleteBehavior.Restrict);
    }
}
