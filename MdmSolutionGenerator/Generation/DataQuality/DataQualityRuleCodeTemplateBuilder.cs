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
                : intent.IsDuplicateMatchingRule
                    ? BuildDuplicateMatchingRuleMethod(intent)
                : BuildRuleMethod(intent));
        }
        builder.AppendLine("}");
        return builder.ToString();
    }

    private string BuildDuplicateMatchingRuleMethod(DataQualityRuleIntent intent)
    {
        var method = RuleMethodName(intent);
        var sql = BuildDuplicateMatchingSql(intent);

        return $$"""
    private async Task {{method}}Async(Guid runId, CancellationToken cancellationToken)
    {
        var duplicateRows = await _dbContext.DuplicateCandidateRows
            .FromSqlRaw({{VerbatimString(sql)}})
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
            Status = duplicateRows.Any() ? "Failed" : "Passed",
            AffectedCount = duplicateRows.Count,
            Score = duplicateRows.Count == 0 ? 100m : 0m,
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var duplicateDrilldowns = duplicateRows.Select(row => new DataQualityDuplicateDrilldown
        {
            DuplicateDrilldownId = Guid.NewGuid(),
            RunId = runId,
            ResultId = result.ResultId,
            BusinessObjectName = "{{Escape(intent.BusinessObjectName)}}",
            RuleCode = "{{Escape(intent.RuleCode)}}",
            RuleName = "{{Escape(intent.RuleName)}}",
            EntityName = "{{Escape(intent.EntityName)}}",
            SourceRootRecordId = row.SourceRootRecordId,
            SourceRecordId = row.SourceRecordId,
            SourceDisplayValue = row.SourceDisplayValue,
            DuplicateRootRecordId = row.DuplicateRootRecordId,
            DuplicateRecordId = row.DuplicateRecordId,
            DuplicateDisplayValue = row.DuplicateDisplayValue,
            MatchScore = row.MatchScore,
            MatchStatus = "PotentialDuplicate",
            Severity = "{{Escape(intent.Severity)}}",
            Message = $"Potential duplicate {{Escape(intent.BusinessObjectName)}} found. Match score: {row.MatchScore:0.##}",
            MatchedFieldJson = row.MatchedFieldJson,
            SourceRecordSnapshotJson = row.SourceRecordSnapshotJson,
            DuplicateRecordSnapshotJson = row.DuplicateRecordSnapshotJson,
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDuplicateDrilldowns.AddRange(duplicateDrilldowns);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

""";
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
            RuleSummaryId = result.ResultId,
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

    private static string BuildDuplicateMatchingSql(DataQualityRuleIntent intent)
    {
        var rootTable = QuoteIdentifier(Naming.Plural(intent.RootEntityName));
        const string sourceRootAlias = "source_root";
        const string duplicateRootAlias = "duplicate_root";
        var childEntities = intent.DuplicateMatchProperties
            .Where(property => !property.EntityName.Equals(intent.RootEntityName, StringComparison.OrdinalIgnoreCase))
            .Select(property => property.EntityName)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        var joins = new StringBuilder();
        foreach (var childEntity in childEntities)
        {
            var sourceAlias = Alias(childEntity, "source");
            var duplicateAlias = Alias(childEntity, "duplicate");
            var childTable = QuoteIdentifier(Naming.Plural(childEntity));
            var parentForeignKey = QuoteIdentifier($"{intent.RootEntityName}Id");
            joins.AppendLine($"JOIN {childTable} {sourceAlias} ON {sourceAlias}.{parentForeignKey} = {sourceRootAlias}.\"{intent.RootKey}\"");
            joins.AppendLine($"JOIN {childTable} {duplicateAlias} ON {duplicateAlias}.{parentForeignKey} = {duplicateRootAlias}.\"{intent.RootKey}\"");
        }

        var totalWeight = intent.DuplicateMatchProperties.Sum(property => property.Weight);
        if (totalWeight <= 0)
        {
            totalWeight = 1;
        }

        var scoreTerms = intent.DuplicateMatchProperties
            .Select(property => $"({ScoreExpression(intent, property)} * {SqlDecimal(property.Weight)})")
            .ToList();
        var scoreExpression = $"(({string.Join(" + ", scoreTerms)}) / {SqlDecimal(totalWeight)})";
        var matchConditions = intent.DuplicateMatchProperties
            .Where(property => property.MinimumPropertyScore > 0)
            .Select(property => $"{ScoreExpression(intent, property)} >= {SqlDecimal(property.MinimumPropertyScore)}")
            .ToList();
        matchConditions.Add($"{scoreExpression} >= {SqlDecimal(intent.MinimumMatchScore)}");

        foreach (var filter in intent.DuplicateFilters)
        {
            var sourceFilter = FilterExpression(intent, filter, source: true);
            var duplicateFilter = FilterExpression(intent, filter, source: false);
            if (!string.IsNullOrWhiteSpace(sourceFilter) && !string.IsNullOrWhiteSpace(duplicateFilter))
            {
                matchConditions.Add(sourceFilter);
                matchConditions.Add(duplicateFilter);
            }
        }

        var matchedFieldJson = $"jsonb_build_array({string.Join(", ", intent.DuplicateMatchProperties.Select(property => MatchedFieldJsonExpression(intent, property)))})::text";
        var sourceSnapshot = SnapshotJsonExpression(intent, source: true);
        var duplicateSnapshot = SnapshotJsonExpression(intent, source: false);
        var displayField = intent.DuplicateMatchProperties.FirstOrDefault(property => property.EntityName.Equals(intent.RootEntityName, StringComparison.OrdinalIgnoreCase))?.FieldName ?? intent.RootKey;

        return $$"""
SELECT
    {{sourceRootAlias}}."{{intent.RootKey}}"::text AS "SourceRootRecordId",
    {{sourceRootAlias}}."{{intent.RootKey}}"::text AS "SourceRecordId",
    COALESCE({{sourceRootAlias}}.{{QuoteIdentifier(displayField)}}::text, {{sourceRootAlias}}."{{intent.RootKey}}"::text) AS "SourceDisplayValue",
    {{duplicateRootAlias}}."{{intent.RootKey}}"::text AS "DuplicateRootRecordId",
    {{duplicateRootAlias}}."{{intent.RootKey}}"::text AS "DuplicateRecordId",
    COALESCE({{duplicateRootAlias}}.{{QuoteIdentifier(displayField)}}::text, {{duplicateRootAlias}}."{{intent.RootKey}}"::text) AS "DuplicateDisplayValue",
    ROUND({{scoreExpression}}, 2) AS "MatchScore",
    {{matchedFieldJson}} AS "MatchedFieldJson",
    {{sourceSnapshot}} AS "SourceRecordSnapshotJson",
    {{duplicateSnapshot}} AS "DuplicateRecordSnapshotJson"
FROM {{rootTable}} {{sourceRootAlias}}
JOIN {{rootTable}} {{duplicateRootAlias}} ON {{sourceRootAlias}}."{{intent.RootKey}}" < {{duplicateRootAlias}}."{{intent.RootKey}}"
{{joins.ToString().TrimEnd()}}
WHERE {{string.Join($"{Environment.NewLine}  AND ", matchConditions)}}
""";
    }

    private static string ScoreExpression(DataQualityRuleIntent intent, DuplicateMatchPropertyIntent property)
    {
        var sourceField = FieldReference(intent, property, source: true);
        var duplicateField = FieldReference(intent, property, source: false);
        return property.Comparison.Equals("Fuzzy", StringComparison.OrdinalIgnoreCase)
            ? $"(similarity(COALESCE({sourceField}::text, ''), COALESCE({duplicateField}::text, '')) * 100)"
            : $"(CASE WHEN COALESCE({sourceField}::text, '') = COALESCE({duplicateField}::text, '') THEN 100 ELSE 0 END)";
    }

    private static string MatchedFieldJsonExpression(DataQualityRuleIntent intent, DuplicateMatchPropertyIntent property)
    {
        var score = ScoreExpression(intent, property);
        var sourceField = FieldReference(intent, property, source: true);
        var duplicateField = FieldReference(intent, property, source: false);
        return $"jsonb_build_object('propertyPath', '{SqlString(property.PropertyPath)}', 'comparison', '{SqlString(property.Comparison)}', 'sourceValue', {sourceField}::text, 'duplicateValue', {duplicateField}::text, 'score', ROUND({score}, 2), 'weight', {SqlDecimal(property.Weight)})";
    }

    private static string SnapshotJsonExpression(DataQualityRuleIntent intent, bool source)
    {
        const string sourceRootAlias = "source_root";
        const string duplicateRootAlias = "duplicate_root";
        var rootAlias = source ? sourceRootAlias : duplicateRootAlias;
        var values = new List<string>
        {
            $"'Id', {rootAlias}.\"{intent.RootKey}\""
        };

        foreach (var property in intent.DuplicateMatchProperties)
        {
            values.Add($"'{SqlString(property.PropertyPath)}'");
            values.Add(FieldReference(intent, property, source));
        }

        return $"jsonb_build_object({string.Join(", ", values)})::text";
    }

    private static string FieldReference(DataQualityRuleIntent intent, DuplicateMatchPropertyIntent property, bool source)
    {
        var alias = property.EntityName.Equals(intent.RootEntityName, StringComparison.OrdinalIgnoreCase)
            ? source ? "source_root" : "duplicate_root"
            : Alias(property.EntityName, source ? "source" : "duplicate");
        return $"{alias}.{QuoteIdentifier(property.FieldName)}";
    }

    private static string FilterExpression(DataQualityRuleIntent intent, DuplicateFilterIntent filter, bool source)
    {
        var field = filter.EntityName.Equals(intent.RootEntityName, StringComparison.OrdinalIgnoreCase)
            ? $"{(source ? "source_root" : "duplicate_root")}.{QuoteIdentifier(filter.FieldName)}"
            : $"{Alias(filter.EntityName, source ? "source" : "duplicate")}.{QuoteIdentifier(filter.FieldName)}";
        var value = $"'{SqlString(filter.Value ?? "")}'";
        return filter.Operator switch
        {
            "NotEquals" => $"{field}::text <> {value}",
            "Equals" => $"{field}::text = {value}",
            _ => ""
        };
    }

    private static string Alias(string entityName, string prefix)
        => $"{prefix}_{entityName.ToLowerInvariant()}";

    private static string QuoteIdentifier(string identifier)
        => $"\"{identifier.Replace("\"", "\"\"", StringComparison.Ordinal)}\"";

    private static string SqlString(string value)
        => value.Replace("'", "''", StringComparison.Ordinal);

    private static string SqlDecimal(decimal value)
        => value.ToString(System.Globalization.CultureInfo.InvariantCulture);

    private static string VerbatimString(string value)
        => "@\"" + value.Replace("\"", "\"\"", StringComparison.Ordinal) + "\"";

    private string BuildWhereClause(DataQualityRuleIntent intent)
    {
        if (IsDateRangeRule(intent))
        {
            return string.IsNullOrWhiteSpace(intent.FromField) || string.IsNullOrWhiteSpace(intent.ToField)
                ? ".Where(x => false)"
                : $".Where(x => x.{intent.ToField} < x.{intent.FromField})";
        }

        if (intent.ConditionType.Equals("LookupExists", StringComparison.OrdinalIgnoreCase))
        {
            return string.IsNullOrWhiteSpace(intent.FieldName) || string.IsNullOrWhiteSpace(intent.LookupDbSetName)
                ? ".Where(x => false)"
                : $".Where(x => !_dbContext.{intent.LookupDbSetName}.Any(l => l.{intent.LookupKey} == x.{intent.FieldName}))";
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
