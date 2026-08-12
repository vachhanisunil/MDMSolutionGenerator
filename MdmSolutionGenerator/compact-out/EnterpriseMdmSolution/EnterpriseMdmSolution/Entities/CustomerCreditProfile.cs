using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class CustomerCreditProfile : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    [Required]
    [MaxLength(20)]
    public string CreditControlArea { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public decimal? CreditExposure { get; set; }
    [MaxLength(30)]
    public string? CreditRiskClass { get; set; }
    public DateTime? ReviewDate { get; set; }
    public bool IsBlocked { get; set; }
    public Customer? Customer { get; set; }
}
