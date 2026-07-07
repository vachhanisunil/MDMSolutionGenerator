using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.Entities;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class VendorEvaluationConfiguration : IEntityTypeConfiguration<VendorEvaluation>
{
    public void Configure(EntityTypeBuilder<VendorEvaluation> builder)
    {
        builder.ToTable("VendorEvaluations");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VendorId)
            .HasColumnName("VendorId");
        builder.HasIndex(x => x.VendorId);

        builder.Property(x => x.EvaluationPeriod)
            .HasColumnName("EvaluationPeriod")
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.QualityScore)
            .HasColumnName("QualityScore");

        builder.Property(x => x.DeliveryScore)
            .HasColumnName("DeliveryScore");

        builder.Property(x => x.CostScore)
            .HasColumnName("CostScore");

        builder.Property(x => x.OverallScore)
            .HasColumnName("OverallScore");

        builder.Property(x => x.EvaluationDate)
            .HasColumnName("EvaluationDate");
        builder.HasOne(x => x.Vendor).WithMany(x => x.VendorEvaluations).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
    }
}
