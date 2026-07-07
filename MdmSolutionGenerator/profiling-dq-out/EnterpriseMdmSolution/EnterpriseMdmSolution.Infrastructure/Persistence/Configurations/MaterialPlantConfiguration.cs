using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class MaterialPlantConfiguration : IEntityTypeConfiguration<MaterialPlant>
{
    public void Configure(EntityTypeBuilder<MaterialPlant> builder)
    {
        builder.ToTable("MaterialPlants");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.MaterialId)
            .HasColumnName("MaterialId");
        builder.HasIndex(x => x.MaterialId);

        builder.Property(x => x.PlantId)
            .HasColumnName("PlantId");
        builder.HasIndex(x => x.PlantId);

        builder.Property(x => x.ProcurementType)
            .HasColumnName("ProcurementType")
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.ReorderPoint)
            .HasColumnName("ReorderPoint");

        builder.Property(x => x.MinimumLotSize)
            .HasColumnName("MinimumLotSize");

        builder.Property(x => x.MaximumLotSize)
            .HasColumnName("MaximumLotSize");

        builder.Property(x => x.MrpType)
            .HasColumnName("MrpType")
            .HasMaxLength(20);

        builder.Property(x => x.PlanningTimeFenceDays)
            .HasColumnName("PlanningTimeFenceDays");

        builder.Property(x => x.ProfitCenter)
            .HasColumnName("ProfitCenter")
            .HasMaxLength(50);
        builder.HasOne(x => x.Material).WithMany(x => x.MaterialPlants).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Plant).WithMany(x => x.MaterialPlants).HasForeignKey(x => x.PlantId).OnDelete(DeleteBehavior.Restrict);
    }
}
