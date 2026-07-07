using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class MaterialPriceConfiguration : IEntityTypeConfiguration<MaterialPrice>
{
    public void Configure(EntityTypeBuilder<MaterialPrice> builder)
    {
        builder.ToTable("MaterialPrices");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.MaterialId)
            .HasColumnName("MaterialId");
        builder.HasIndex(x => x.MaterialId);

        builder.Property(x => x.CurrencyId)
            .HasColumnName("CurrencyId");
        builder.HasIndex(x => x.CurrencyId);

        builder.Property(x => x.PriceType)
            .HasColumnName("PriceType")
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Price)
            .HasColumnName("Price");

        builder.Property(x => x.PriceUnit)
            .HasColumnName("PriceUnit");

        builder.Property(x => x.ValidFrom)
            .HasColumnName("ValidFrom");

        builder.Property(x => x.ValidTo)
            .HasColumnName("ValidTo");

        builder.Property(x => x.SourceSystem)
            .HasColumnName("SourceSystem")
            .HasMaxLength(50);
        builder.HasOne(x => x.Material).WithMany(x => x.MaterialPrices).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Currency).WithMany(x => x.MaterialPrices).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
    }
}
