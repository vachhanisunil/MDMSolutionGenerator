using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class CustomerSalesAreaConfiguration : IEntityTypeConfiguration<CustomerSalesArea>
{
    public void Configure(EntityTypeBuilder<CustomerSalesArea> builder)
    {
        builder.ToTable("CustomerSalesAreas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CustomerId)
            .HasColumnName("CustomerId");
        builder.HasIndex(x => x.CustomerId);

        builder.Property(x => x.SalesOrganizationId)
            .HasColumnName("SalesOrganizationId");
        builder.HasIndex(x => x.SalesOrganizationId);

        builder.Property(x => x.DistributionChannel)
            .HasColumnName("DistributionChannel")
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Division)
            .HasColumnName("Division")
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.PaymentTermId)
            .HasColumnName("PaymentTermId");
        builder.HasIndex(x => x.PaymentTermId);

        builder.Property(x => x.CreditLimit)
            .HasColumnName("CreditLimit");

        builder.Property(x => x.CustomerGroup)
            .HasColumnName("CustomerGroup")
            .HasMaxLength(50);

        builder.Property(x => x.SalesOffice)
            .HasColumnName("SalesOffice")
            .HasMaxLength(50);

        builder.Property(x => x.SalesDistrict)
            .HasColumnName("SalesDistrict")
            .HasMaxLength(50);
        builder.HasOne(x => x.Customer).WithMany(x => x.CustomerSalesAreas).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.SalesOrganization).WithMany(x => x.CustomerSalesAreas).HasForeignKey(x => x.SalesOrganizationId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.PaymentTerm).WithMany(x => x.CustomerSalesAreas).HasForeignKey(x => x.PaymentTermId).OnDelete(DeleteBehavior.Restrict);
    }
}
