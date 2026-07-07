using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class MaterialClassificationConfiguration : IEntityTypeConfiguration<MaterialClassification>
{
    public void Configure(EntityTypeBuilder<MaterialClassification> builder)
    {
        builder.ToTable("MaterialClassifications");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.MaterialId)
            .HasColumnName("MaterialId");
        builder.HasIndex(x => x.MaterialId);

        builder.Property(x => x.ClassType)
            .HasColumnName("ClassType")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ClassValue)
            .HasColumnName("ClassValue")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.CharacteristicName)
            .HasColumnName("CharacteristicName")
            .HasMaxLength(100);
        builder.HasOne(x => x.Material).WithMany(x => x.MaterialClassifications).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
    }
}
