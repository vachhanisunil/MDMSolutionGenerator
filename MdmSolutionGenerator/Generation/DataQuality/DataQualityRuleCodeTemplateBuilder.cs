using System.Text;

namespace MdmSolutionGenerator.Generation.DataQuality;

internal sealed class DataQualityRuleCodeTemplateBuilder(string rootNamespace)
{
    private readonly LinqExpressionTemplateProvider _linq = new();

    public string BuildRuleExecutor(BusinessObjectDefinition businessObject, IReadOnlyList<DataQualityRuleIntent> intents)
    {
        var builder = new StringBuilder();
        builder.AppendLine("using System.Text.Json;");
        builder.AppendLine("using Microsoft.EntityFrameworkCore;");
        builder.AppendLine($"using {rootNamespace}.Application.Common;");
        builder.AppendLine($"using {rootNamespace}.Core.DataQuality;");
        builder.AppendLine();
        builder.AppendLine($"namespace {rootNamespace}.Application.Modules.{businessObject.Name}.DataQuality.Services;");
        builder.AppendLine();
        builder.AppendLine($"public sealed class {businessObject.Name}DataQualityRuleExecutor(IAnalysisDbContext dbContext)");
        builder.AppendLine("{");
        builder.AppendLine("    private readonly IAnalysisDbContext _dbContext = dbContext;");
        builder.AppendLine();
        builder.AppendLine("    public async Task ExecuteAsync(Guid runId, CancellationToken cancellationToken)");
        builder.AppendLine("    {");
        foreach (var intent in intents)
        {
            builder.AppendLine($"        await {RuleMethodName(intent)}Async(runId, cancellationToken);");
        }
        builder.AppendLine("    }");
        builder.AppendLine();
        foreach (var intent in intents)
        {
            builder.AppendLine(intent.RuleType.Equals("CustomCodeRule", StringComparison.OrdinalIgnoreCase)
                ? BuildCustomRuleMethod(intent)
                : BuildRuleMethod(intent));
        }
        builder.AppendLine("}");
        return builder.ToString();
    }

    private string BuildRuleMethod(DataQualityRuleIntent intent)
    {
        var method = RuleMethodName(intent);
        var declaration = _linq.BuildAllowedValuesDeclaration(intent);
        var whereClause = BuildWhereClause(intent);
        var fieldValue = FieldValueExpression(intent.FieldName, intent.IsFieldString);

        return $$"""
    private async Task {{method}}Async(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.{{intent.DbSetName}}.CountAsync(cancellationToken);
{{Indent(declaration, 8)}}
        var failedSourceRecords = await _dbContext.{{intent.DbSetName}}
            {{whereClause}}
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "{{Escape(intent.BusinessObjectName)}}",
            RuleCode = "{{Escape(intent.RuleCode)}}",
            RuleName = "{{Escape(intent.RuleName)}}",
            EntityName = "{{Escape(intent.EntityName)}}",
            Category = "{{Escape(intent.Category)}}",
            Severity = "{{Escape(intent.Severity)}}",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            ResultId = result.ResultId,
            BusinessObjectName = "{{Escape(intent.BusinessObjectName)}}",
            EntityName = "{{Escape(intent.EntityName)}}",
            RootRecordId = {{RootRecordIdExpression(intent)}},
            RecordId = x.{{intent.PrimaryKey}}.ToString(),
            RuleCode = "{{Escape(intent.RuleCode)}}",
            FieldName = "{{Escape(intent.FieldName)}}",
            Message = "{{Escape(intent.Message)}}",
            Severity = "{{Escape(intent.Severity)}}",
            Status = "Open",
            FieldValue = {{fieldValue}},
            RecordSnapshotJson = JsonSerializer.Serialize(new { {{SnapshotFields(intent)}} }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

""";
    }

    private static string BuildCustomRuleMethod(DataQualityRuleIntent intent) => $$"""
    private async Task {{RuleMethodName(intent)}}Async(Guid runId, CancellationToken cancellationToken)
    {
        // TODO: Implement custom business rule logic here.
        // This rule requires custom logic because it cannot be generated safely from metadata alone.
        await Task.CompletedTask;
    }

""";

    private string BuildWhereClause(DataQualityRuleIntent intent)
    {
        if (IsDateRangeRule(intent))
        {
            return string.IsNullOrWhiteSpace(intent.FromField) || string.IsNullOrWhiteSpace(intent.ToField)
                ? ".Where(x => false)"
                : $".Where(x => x.{intent.ToField} < x.{intent.FromField})";
        }

        return _linq.BuildWhereClause(intent);
    }

    private static bool IsDateRangeRule(DataQualityRuleIntent intent)
        => ContainsDateRange(intent.ConditionType)
            || ContainsDateRange(intent.RuleType)
            || ContainsDateRange(intent.RuleName)
            || ContainsDateRange(intent.RuleCode);

    private static bool ContainsDateRange(string? value)
        => !string.IsNullOrWhiteSpace(value)
            && value.Replace("_", "", StringComparison.Ordinal).Contains("DateRange", StringComparison.OrdinalIgnoreCase);

    private static string RuleMethodName(DataQualityRuleIntent intent)
        => $"Execute{Sanitize(intent.RuleCode)}Rule";

    private static string RootRecordIdExpression(DataQualityRuleIntent intent)
        => string.Equals(intent.EntityName, intent.RootEntityName, StringComparison.OrdinalIgnoreCase)
            ? $"x.{intent.PrimaryKey}.ToString()"
            : string.IsNullOrWhiteSpace(intent.ParentForeignKey) ? "null" : $"x.{intent.ParentForeignKey}.ToString()";

    private static string SnapshotFields(DataQualityRuleIntent intent)
    {
        var fields = new List<string> { $"x.{intent.PrimaryKey}" };
        if (!string.IsNullOrWhiteSpace(intent.ParentForeignKey) && !fields.Contains($"x.{intent.ParentForeignKey}"))
        {
            fields.Add($"x.{intent.ParentForeignKey}");
        }
        if (!string.IsNullOrWhiteSpace(intent.FieldName) && !fields.Contains($"x.{intent.FieldName}"))
        {
            fields.Add($"x.{intent.FieldName}");
        }
        return string.Join(", ", fields);
    }

    private static string FieldValueExpression(string? fieldName, bool isFieldString)
    {
        if (string.IsNullOrWhiteSpace(fieldName))
        {
            return "null";
        }

        return isFieldString ? $"x.{fieldName}" : $"x.{fieldName}.ToString()";
    }

    private static string Sanitize(string? value)
        => string.Concat((value ?? "Rule").Where(char.IsLetterOrDigit));

    private static string Indent(string value, int spaces)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "";
        }

        var prefix = new string(' ', spaces);
        return prefix + value;
    }

    private static string Escape(string? value)
        => (value ?? "").Replace("\\", "\\\\", StringComparison.Ordinal).Replace("\"", "\\\"", StringComparison.Ordinal);
}
