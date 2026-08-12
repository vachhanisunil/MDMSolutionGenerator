using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class VendorEvaluation : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int VendorId { get; set; }
    [Required]
    [MaxLength(20)]
    public string EvaluationPeriod { get; set; } = string.Empty;
    public decimal? QualityScore { get; set; }
    public decimal? DeliveryScore { get; set; }
    public decimal? CostScore { get; set; }
    public decimal? OverallScore { get; set; }
    public DateTime EvaluationDate { get; set; }
    public Vendor? Vendor { get; set; }
}
