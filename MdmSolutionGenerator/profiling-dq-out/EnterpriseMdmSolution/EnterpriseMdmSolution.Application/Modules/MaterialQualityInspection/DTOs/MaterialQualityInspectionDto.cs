namespace EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs;

public sealed class MaterialQualityInspectionDto
{
    public int Id { get; init; }
    public int MaterialId { get; init; }
    public string InspectionType { get; init; } = string.Empty;
    public int? InspectionIntervalDays { get; init; }
    public bool QualityCertificateRequired { get; init; }
    public decimal? SampleSize { get; init; }
    public string? AcceptanceCriteria { get; init; }
}
