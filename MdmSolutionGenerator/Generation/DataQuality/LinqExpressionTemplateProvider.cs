namespace MdmSolutionGenerator.Generation.DataQuality;

internal sealed class LinqExpressionTemplateProvider
{
    public string BuildWhereClause(ProfilingIntent intent)
        => BuildWhereClause(intent.ConditionType, intent.FieldName, null, [], intent.IsFieldString, intent.IsFieldNullable);

    public string BuildWhereClause(DataQualityRuleIntent intent)
        => BuildWhereClause(intent.ConditionType, intent.FieldName, intent.ComparisonValue, intent.AllowedValues, intent.IsFieldString, intent.IsFieldNullable);

    public string BuildDuplicateKeySelector(string? fieldName)
        => string.IsNullOrWhiteSpace(fieldName) ? "x.Id" : $"x.{fieldName}";

    public string BuildAllowedValuesDeclaration(DataQualityRuleIntent intent)
    {
        if (!intent.ConditionType.Equals("AllowedValues", StringComparison.OrdinalIgnoreCase) || intent.AllowedValues.Count == 0)
        {
            return "";
        }

        var values = string.Join(", ", intent.AllowedValues.Select(value => $"\"{Escape(value)}\""));
        return $"var allowedValues = new[] {{ {values} }};";
    }

    private static string BuildWhereClause(string conditionType, string? fieldName, string? comparisonValue, IReadOnlyList<string> allowedValues, bool isFieldString, bool isFieldNullable)
    {
        if (string.IsNullOrWhiteSpace(fieldName))
        {
            return conditionType switch
            {
                "CountAll" => ".Where(x => true)",
                "TotalRecords" => ".Where(x => true)",
                "TotalRootObjects" => ".Where(x => true)",
                "DistinctCount" => ".Where(x => true)",
                "Duplicate" => ".Where(x => true)",
                "LookupExists" => ".Where(x => true)",
                "AtLeastOneChild" => ".Where(x => true)",
                "NoDuplicateCombination" => ".Where(x => true)",
                "ChildCount" => ".Where(x => true)",
                _ => ".Where(x => false)"
            };
        }

        var field = fieldName;
        return conditionType switch
        {
            "IsNullOrEmpty" when isFieldString => $".Where(x => string.IsNullOrEmpty(x.{field}))",
            "IsNullOrEmpty" when isFieldNullable => $".Where(x => x.{field} == null)",
            "IsNullOrEmpty" => ".Where(x => false)",
            "IsNull" when isFieldNullable || isFieldString => $".Where(x => x.{field} == null)",
            "IsNull" => ".Where(x => false)",
            "IsNotNull" when isFieldNullable || isFieldString => $".Where(x => x.{field} != null)",
            "IsNotNull" => ".Where(x => true)",
            "LessThan" => $".Where(x => x.{field} < {Literal(comparisonValue)})",
            "LessThanOrEqual" => $".Where(x => x.{field} <= {Literal(comparisonValue)})",
            "GreaterThan" => $".Where(x => x.{field} > {Literal(comparisonValue)})",
            "GreaterThanOrEqual" => $".Where(x => x.{field} >= {Literal(comparisonValue)})",
            "Equals" => $".Where(x => x.{field} == {Literal(comparisonValue)})",
            "NotEquals" => $".Where(x => x.{field} != {Literal(comparisonValue)})",
            "AllowedValues" => allowedValues.Count == 0
                ? ".Where(x => false)"
                : isFieldString
                    ? $".Where(x => x.{field} != null && !allowedValues.Contains(x.{field}))"
                    : $".Where(x => !allowedValues.Contains(x.{field}.ToString()))",
            "Regex" when isFieldString => $".Where(x => x.{field} != null)",
            "Regex" => ".Where(x => false)",
            "EmailFormat" when isFieldString => $".Where(x => x.{field} != null && !x.{field}.Contains(\"@\"))",
            "EmailFormat" => ".Where(x => false)",
            "CountAll" => ".Where(x => true)",
            "TotalRecords" => ".Where(x => true)",
            "TotalRootObjects" => ".Where(x => true)",
            "DateRangeValid" => ".Where(x => false)",
            "DistinctCount" => ".Where(x => true)",
            "MinLength" => $".Where(x => x.{field} != null)",
            "MaxLength" => $".Where(x => x.{field} != null)",
            "MinValue" => $".Where(x => x.{field} != null)",
            "MaxValue" => $".Where(x => x.{field} != null)",
            "AverageValue" => $".Where(x => x.{field} != null)",
            "Duplicate" => ".Where(x => true)",
            "LookupExists" => ".Where(x => true)",
            "AtLeastOneChild" => ".Where(x => true)",
            "NoDuplicateCombination" => ".Where(x => true)",
            "ChildCount" => ".Where(x => true)",
            _ when isFieldString => $".Where(x => string.IsNullOrEmpty(x.{field}))",
            _ when isFieldNullable => $".Where(x => x.{field} == null)",
            _ => ".Where(x => false)"
        };
    }

    private static string Literal(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "0";
        }

        return decimal.TryParse(value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out _)
            ? value
            : $"\"{Escape(value)}\"";
    }

    private static string Escape(string value)
        => value.Replace("\\", "\\\\", StringComparison.Ordinal).Replace("\"", "\\\"", StringComparison.Ordinal);
}
