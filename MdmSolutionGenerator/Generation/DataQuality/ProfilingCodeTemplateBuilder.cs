using System.Text;

namespace MdmSolutionGenerator.Generation.DataQuality;

internal sealed class ProfilingCodeTemplateBuilder(string rootNamespace)
{
    private readonly LinqExpressionTemplateProvider _linq = new();

    public string BuildProfiler(BusinessObjectDefinition businessObject, IReadOnlyList<ProfilingIntent> intents)
    {
        var builder = new StringBuilder();
        builder.AppendLine("using System.Text.Json;");
        builder.AppendLine("using Microsoft.EntityFrameworkCore;");
        builder.AppendLine($"using {rootNamespace}.Application.Common;");
        builder.AppendLine($"using {rootNamespace}.Core.DataQuality;");
        builder.AppendLine();
        builder.AppendLine($"namespace {rootNamespace}.Application.Modules.{businessObject.Name}.DataQuality.Services;");
        builder.AppendLine();
        builder.AppendLine($"public sealed class {businessObject.Name}Profiler(IAnalysisDbContext dbContext)");
        builder.AppendLine("{");
        builder.AppendLine("    private readonly IAnalysisDbContext _dbContext = dbContext;");
        builder.AppendLine();
        builder.AppendLine("    public async Task ExecuteAsync(Guid runId, CancellationToken cancellationToken)");
        builder.AppendLine("    {");
        foreach (var intent in intents)
        {
            builder.AppendLine($"        await {ProfileMethodName(intent)}Async(runId, cancellationToken);");
        }
        builder.AppendLine("    }");
        builder.AppendLine();
        foreach (var intent in intents)
        {
            builder.AppendLine(BuildProfilingMethod(intent));
        }
        builder.AppendLine("}");
        return builder.ToString();
    }

    private string BuildProfilingMethod(ProfilingIntent intent)
    {
        if (IsDuplicate(intent))
        {
            return BuildDuplicateProfilingMethod(intent);
        }

        if (IsDistinctCount(intent))
        {
            return BuildDistinctCountProfilingMethod(intent);
        }

        if (IsNumericAggregate(intent))
        {
            return BuildNumericAggregateProfilingMethod(intent);
        }

        var method = ProfileMethodName(intent);
        var fieldValue = FieldValueExpression(intent.FieldName, intent.IsFieldString);
        var whereClause = _linq.BuildWhereClause(intent);
        var drilldownBlock = intent.StoreDrilldown ? BuildDrilldownBlock(intent, fieldValue) : "";

        return $$"""
    private async Task {{method}}Async(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.{{intent.DbSetName}}.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.{{intent.DbSetName}}
            {{whereClause}}
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "{{Escape(intent.BusinessObjectName)}}",
            EntityName = "{{Escape(intent.EntityName)}}",
            ColumnName = "{{Escape(intent.ColumnName)}}",
            SummaryCode = "{{Escape(intent.SummaryCode)}}",
            SummaryType = "{{Escape(intent.SummaryType)}}",
            Label = "{{Escape(intent.Label)}}",
            Severity = "{{Escape(intent.Severity)}}",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = {{Bool(intent.StoreDrilldown)}},
            DrilldownKey = "{{Escape(intent.SummaryCode)}}",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);
{{drilldownBlock}}

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

""";
    }

    private string BuildDuplicateProfilingMethod(ProfilingIntent intent)
    {
        var method = ProfileMethodName(intent);
        var fieldValue = FieldValueExpression(intent.FieldName, intent.IsFieldString);
        var field = intent.FieldName ?? intent.PrimaryKey;
        var notEmptyFilter = intent.IsFieldString
            ? $".Where(x => x.{field} != null && x.{field} != \"\")"
            : ".Where(x => true)";
        var drilldownBlock = intent.StoreDrilldown ? BuildDrilldownBlock(intent, fieldValue) : "";

        return $$"""
    private async Task {{method}}Async(Guid runId, CancellationToken cancellationToken)
    {
        var duplicateValues = await _dbContext.{{intent.DbSetName}}
            {{notEmptyFilter}}
            .GroupBy(x => x.{{field}})
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToListAsync(cancellationToken);

        var affectedSourceRecords = await _dbContext.{{intent.DbSetName}}
            .Where(x => duplicateValues.Contains(x.{{field}}))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "{{Escape(intent.BusinessObjectName)}}",
            EntityName = "{{Escape(intent.EntityName)}}",
            ColumnName = "{{Escape(intent.ColumnName)}}",
            SummaryCode = "{{Escape(intent.SummaryCode)}}",
            SummaryType = "{{Escape(intent.SummaryType)}}",
            Label = "{{Escape(intent.Label)}}",
            Severity = "{{Escape(intent.Severity)}}",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = {{Bool(intent.StoreDrilldown)}},
            DrilldownKey = "{{Escape(intent.SummaryCode)}}",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);
{{drilldownBlock}}

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

""";
    }

    private string BuildDistinctCountProfilingMethod(ProfilingIntent intent)
    {
        var method = ProfileMethodName(intent);
        var field = intent.FieldName ?? intent.PrimaryKey;

        return $$"""
    private async Task {{method}}Async(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.{{intent.DbSetName}}
            .Select(x => x.{{field}})
            .Distinct()
            .CountAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "{{Escape(intent.BusinessObjectName)}}",
            EntityName = "{{Escape(intent.EntityName)}}",
            ColumnName = "{{Escape(intent.ColumnName)}}",
            SummaryCode = "{{Escape(intent.SummaryCode)}}",
            SummaryType = "{{Escape(intent.SummaryType)}}",
            Label = "{{Escape(intent.Label)}}",
            Severity = "{{Escape(intent.Severity)}}",
            MetricValue = metricValue,
            AffectedCount = metricValue,
            HasDrilldown = false,
            DrilldownKey = "{{Escape(intent.SummaryCode)}}",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

""";
    }

    private string BuildNumericAggregateProfilingMethod(ProfilingIntent intent)
    {
        var method = ProfileMethodName(intent);
        var field = intent.FieldName ?? intent.PrimaryKey;
        var metricExpression = NumericAggregateExpression(intent, field);
        var notNullFilter = intent.IsFieldNullable ? $".Where(x => x.{field} != null)" : ".Where(x => true)";

        return $$"""
    private async Task {{method}}Async(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.{{intent.DbSetName}}
            {{notNullFilter}}
            .Select(x => (decimal?)x.{{field}})
            {{metricExpression}};

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "{{Escape(intent.BusinessObjectName)}}",
            EntityName = "{{Escape(intent.EntityName)}}",
            ColumnName = "{{Escape(intent.ColumnName)}}",
            SummaryCode = "{{Escape(intent.SummaryCode)}}",
            SummaryType = "{{Escape(intent.SummaryType)}}",
            Label = "{{Escape(intent.Label)}}",
            Severity = "{{Escape(intent.Severity)}}",
            MetricValue = metricValue ?? 0,
            AffectedCount = 0,
            HasDrilldown = false,
            DrilldownKey = "{{Escape(intent.SummaryCode)}}",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

""";
    }

    private static string BuildDrilldownBlock(ProfilingIntent intent, string fieldValue) => $$"""

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "{{Escape(intent.BusinessObjectName)}}",
            EntityName = "{{Escape(intent.EntityName)}}",
            RootRecordId = {{RootRecordIdExpression(intent)}},
            RecordId = x.{{intent.PrimaryKey}}.ToString(),
            ColumnName = "{{Escape(intent.ColumnName)}}",
            SummaryCode = "{{Escape(intent.SummaryCode)}}",
            SummaryType = "{{Escape(intent.SummaryType)}}",
            FieldValue = {{fieldValue}},
            Message = "{{Escape(intent.Label)}}",
            RecordSnapshotJson = JsonSerializer.Serialize(new { {{SnapshotFields(intent)}} }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
""";

    private static string ProfileMethodName(ProfilingIntent intent)
        => $"Profile{Sanitize(intent.EntityName)}{Sanitize(intent.FieldName)}{Sanitize(intent.SummaryType)}";

    private static bool IsDuplicate(ProfilingIntent intent)
        => intent.ConditionType.Equals("Duplicate", StringComparison.OrdinalIgnoreCase)
            || intent.SummaryType.Contains("Duplicate", StringComparison.OrdinalIgnoreCase);

    private static bool IsDistinctCount(ProfilingIntent intent)
        => intent.ConditionType.Equals("DistinctCount", StringComparison.OrdinalIgnoreCase)
            || intent.SummaryType.Equals("DistinctCount", StringComparison.OrdinalIgnoreCase);

    private static bool IsNumericAggregate(ProfilingIntent intent)
        => IsNumericField(intent)
            && (intent.ConditionType.Equals("AverageValue", StringComparison.OrdinalIgnoreCase)
                || intent.ConditionType.Equals("MinValue", StringComparison.OrdinalIgnoreCase)
                || intent.ConditionType.Equals("MaxValue", StringComparison.OrdinalIgnoreCase)
                || intent.SummaryType.Equals("AverageValue", StringComparison.OrdinalIgnoreCase)
                || intent.SummaryType.Equals("MinValue", StringComparison.OrdinalIgnoreCase)
                || intent.SummaryType.Equals("MaxValue", StringComparison.OrdinalIgnoreCase));

    private static bool IsNumericField(ProfilingIntent intent)
        => (intent.FieldType ?? "").Equals("decimal", StringComparison.OrdinalIgnoreCase);

    private static string NumericAggregateExpression(ProfilingIntent intent, string field)
    {
        if (intent.ConditionType.Equals("MinValue", StringComparison.OrdinalIgnoreCase)
            || intent.SummaryType.Equals("MinValue", StringComparison.OrdinalIgnoreCase))
        {
            return ".MinAsync(cancellationToken)";
        }

        if (intent.ConditionType.Equals("MaxValue", StringComparison.OrdinalIgnoreCase)
            || intent.SummaryType.Equals("MaxValue", StringComparison.OrdinalIgnoreCase))
        {
            return ".MaxAsync(cancellationToken)";
        }

        return ".AverageAsync(cancellationToken)";
    }

    private static string RootRecordIdExpression(ProfilingIntent intent)
        => string.Equals(intent.EntityName, intent.RootEntityName, StringComparison.OrdinalIgnoreCase)
            ? $"x.{intent.PrimaryKey}.ToString()"
            : string.IsNullOrWhiteSpace(intent.ParentForeignKey) ? "null" : $"x.{intent.ParentForeignKey}.ToString()";

    private static string SnapshotFields(ProfilingIntent intent)
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
        => string.Concat((value ?? "Records").Where(char.IsLetterOrDigit));

    private static string Bool(bool value) => value ? "true" : "false";

    private static string Escape(string? value)
        => (value ?? "").Replace("\\", "\\\\", StringComparison.Ordinal).Replace("\"", "\\\"", StringComparison.Ordinal);
}
