using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class MaterialForecastConfiguration : IEntityTypeConfiguration<MaterialForecast>
{
    public void Configure(EntityTypeBuilder<MaterialForecast> builder)
    {
        builder.ToTable("MaterialForecasts");
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

        builder.Property(x => x.ForecastPeriod)
            .HasColumnName("ForecastPeriod")
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.ForecastQuantity)
            .HasColumnName("ForecastQuantity");

        builder.Property(x => x.ForecastUnitOfMeasureId)
            .HasColumnName("ForecastUnitOfMeasureId");
        builder.HasIndex(x => x.ForecastUnitOfMeasureId);

        builder.Property(x => x.ConfidencePercent)
            .HasColumnName("ConfidencePercent");
        builder.HasOne(x => x.Material).WithMany(x => x.MaterialForecasts).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Plant).WithMany(x => x.MaterialForecasts).HasForeignKey(x => x.PlantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.UnitOfMeasure).WithMany(x => x.MaterialForecasts).HasForeignKey(x => x.ForecastUnitOfMeasureId).OnDelete(DeleteBehavior.Restrict);
    }
}
