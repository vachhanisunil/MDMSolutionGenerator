using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Infrastructure.Persistence.Configurations;

public sealed class DuplicateCandidateRowConfiguration : IEntityTypeConfiguration<DuplicateCandidateRow>
{
    public void Configure(EntityTypeBuilder<DuplicateCandidateRow> builder)
    {
        builder.HasNoKey();
        builder.ToView(null);
    }
}