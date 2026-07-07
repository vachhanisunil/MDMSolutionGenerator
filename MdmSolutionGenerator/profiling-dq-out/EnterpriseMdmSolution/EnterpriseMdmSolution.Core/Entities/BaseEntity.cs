namespace EnterpriseMdmSolution.Core.Entities;

public abstract class BaseEntity
{
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreatedOn { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedOn { get; set; }
}