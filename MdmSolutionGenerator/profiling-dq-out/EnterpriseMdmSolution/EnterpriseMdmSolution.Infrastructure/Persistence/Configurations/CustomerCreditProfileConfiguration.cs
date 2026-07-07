using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class CustomerCreditProfileConfiguration : IEntityTypeConfiguration<CustomerCreditProfile>
{
    public void Configure(EntityTypeBuilder<CustomerCreditProfile> builder)
    {
        builder.ToTable("CustomerCreditProfiles");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CustomerId)
            .HasColumnName("CustomerId");
        builder.HasIndex(x => x.CustomerId);

        builder.Property(x => x.CreditControlArea)
            .HasColumnName("CreditControlArea")
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.CreditLimit)
            .HasColumnName("CreditLimit");

        builder.Property(x => x.CreditExposure)
            .HasColumnName("CreditExposure");

        builder.Property(x => x.CreditRiskClass)
            .HasColumnName("CreditRiskClass")
            .HasMaxLength(30);

        builder.Property(x => x.ReviewDate)
            .HasColumnName("ReviewDate");

        builder.Property(x => x.IsBlocked)
            .HasColumnName("IsBlocked");
        builder.HasOne(x => x.Customer).WithMany(x => x.CustomerCreditProfiles).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
    }
}
