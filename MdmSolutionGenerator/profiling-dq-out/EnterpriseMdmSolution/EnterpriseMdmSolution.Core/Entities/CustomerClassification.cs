namespace EnterpriseMdmSolution.Core.Entities;

public class CustomerClassification : BaseEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string ClassificationType { get; set; } = string.Empty;
    public string ClassificationValue { get; set; } = string.Empty;
    public string? ClassificationGroup { get; set; }
    public Customer? Customer { get; set; }
}
