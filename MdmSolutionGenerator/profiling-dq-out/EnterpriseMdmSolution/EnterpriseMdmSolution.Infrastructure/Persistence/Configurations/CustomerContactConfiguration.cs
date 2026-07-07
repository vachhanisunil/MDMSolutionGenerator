using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class CustomerContactConfiguration : IEntityTypeConfiguration<CustomerContact>
{
    public void Configure(EntityTypeBuilder<CustomerContact> builder)
    {
        builder.ToTable("CustomerContacts");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CustomerId)
            .HasColumnName("CustomerId");
        builder.HasIndex(x => x.CustomerId);

        builder.Property(x => x.FirstName)
            .HasColumnName("FirstName")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .HasColumnName("LastName")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasMaxLength(250);

        builder.Property(x => x.Phone)
            .HasColumnName("Phone")
            .HasMaxLength(30);

        builder.Property(x => x.MobilePhone)
            .HasColumnName("MobilePhone")
            .HasMaxLength(30);

        builder.Property(x => x.Designation)
            .HasColumnName("Designation")
            .HasMaxLength(100);

        builder.Property(x => x.Department)
            .HasColumnName("Department")
            .HasMaxLength(100);

        builder.Property(x => x.PreferredLanguage)
            .HasColumnName("PreferredLanguage")
            .HasMaxLength(20);

        builder.Property(x => x.IsPrimary)
            .HasColumnName("IsPrimary");
        builder.HasOne(x => x.Customer).WithMany(x => x.CustomerContacts).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
    }
}
