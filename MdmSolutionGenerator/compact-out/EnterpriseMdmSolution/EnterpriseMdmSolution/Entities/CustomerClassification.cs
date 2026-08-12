using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class CustomerClassification : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    [Required]
    [MaxLength(50)]
    public string ClassificationType { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string ClassificationValue { get; set; } = string.Empty;
    [MaxLength(50)]
    public string? ClassificationGroup { get; set; }
    public Customer? Customer { get; set; }
}
