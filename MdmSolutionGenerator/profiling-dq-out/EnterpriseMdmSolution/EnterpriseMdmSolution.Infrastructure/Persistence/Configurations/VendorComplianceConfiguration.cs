using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class VendorComplianceConfiguration : IEntityTypeConfiguration<VendorCompliance>
{
    public void Configure(EntityTypeBuilder<VendorCompliance> builder)
    {
        builder.ToTable("VendorCompliances");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VendorId)
            .HasColumnName("VendorId");
        builder.HasIndex(x => x.VendorId);

        builder.Property(x => x.ComplianceType)
            .HasColumnName("ComplianceType")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ComplianceStatus)
            .HasColumnName("ComplianceStatus")
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.CertificateNumber)
            .HasColumnName("CertificateNumber")
            .HasMaxLength(100);

        builder.Property(x => x.ValidFrom)
            .HasColumnName("ValidFrom");

        builder.Property(x => x.ValidTo)
            .HasColumnName("ValidTo");

        builder.Property(x => x.ReviewOwner)
            .HasColumnName("ReviewOwner")
            .HasMaxLength(100);
        builder.HasOne(x => x.Vendor).WithMany(x => x.VendorCompliances).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
    }
}
