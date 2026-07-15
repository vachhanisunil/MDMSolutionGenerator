using System.Text.Json;
using System.Text.Json.Serialization;

namespace MdmSolutionGenerator.Generation;

public sealed class MetadataDocument
{
    public ApplicationInfo Application { get; init; } = new();
    public string AnalysisGenerationMode { get; init; } = "RequiredFieldsOnly";
    public List<EntityDefinition> Entities { get; init; } = [];
    public List<BusinessObjectDefinition> BusinessObjects { get; init; } = [];
    public List<RelationshipDefinition> Relationships { get; init; } = [];
    public bool Audit { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> ExtensionData { get; init; } = [];
}

public sealed class ApplicationInfo
{
    public string Name { get; init; } = "GeneratedSolution";
    public string? Namespace { get; init; }
    public string? Description { get; init; }
}

public sealed class EntityDefinition
{
    public string Name { get; init; } = "";
    public string? TableName { get; init; }
    public string? PrimaryKey { get; init; }
    public bool Audit { get; init; }
    public List<PropertyDefinition> Properties { get; init; } = [];
    public List<OperationDefinition> Operations { get; init; } = [];
}

public sealed class BusinessObjectDefinition
{
    public string Name { get; init; } = "";
    public string? Entity { get; init; }
    public string? RootEntity { get; init; }
    public List<string> Entities { get; init; } = [];
    public List<OperationDefinition> Operations { get; init; } = [];
    public ProfilingDefinition Profiling { get; init; } = new();
    public List<DataQualityRuleDefinition> DataQualityRules { get; init; } = [];
}

public sealed class ProfilingDefinition
{
    public bool Enabled { get; init; }
    public List<ProfilingMeasurementDefinition> Measurements { get; init; } = [];
    public List<ProfilingMeasurementDefinition> Summaries { get; init; } = [];
    public List<ProfilingObservationDefinition> Observations { get; init; } = [];
}

public sealed class ProfilingMeasurementDefinition
{
    public string Code { get; init; } = "";
    public string SummaryCode { get; init; } = "";
    public string SummaryType { get; init; } = "TotalCount";
    public string Name { get; init; } = "";
    public string Label { get; init; } = "";
    public string Entity { get; init; } = "";
    public string? Field { get; init; }
    public string? Column { get; init; }
    public string Type { get; init; } = "TotalCount";
    public ConditionDefinition Condition { get; init; } = new();
    public bool StoreDrilldown { get; init; }
    public string? Severity { get; init; }
    public decimal Weight { get; init; } = 1;
}

public sealed class ProfilingObservationDefinition
{
    public string Code { get; init; } = "";
    public string Name { get; init; } = "";
    public string Entity { get; init; } = "";
    public string? Field { get; init; }
    public string Type { get; init; } = "NullRecords";
    public bool GenerateDrilldown { get; init; } = true;
}

public sealed class DataQualityRuleDefinition
{
    public string RuleId { get; init; } = "";
    public string RuleCode { get; init; } = "";
    public string RuleName { get; init; } = "";
    public string Label { get; init; } = "";
    public string Category { get; init; } = "Field";
    public string Severity { get; init; } = "Medium";
    public bool Enabled { get; init; } = true;
    public string BusinessObject { get; init; } = "";
    public string Entity { get; init; } = "";
    public string? Field { get; init; }
    public string? Column { get; init; }
    public string Type { get; init; } = "Required";
    public string RuleType { get; init; } = "";
    public string ExecutionType { get; init; } = "";
    public ConditionDefinition Condition { get; init; } = new();
    public FilterDefinition Filter { get; init; } = new();
    public MatchingCriteriaDefinition MatchingCriteria { get; init; } = new();
    public string Message { get; init; } = "";
    public string? LookupEntity { get; init; }
    public string? Relationship { get; init; }
    public string? Expression { get; init; }
    public string? Sql { get; init; }
    public decimal Weight { get; init; } = 1;
}

public sealed class FilterDefinition
{
    public string LogicalOperator { get; init; } = "AND";
    public List<FilterConditionDefinition> Conditions { get; init; } = [];
}

public sealed class FilterConditionDefinition
{
    public string PropertyPath { get; init; } = "";
    public string Operator { get; init; } = "Equals";
    [JsonConverter(typeof(FlexibleStringJsonConverter))]
    public string? Value { get; init; }
}

public sealed class MatchingCriteriaDefinition
{
    public string MatchType { get; init; } = "";
    public decimal MinimumMatchScore { get; init; }
    public List<MatchingPropertyDefinition> Properties { get; init; } = [];
}

public sealed class MatchingPropertyDefinition
{
    public string PropertyPath { get; init; } = "";
    public string Comparison { get; init; } = "Exact";
    public decimal MinimumPropertyScore { get; init; }
    public decimal Weight { get; init; } = 1;
}

public sealed class ConditionDefinition
{
    public string Type { get; init; } = "";
    public string? Field { get; init; }
    [JsonConverter(typeof(FlexibleStringJsonConverter))]
    public string? Value { get; init; }
    public decimal? NumericValue { get; init; }
    public List<string> Values { get; init; } = [];
    public List<string> AllowedValues { get; init; } = [];
    public string? LookupEntity { get; init; }
    public string? LookupField { get; init; }
    public string? ChildEntity { get; init; }
    public string? ChildForeignKey { get; init; }
    public string? ParentKey { get; init; }
    public string? FromField { get; init; }
    public string? ToField { get; init; }
    public string? LeftField { get; init; }
    public string? RightField { get; init; }
}

public sealed class PropertyDefinition
{
    public string Name { get; init; } = "";
    public string Type { get; init; } = "string";
    public bool IsKey { get; init; }
    public bool Identity { get; init; }
    public bool Required { get; init; }
    public bool Unique { get; init; }
    public bool Index { get; init; }
    public int? MinLength { get; init; }
    public int? MaxLength { get; init; }
    public string? Regex { get; init; }
    public bool Email { get; init; }
    public decimal? MinValue { get; init; }
    public decimal? MaxValue { get; init; }
    public List<string> AllowedValues { get; init; } = [];
}

public sealed class OperationDefinition
{
    public string Name { get; init; } = "";
    public string Type { get; init; } = "";
}

public sealed class RelationshipDefinition
{
    public string Name { get; init; } = "";
    public string Type { get; init; } = "OneToMany";
    public string From { get; init; } = "";
    public string To { get; init; } = "";
    public string? ForeignKey { get; init; }
}

public sealed record GenerationResult(
    string SolutionName,
    string OutputFolder,
    IReadOnlyList<string> Projects,
    IReadOnlyList<string> Files);

internal sealed class FlexibleStringJsonConverter : JsonConverter<string?>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.TokenType switch
        {
            JsonTokenType.String => reader.GetString(),
            JsonTokenType.Number => ReadNumberAsString(ref reader),
            JsonTokenType.True => bool.TrueString,
            JsonTokenType.False => bool.FalseString,
            JsonTokenType.Null => null,
            _ => throw new JsonException($"Cannot convert token {reader.TokenType} to string.")
        };

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStringValue(value);
    }

    private static string ReadNumberAsString(ref Utf8JsonReader reader)
    {
        if (reader.TryGetInt64(out var longValue))
        {
            return longValue.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        return reader.GetDouble().ToString(System.Globalization.CultureInfo.InvariantCulture);
    }
}
