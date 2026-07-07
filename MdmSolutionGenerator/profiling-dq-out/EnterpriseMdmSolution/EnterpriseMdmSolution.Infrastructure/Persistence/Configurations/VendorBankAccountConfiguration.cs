using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class VendorBankAccountConfiguration : IEntityTypeConfiguration<VendorBankAccount>
{
    public void Configure(EntityTypeBuilder<VendorBankAccount> builder)
    {
        builder.ToTable("VendorBankAccounts");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VendorId)
            .HasColumnName("VendorId");
        builder.HasIndex(x => x.VendorId);

        builder.Property(x => x.BankName)
            .HasColumnName("BankName")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.AccountNumber)
            .HasColumnName("AccountNumber")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.IfscCode)
            .HasColumnName("IfscCode")
            .HasMaxLength(20);

        builder.Property(x => x.SwiftCode)
            .HasColumnName("SwiftCode")
            .HasMaxLength(20);

        builder.Property(x => x.CurrencyId)
            .HasColumnName("CurrencyId");
        builder.HasIndex(x => x.CurrencyId);

        builder.Property(x => x.AccountHolderName)
            .HasColumnName("AccountHolderName")
            .HasMaxLength(150);

        builder.Property(x => x.BankCountryId)
            .HasColumnName("BankCountryId");
        builder.HasIndex(x => x.BankCountryId);

        builder.Property(x => x.IsDefault)
            .HasColumnName("IsDefault");
        builder.HasOne(x => x.Vendor).WithMany(x => x.VendorBankAccounts).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Currency).WithMany(x => x.VendorBankAccounts).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Country).WithMany(x => x.VendorBankAccounts).HasForeignKey(x => x.BankCountryId).OnDelete(DeleteBehavior.Restrict);
    }
}
