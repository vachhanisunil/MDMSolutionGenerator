namespace MdmSolutionGenerator.Generation.DataQuality;

internal sealed class MetadataIntentInterpreter(MetadataDocument metadata)
{
    public IReadOnlyList<ProfilingIntent> GetProfilingIntents(BusinessObjectDefinition businessObject)
    {
        var configured = businessObject.Profiling.Measurements
            .Concat(businessObject.Profiling.Summaries)
            .Where(measurement => !string.IsNullOrWhiteSpace(measurement.Entity))
            .Select(measurement => ToProfilingIntent(businessObject, measurement))
            .Where(intent => intent is not null)
            .Cast<ProfilingIntent>()
            .ToList();

        if (configured.Count > 0)
        {
            return configured;
        }

        if (IsExplicitOnly())
        {
            return [];
        }

        return BusinessObjectEntities(businessObject)
            .SelectMany(entity => entity.Properties
                .Where(property => property.Required && IsString(property) && !IsKey(entity, property))
                .Select(property => BuildProfilingIntent(
                    businessObject,
                    entity,
                    $"{businessObject.Name.ToUpperInvariant()}_{entity.Name.ToUpperInvariant()}_{property.Name.ToUpperInvariant()}_NULL_COUNT",
                    "NullCount",
                    property.Name,
                    "IsNullOrEmpty",
                    $"{entity.Name} {property.Name} missing count",
                    "Medium",
                    storeDrilldown: true)))
            .ToList();
    }

    public IReadOnlyList<DataQualityRuleIntent> GetRuleIntents(BusinessObjectDefinition businessObject)
    {
        var configured = businessObject.DataQualityRules
            .Where(rule => rule.Enabled)
            .Select(rule => ToRuleIntent(businessObject, rule))
            .Where(intent => intent is not null)
            .Cast<DataQualityRuleIntent>()
            .ToList();

        if (configured.Count > 0)
        {
            return configured;
        }

        if (IsExplicitOnly())
        {
            return [];
        }

        return BusinessObjectEntities(businessObject)
            .SelectMany(entity => entity.Properties
                .Where(property => property.Required && IsString(property) && !IsKey(entity, property))
                .Select(property => BuildRuleIntent(
                    businessObject,
                    entity,
                    $"{businessObject.Name.ToUpperInvariant()}_{entity.Name.ToUpperInvariant()}_{property.Name.ToUpperInvariant()}_REQUIRED",
                    $"{entity.Name} {property.Name} is mandatory",
                    "FieldRule",
                    "Completeness",
                    "High",
                    property.Name,
                    "IsNullOrEmpty",
                    $"{entity.Name} {property.Name} is required.")))
            .ToList();
    }

    private ProfilingIntent? ToProfilingIntent(BusinessObjectDefinition businessObject, ProfilingMeasurementDefinition measurement)
    {
        var entity = FindEntity(measurement.Entity);
        var field = measurement.Condition.Field ?? measurement.Field ?? measurement.Column;
        var conditionType = NormalizeConditionType(Coalesce(measurement.Condition.Type, measurement.Type, "IsNullOrEmpty"));
        return entity is null
            ? null
            : BuildProfilingIntent(
                businessObject,
                entity,
                Coalesce(measurement.SummaryCode, measurement.Code, $"{businessObject.Name}_{entity.Name}_{field}_{measurement.SummaryType}").ToUpperInvariant(),
                Coalesce(measurement.SummaryType, measurement.Type, "NullCount"),
                field,
                conditionType,
                Coalesce(measurement.Label, measurement.Name, $"{entity.Name} {field} {measurement.SummaryType}"),
                measurement.Severity,
                measurement.StoreDrilldown);
    }

    private DataQualityRuleIntent? ToRuleIntent(BusinessObjectDefinition businessObject, DataQualityRuleDefinition rule)
    {
        var ruleType = Coalesce(rule.RuleType, rule.Type, "FieldRule");
        if (IsDuplicateMatchingRule(rule, ruleType))
        {
            return ToDuplicateRuleIntent(businessObject, rule, ruleType);
        }

        var entity = FindEntity(rule.Entity);
        if (entity is null)
        {
            return null;
        }

        var field = rule.Condition.Field ?? rule.Field ?? rule.Column;
        var conditionType = NormalizeConditionType(Coalesce(rule.Condition.Type, rule.Type, "IsNullOrEmpty"));
        var intent = BuildRuleIntent(
            businessObject,
            entity,
            Coalesce(rule.RuleCode, rule.RuleId, $"{businessObject.Name}_{entity.Name}_{field}_{rule.Type}").ToUpperInvariant(),
            Coalesce(rule.RuleName, rule.Label, $"{entity.Name} {field} {rule.Type}"),
            ruleType,
            Coalesce(rule.Category, "Completeness"),
            Coalesce(rule.Severity, "Medium"),
            field,
            conditionType,
            Coalesce(rule.Message, $"{entity.Name} {field} failed {rule.Type}."));

        intent.LookupEntityName = rule.Condition.LookupEntity ?? rule.LookupEntity;
        intent.LookupDbSetName = string.IsNullOrWhiteSpace(intent.LookupEntityName) ? null : Naming.Plural(Naming.Pascal(intent.LookupEntityName));
        intent.LookupKey = rule.Condition.LookupField ?? "Id";
        intent.FromField = rule.Condition.FromField ?? rule.Condition.RightField;
        intent.ToField = rule.Condition.ToField ?? rule.Condition.LeftField;
        intent.AllowedValues = rule.Condition.Values.Count > 0
            ? rule.Condition.Values
            : rule.Condition.AllowedValues.Count > 0
                ? rule.Condition.AllowedValues
                : entity.Properties.FirstOrDefault(p => Matches(p.Name, field ?? ""))?.AllowedValues ?? [];
        intent.ComparisonValue = rule.Condition.Value ?? rule.Condition.NumericValue?.ToString(System.Globalization.CultureInfo.InvariantCulture);
        return intent;
    }

    private DataQualityRuleIntent? ToDuplicateRuleIntent(BusinessObjectDefinition businessObject, DataQualityRuleDefinition rule, string ruleType)
    {
        var root = RootEntity(businessObject) ?? FindEntity(rule.Entity) ?? FindEntity(businessObject.Name);
        if (root is null)
        {
            return null;
        }

        var properties = rule.MatchingCriteria.Properties
            .Select(ToDuplicateMatchPropertyIntent)
            .Where(property => property is not null)
            .Cast<DuplicateMatchPropertyIntent>()
            .ToList();

        if (properties.Count == 0)
        {
            return null;
        }

        var filters = rule.Filter.Conditions
            .Select(ToDuplicateFilterIntent)
            .Where(filter => filter is not null)
            .Cast<DuplicateFilterIntent>()
            .ToList();

        var intent = BuildRuleIntent(
            businessObject,
            root,
            Coalesce(rule.RuleCode, rule.RuleId, $"{businessObject.Name}_DUPLICATE_MATCH").ToUpperInvariant(),
            Coalesce(rule.RuleName, rule.Label, $"{businessObject.Name} potential duplicate match"),
            ruleType,
            Coalesce(rule.Category, "Duplication"),
            Coalesce(rule.Severity, "Medium"),
            null,
            "WeightedFuzzyDuplicate",
            Coalesce(rule.Message, rule.Label, "Potential duplicate record found."));

        intent.IsDuplicateMatchingRule = true;
        intent.MinimumMatchScore = rule.MatchingCriteria.MinimumMatchScore <= 0 ? 85 : rule.MatchingCriteria.MinimumMatchScore;
        intent.DuplicateMatchProperties = properties;
        intent.DuplicateFilters = filters;
        return intent;
    }

    private DuplicateMatchPropertyIntent? ToDuplicateMatchPropertyIntent(MatchingPropertyDefinition property)
    {
        var path = ParsePropertyPath(property.PropertyPath);
        if (path is null || FindEntity(path.Value.EntityName) is null)
        {
            return null;
        }

        var entity = FindEntity(path.Value.EntityName)!;
        if (FieldProperty(entity, path.Value.FieldName) is null)
        {
            return null;
        }

        return new DuplicateMatchPropertyIntent
        {
            EntityName = entity.Name,
            FieldName = path.Value.FieldName,
            PropertyPath = $"{entity.Name}.{path.Value.FieldName}",
            Comparison = string.IsNullOrWhiteSpace(property.Comparison) ? "Exact" : property.Comparison,
            MinimumPropertyScore = property.MinimumPropertyScore,
            Weight = property.Weight <= 0 ? 1 : property.Weight
        };
    }

    private DuplicateFilterIntent? ToDuplicateFilterIntent(FilterConditionDefinition condition)
    {
        var path = ParsePropertyPath(condition.PropertyPath);
        if (path is null || FindEntity(path.Value.EntityName) is null)
        {
            return null;
        }

        var entity = FindEntity(path.Value.EntityName)!;
        if (FieldProperty(entity, path.Value.FieldName) is null)
        {
            return null;
        }

        return new DuplicateFilterIntent
        {
            EntityName = entity.Name,
            FieldName = path.Value.FieldName,
            Operator = string.IsNullOrWhiteSpace(condition.Operator) ? "Equals" : condition.Operator,
            Value = condition.Value
        };
    }

    private bool IsExplicitOnly()
        => metadata.AnalysisGenerationMode.Equals("ExplicitOnly", StringComparison.OrdinalIgnoreCase);

    private static bool IsDuplicateMatchingRule(DataQualityRuleDefinition rule, string ruleType)
        => rule.MatchingCriteria.Properties.Count > 0
            || ruleType.Contains("Duplication", StringComparison.OrdinalIgnoreCase)
            || ruleType.Contains("Duplicate", StringComparison.OrdinalIgnoreCase);

    private static string NormalizeConditionType(string conditionType)
        => conditionType switch
        {
            "NotInAllowedValues" => "AllowedValues",
            _ => conditionType
        };

    private ProfilingIntent BuildProfilingIntent(
        BusinessObjectDefinition businessObject,
        EntityDefinition entity,
        string summaryCode,
        string summaryType,
        string? fieldName,
        string conditionType,
        string label,
        string? severity,
        bool storeDrilldown)
    {
        var root = RootEntity(businessObject) ?? entity;
        var field = FieldProperty(entity, fieldName);
        return new ProfilingIntent
        {
            BusinessObjectName = businessObject.Name,
            EntityName = entity.Name,
            DbSetName = Naming.Plural(entity.Name),
            RootEntityName = root.Name,
            PrimaryKey = KeyProperty(entity).Name,
            RootKey = KeyProperty(root).Name,
            ParentForeignKey = ParentForeignKey(entity, root),
            SummaryCode = summaryCode,
            SummaryType = summaryType,
            ColumnName = fieldName,
            ConditionType = conditionType,
            FieldName = fieldName,
            FieldType = field?.Type,
            IsFieldString = field is not null && IsString(field),
            IsFieldNullable = field is null || IsNullable(entity, field),
            StoreDrilldown = storeDrilldown,
            Label = label,
            Severity = severity
        };
    }

    private DataQualityRuleIntent BuildRuleIntent(
        BusinessObjectDefinition businessObject,
        EntityDefinition entity,
        string ruleCode,
        string ruleName,
        string ruleType,
        string category,
        string severity,
        string? fieldName,
        string conditionType,
        string message)
    {
        var root = RootEntity(businessObject) ?? entity;
        var field = FieldProperty(entity, fieldName);
        return new DataQualityRuleIntent
        {
            BusinessObjectName = businessObject.Name,
            EntityName = entity.Name,
            DbSetName = Naming.Plural(entity.Name),
            RootEntityName = root.Name,
            PrimaryKey = KeyProperty(entity).Name,
            RootKey = KeyProperty(root).Name,
            ParentForeignKey = ParentForeignKey(entity, root),
            RuleCode = ruleCode,
            RuleName = ruleName,
            RuleType = ruleType,
            Category = category,
            Severity = severity,
            FieldName = fieldName,
            IsFieldString = field is not null && IsString(field),
            IsFieldNullable = field is null || IsNullable(entity, field),
            ConditionType = conditionType,
            Message = message
        };
    }

    private IEnumerable<EntityDefinition> BusinessObjectEntities(BusinessObjectDefinition businessObject)
    {
        var names = businessObject.Entities.Count == 0
            ? [Naming.Pascal(businessObject.RootEntity ?? businessObject.Entity ?? businessObject.Name)]
            : businessObject.Entities.Select(Naming.Pascal).ToList();

        return metadata.Entities.Where(entity => names.Any(name => Matches(name, entity.Name)));
    }

    private EntityDefinition? RootEntity(BusinessObjectDefinition businessObject)
        => FindEntity(businessObject.RootEntity ?? businessObject.Entity ?? businessObject.Name);

    private EntityDefinition? FindEntity(string? entityName)
        => string.IsNullOrWhiteSpace(entityName)
            ? null
            : metadata.Entities.FirstOrDefault(entity => Matches(entity.Name, entityName));

    private string? ParentForeignKey(EntityDefinition entity, EntityDefinition root)
        => Matches(entity.Name, root.Name)
            ? null
            : metadata.Relationships.FirstOrDefault(relationship => Matches(relationship.From, entity.Name) && Matches(relationship.To, root.Name))?.ForeignKey;

    private static PropertyDefinition KeyProperty(EntityDefinition entity)
        => entity.Properties.FirstOrDefault(property => IsKey(entity, property))
            ?? entity.Properties.FirstOrDefault(property => property.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
            ?? new PropertyDefinition { Name = "Id", Type = "int", IsKey = true };

    private static bool IsKey(EntityDefinition entity, PropertyDefinition property)
        => property.IsKey || property.Name.Equals(entity.PrimaryKey ?? "Id", StringComparison.OrdinalIgnoreCase);

    private static bool IsString(PropertyDefinition property)
        => property.Type.Equals("string", StringComparison.OrdinalIgnoreCase);

    private static PropertyDefinition? FieldProperty(EntityDefinition entity, string? fieldName)
        => string.IsNullOrWhiteSpace(fieldName)
            ? null
            : entity.Properties.FirstOrDefault(property => Matches(property.Name, fieldName));

    private static bool IsNullable(EntityDefinition entity, PropertyDefinition property)
        => !property.Required && !IsKey(entity, property);

    private static string Coalesce(params string?[] values)
        => values.FirstOrDefault(value => !string.IsNullOrWhiteSpace(value)) ?? "";

    private static bool Matches(string left, string right)
        => Naming.Pascal(left).Equals(Naming.Pascal(right), StringComparison.OrdinalIgnoreCase);

    private static (string EntityName, string FieldName)? ParsePropertyPath(string propertyPath)
    {
        if (string.IsNullOrWhiteSpace(propertyPath))
        {
            return null;
        }

        var parts = propertyPath.Split('.', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        return parts.Length == 2 ? (Naming.Pascal(parts[0]), Naming.Pascal(parts[1])) : null;
    }
}
