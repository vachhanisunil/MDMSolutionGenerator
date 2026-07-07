using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class PlantConfiguration : IEntityTypeConfiguration<Plant>
{
    public void Configure(EntityTypeBuilder<Plant> builder)
    {
        builder.ToTable("Plants");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.PlantCode)
            .HasColumnName("PlantCode")
            .IsRequired()
            .HasMaxLength(10);
        builder.HasIndex(x => x.PlantCode).IsUnique();

        builder.Property(x => x.PlantName)
            .HasColumnName("PlantName")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.CountryId)
            .HasColumnName("CountryId");
        builder.HasIndex(x => x.CountryId);
        builder.HasOne(x => x.Country).WithMany(x => x.Plants).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
    }
}
