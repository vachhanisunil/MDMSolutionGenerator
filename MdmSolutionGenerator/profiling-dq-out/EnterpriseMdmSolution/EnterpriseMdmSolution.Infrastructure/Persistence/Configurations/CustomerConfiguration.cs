using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CustomerNumber)
            .HasColumnName("CustomerNumber")
            .IsRequired()
            .HasMaxLength(20);
        builder.HasIndex(x => x.CustomerNumber).IsUnique();

        builder.Property(x => x.CustomerName)
            .HasColumnName("CustomerName")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.CustomerType)
            .HasColumnName("CustomerType")
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasMaxLength(250);

        builder.Property(x => x.Phone)
            .HasColumnName("Phone")
            .HasMaxLength(30);

        builder.Property(x => x.CountryId)
            .HasColumnName("CountryId");
        builder.HasIndex(x => x.CountryId);

        builder.Property(x => x.CurrencyId)
            .HasColumnName("CurrencyId");
        builder.HasIndex(x => x.CurrencyId);

        builder.Property(x => x.IndustryCode)
            .HasColumnName("IndustryCode")
            .HasMaxLength(30);
        builder.HasIndex(x => x.IndustryCode);

        builder.Property(x => x.RiskCategory)
            .HasColumnName("RiskCategory")
            .HasMaxLength(30);

        builder.Property(x => x.RegistrationNumber)
            .HasColumnName("RegistrationNumber")
            .HasMaxLength(50);

        builder.Property(x => x.OnboardingDate)
            .HasColumnName("OnboardingDate");

        builder.Property(x => x.IsActive)
            .HasColumnName("IsActive");
        builder.HasOne(x => x.Country).WithMany(x => x.Customers).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Currency).WithMany(x => x.Customers).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
    }
}
