using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class VendorCertificateConfiguration : IEntityTypeConfiguration<VendorCertificate>
{
    public void Configure(EntityTypeBuilder<VendorCertificate> builder)
    {
        builder.ToTable("VendorCertificates");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VendorId)
            .HasColumnName("VendorId");
        builder.HasIndex(x => x.VendorId);

        builder.Property(x => x.CertificateType)
            .HasColumnName("CertificateType")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.CertificateName)
            .HasColumnName("CertificateName")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.CertificateNumber)
            .HasColumnName("CertificateNumber")
            .HasMaxLength(100);

        builder.Property(x => x.IssuingAuthority)
            .HasColumnName("IssuingAuthority")
            .HasMaxLength(150);

        builder.Property(x => x.ExpiryDate)
            .HasColumnName("ExpiryDate");

        builder.Property(x => x.StoragePath)
            .HasColumnName("StoragePath")
            .HasMaxLength(500);
        builder.HasOne(x => x.Vendor).WithMany(x => x.VendorCertificates).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
    }
}
