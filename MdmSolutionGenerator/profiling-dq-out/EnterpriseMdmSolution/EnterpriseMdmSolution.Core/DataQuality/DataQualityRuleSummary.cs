namespace EnterpriseMdmSolution.Core.DataQuality;

public sealed class DataQualityRuleSummary : EnterpriseMdmSolution.Core.Entities.BaseEntity
{
    public Guid RuleSummaryId { get; set; }
    public Guid RunId { get; set; }
    public string RuleCode { get; set; } = string.Empty;
    public string RuleName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int AffectedCount { get; set; }
    public decimal Score { get; set; }
}