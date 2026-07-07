using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class CustomerPartnerFunctionConfiguration : IEntityTypeConfiguration<CustomerPartnerFunction>
{
    public void Configure(EntityTypeBuilder<CustomerPartnerFunction> builder)
    {
        builder.ToTable("CustomerPartnerFunctions");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CustomerId)
            .HasColumnName("CustomerId");
        builder.HasIndex(x => x.CustomerId);

        builder.Property(x => x.PartnerFunctionCode)
            .HasColumnName("PartnerFunctionCode")
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.PartnerCustomerId)
            .HasColumnName("PartnerCustomerId");
        builder.HasIndex(x => x.PartnerCustomerId);

        builder.Property(x => x.Description)
            .HasColumnName("Description")
            .HasMaxLength(200);

        builder.Property(x => x.IsDefault)
            .HasColumnName("IsDefault");
        builder.HasOne(x => x.Customer).WithMany(x => x.CustomerPartnerFunctions).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
    }
}
