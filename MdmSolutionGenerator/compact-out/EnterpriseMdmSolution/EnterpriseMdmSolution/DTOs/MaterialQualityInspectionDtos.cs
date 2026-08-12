namespace EnterpriseMdmSolution.DTOs;

public sealed class MaterialQualityInspectionDto
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public string InspectionType { get; set; } = string.Empty;
    public int? InspectionIntervalDays { get; set; }
    public bool QualityCertificateRequired { get; set; }
    public decimal? SampleSize { get; set; }
    public string? AcceptanceCriteria { get; set; }
}

public sealed class CreateMaterialQualityInspectionDto
{
    public int MaterialId { get; set; }
    public string InspectionType { get; set; } = string.Empty;
    public int? InspectionIntervalDays { get; set; }
    public bool QualityCertificateRequired { get; set; }
    public decimal? SampleSize { get; set; }
    public string? AcceptanceCriteria { get; set; }
}

public sealed class UpdateMaterialQualityInspectionDto
{
    public int MaterialId { get; set; }
    public string InspectionType { get; set; } = string.Empty;
    public int? InspectionIntervalDays { get; set; }
    public bool QualityCertificateRequired { get; set; }
    public decimal? SampleSize { get; set; }
    public string? AcceptanceCriteria { get; set; }
}

public sealed class SearchMaterialQualityInspectionDto : EnterpriseMdmSolution.Services.SearchRequest
{
}