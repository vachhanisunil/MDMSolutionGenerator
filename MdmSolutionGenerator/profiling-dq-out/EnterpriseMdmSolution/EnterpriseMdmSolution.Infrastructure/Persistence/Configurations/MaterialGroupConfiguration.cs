using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class MaterialGroupConfiguration : IEntityTypeConfiguration<MaterialGroup>
{
    public void Configure(EntityTypeBuilder<MaterialGroup> builder)
    {
        builder.ToTable("MaterialGroups");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .HasColumnName("Code")
            .IsRequired()
            .HasMaxLength(20);
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(150);
    }
}
