using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class MaterialQualityInspectionConfiguration : IEntityTypeConfiguration<MaterialQualityInspection>
{
    public void Configure(EntityTypeBuilder<MaterialQualityInspection> builder)
    {
        builder.ToTable("MaterialQualityInspections");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.MaterialId)
            .HasColumnName("MaterialId");
        builder.HasIndex(x => x.MaterialId);

        builder.Property(x => x.InspectionType)
            .HasColumnName("InspectionType")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.InspectionIntervalDays)
            .HasColumnName("InspectionIntervalDays");

        builder.Property(x => x.QualityCertificateRequired)
            .HasColumnName("QualityCertificateRequired");

        builder.Property(x => x.SampleSize)
            .HasColumnName("SampleSize");

        builder.Property(x => x.AcceptanceCriteria)
            .HasColumnName("AcceptanceCriteria")
            .HasMaxLength(500);
        builder.HasOne(x => x.Material).WithMany(x => x.MaterialQualityInspections).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
    }
}
