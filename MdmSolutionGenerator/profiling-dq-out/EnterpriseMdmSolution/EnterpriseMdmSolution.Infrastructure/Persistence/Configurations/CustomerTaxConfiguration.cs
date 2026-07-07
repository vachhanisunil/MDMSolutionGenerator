using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class CustomerTaxConfiguration : IEntityTypeConfiguration<CustomerTax>
{
    public void Configure(EntityTypeBuilder<CustomerTax> builder)
    {
        builder.ToTable("CustomerTaxs");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CustomerId)
            .HasColumnName("CustomerId");
        builder.HasIndex(x => x.CustomerId);

        builder.Property(x => x.TaxType)
            .HasColumnName("TaxType")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.TaxNumber)
            .HasColumnName("TaxNumber")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.CountryId)
            .HasColumnName("CountryId");
        builder.HasIndex(x => x.CountryId);

        builder.Property(x => x.ValidFrom)
            .HasColumnName("ValidFrom");

        builder.Property(x => x.ValidTo)
            .HasColumnName("ValidTo");

        builder.Property(x => x.IsExempt)
            .HasColumnName("IsExempt");
        builder.HasOne(x => x.Customer).WithMany(x => x.CustomerTaxs).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Country).WithMany(x => x.CustomerTaxs).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
    }
}
