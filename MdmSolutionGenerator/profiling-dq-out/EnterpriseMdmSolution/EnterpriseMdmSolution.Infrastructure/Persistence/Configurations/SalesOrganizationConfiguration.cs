using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class SalesOrganizationConfiguration : IEntityTypeConfiguration<SalesOrganization>
{
    public void Configure(EntityTypeBuilder<SalesOrganization> builder)
    {
        builder.ToTable("SalesOrganizations");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.SalesOrganizationCode)
            .HasColumnName("SalesOrganizationCode")
            .IsRequired()
            .HasMaxLength(10);
        builder.HasIndex(x => x.SalesOrganizationCode).IsUnique();

        builder.Property(x => x.SalesOrganizationName)
            .HasColumnName("SalesOrganizationName")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.CurrencyId)
            .HasColumnName("CurrencyId");
        builder.HasIndex(x => x.CurrencyId);
        builder.HasOne(x => x.Currency).WithMany(x => x.SalesOrganizations).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
    }
}
