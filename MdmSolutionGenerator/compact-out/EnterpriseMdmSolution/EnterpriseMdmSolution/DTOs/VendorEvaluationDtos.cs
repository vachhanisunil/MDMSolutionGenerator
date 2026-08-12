namespace EnterpriseMdmSolution.DTOs;

public sealed class VendorEvaluationDto
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public string EvaluationPeriod { get; set; } = string.Empty;
    public decimal? QualityScore { get; set; }
    public decimal? DeliveryScore { get; set; }
    public decimal? CostScore { get; set; }
    public decimal? OverallScore { get; set; }
    public DateTime EvaluationDate { get; set; }
}

public sealed class CreateVendorEvaluationDto
{
    public int VendorId { get; set; }
    public string EvaluationPeriod { get; set; } = string.Empty;
    public decimal? QualityScore { get; set; }
    public decimal? DeliveryScore { get; set; }
    public decimal? CostScore { get; set; }
    public decimal? OverallScore { get; set; }
    public DateTime EvaluationDate { get; set; }
}

public sealed class UpdateVendorEvaluationDto
{
    public int VendorId { get; set; }
    public string EvaluationPeriod { get; set; } = string.Empty;
    public decimal? QualityScore { get; set; }
    public decimal? DeliveryScore { get; set; }
    public decimal? CostScore { get; set; }
    public decimal? OverallScore { get; set; }
    public DateTime EvaluationDate { get; set; }
}

public sealed class SearchVendorEvaluationDto : EnterpriseMdmSolution.Services.SearchRequest
{
}