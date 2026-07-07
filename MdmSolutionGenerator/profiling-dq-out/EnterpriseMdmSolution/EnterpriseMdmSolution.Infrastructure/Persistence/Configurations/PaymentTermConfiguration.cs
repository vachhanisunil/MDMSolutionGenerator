using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class PaymentTermConfiguration : IEntityTypeConfiguration<PaymentTerm>
{
    public void Configure(EntityTypeBuilder<PaymentTerm> builder)
    {
        builder.ToTable("PaymentTerms");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .HasColumnName("Code")
            .IsRequired()
            .HasMaxLength(20);
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.Description)
            .HasColumnName("Description")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.NetDays)
            .HasColumnName("NetDays");
    }
}
