namespace EnterpriseMdmSolution.Core.DataQuality;

public sealed class DataQualityRuleResult : EnterpriseMdmSolution.Core.Entities.BaseEntity
{
    public Guid ResultId { get; set; }
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string RuleCode { get; set; } = string.Empty;
    public string RuleName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int AffectedCount { get; set; }
    public decimal Score { get; set; }
    public new DateTimeOffset CreatedOn { get; set; }
}