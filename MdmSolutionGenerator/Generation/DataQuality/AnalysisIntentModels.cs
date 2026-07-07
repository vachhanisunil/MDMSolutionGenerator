namespace MdmSolutionGenerator.Generation.DataQuality;

internal sealed class ProfilingIntent
{
    public string BusinessObjectName { get; set; } = "";
    public string EntityName { get; set; } = "";
    public string DbSetName { get; set; } = "";
    public string RootEntityName { get; set; } = "";
    public string PrimaryKey { get; set; } = "Id";
    public string RootKey { get; set; } = "Id";
    public string? ParentForeignKey { get; set; }
    public string SummaryCode { get; set; } = "";
    public string SummaryType { get; set; } = "NullCount";
    public string? ColumnName { get; set; }
    public string ConditionType { get; set; } = "IsNullOrEmpty";
    public string? FieldName { get; set; }
    public bool IsFieldString { get; set; }
    public bool IsFieldNullable { get; set; }
    public bool StoreDrilldown { get; set; }
    public string Label { get; set; } = "";
    public string? Severity { get; set; }
}

internal sealed class DataQualityRuleIntent
{
    public string BusinessObjectName { get; set; } = "";
    public string EntityName { get; set; } = "";
    public string DbSetName { get; set; } = "";
    public string RootEntityName { get; set; } = "";
    public string PrimaryKey { get; set; } = "Id";
    public string RootKey { get; set; } = "Id";
    public string? ParentForeignKey { get; set; }
    public string RuleCode { get; set; } = "";
    public string RuleName { get; set; } = "";
    public string RuleType { get; set; } = "FieldRule";
    public string Category { get; set; } = "Completeness";
    public string Severity { get; set; } = "Medium";
    public string? FieldName { get; set; }
    public bool IsFieldString { get; set; }
    public bool IsFieldNullable { get; set; }
    public string ConditionType { get; set; } = "IsNullOrEmpty";
    public string Message { get; set; } = "";
    public string? LookupEntityName { get; set; }
    public string? LookupDbSetName { get; set; }
    public string? LookupKey { get; set; }
    public string? FromField { get; set; }
    public string? ToField { get; set; }
    public IReadOnlyList<string> AllowedValues { get; set; } = [];
    public string? ComparisonValue { get; set; }
}
