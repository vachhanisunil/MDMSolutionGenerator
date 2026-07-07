using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class StorageLocationConfiguration : IEntityTypeConfiguration<StorageLocation>
{
    public void Configure(EntityTypeBuilder<StorageLocation> builder)
    {
        builder.ToTable("StorageLocations");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StorageLocationCode)
            .HasColumnName("StorageLocationCode")
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(x => x.StorageLocationName)
            .HasColumnName("StorageLocationName")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.PlantId)
            .HasColumnName("PlantId");
        builder.HasIndex(x => x.PlantId);
        builder.HasOne(x => x.Plant).WithMany(x => x.StorageLocations).HasForeignKey(x => x.PlantId).OnDelete(DeleteBehavior.Restrict);
    }
}
