using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class MaterialQualityInspection : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int MaterialId { get; set; }
    [Required]
    [MaxLength(50)]
    public string InspectionType { get; set; } = string.Empty;
    public int? InspectionIntervalDays { get; set; }
    public bool QualityCertificateRequired { get; set; }
    public decimal? SampleSize { get; set; }
    [MaxLength(500)]
    public string? AcceptanceCriteria { get; set; }
    public Material? Material { get; set; }
}
