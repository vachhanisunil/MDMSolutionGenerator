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
        var method = ProfileMethodName(intent);
        var fieldValue = FieldValueExpression(intent.FieldName, intent.IsFieldString);
        var whereClause = _linq.BuildWhereClause(intent);

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

        if ({{Bool(intent.StoreDrilldown)}})
        {
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
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

""";
    }

    private static string ProfileMethodName(ProfilingIntent intent)
        => $"Profile{Sanitize(intent.EntityName)}{Sanitize(intent.FieldName)}{Sanitize(intent.SummaryType)}";

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
