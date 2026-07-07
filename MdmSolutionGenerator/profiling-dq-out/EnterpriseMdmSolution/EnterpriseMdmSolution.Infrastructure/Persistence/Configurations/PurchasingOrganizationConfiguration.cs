using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class PurchasingOrganizationConfiguration : IEntityTypeConfiguration<PurchasingOrganization>
{
    public void Configure(EntityTypeBuilder<PurchasingOrganization> builder)
    {
        builder.ToTable("PurchasingOrganizations");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.PurchasingOrganizationCode)
            .HasColumnName("PurchasingOrganizationCode")
            .IsRequired()
            .HasMaxLength(10);
        builder.HasIndex(x => x.PurchasingOrganizationCode).IsUnique();

        builder.Property(x => x.PurchasingOrganizationName)
            .HasColumnName("PurchasingOrganizationName")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.CurrencyId)
            .HasColumnName("CurrencyId");
        builder.HasIndex(x => x.CurrencyId);
        builder.HasOne(x => x.Currency).WithMany(x => x.PurchasingOrganizations).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
    }
}
