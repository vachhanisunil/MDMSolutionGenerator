namespace EnterpriseMdmSolution.Core.Entities;

public class MaterialQualityInspection : BaseEntity
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public string InspectionType { get; set; } = string.Empty;
    public int? InspectionIntervalDays { get; set; }
    public bool QualityCertificateRequired { get; set; }
    public decimal? SampleSize { get; set; }
    public string? AcceptanceCriteria { get; set; }
    public Material? Material { get; set; }
}
