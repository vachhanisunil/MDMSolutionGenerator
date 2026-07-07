namespace EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs;

public sealed class VendorEvaluationDto
{
    public int Id { get; init; }
    public int VendorId { get; init; }
    public string EvaluationPeriod { get; init; } = string.Empty;
    public decimal? QualityScore { get; init; }
    public decimal? DeliveryScore { get; init; }
    public decimal? CostScore { get; init; }
    public decimal? OverallScore { get; init; }
    public DateTime EvaluationDate { get; init; }
}
