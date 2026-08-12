namespace DataModelingTool.Domain;

public enum GenerationMode
{
    Create,
    Regenerate,
    Enhance,
    Modify
}

public enum RelationshipType
{
    OneToOne,
    OneToMany,
    ManyToOne,
    ManyToMany
}

public enum OperationType
{
    Create,
    Read,
    Update,
    Delete,
    Submit,
    Approve,
    Reject,
    Search,
    Custom
}

public sealed record ApplicationMetadata
{
    public required string Name { get; init; }
}

public sealed record AuditMetadata
{
    public DateTimeOffset GeneratedOn { get; init; } = DateTimeOffset.UtcNow;
    public string? GeneratedBy { get; init; }
}

public sealed record EntityMetadataDocument
{
    public required ApplicationMetadata Application { get; init; }
    public AuditMetadata? Audit { get; init; }
    public List<EntityDefinition> Entities { get; init; } = [];
    public List<RelationshipDefinition> Relationships { get; init; } = [];
}

public sealed record EntityDefinition
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public List<PropertyDefinition> Properties { get; init; } = [];
}

public sealed record PropertyDefinition
{
    public required string Name { get; init; }
    public string Type { get; init; } = "string";
    public bool IsKey { get; init; }
    public bool Identity { get; init; }
    public bool Required { get; init; }
}

public sealed record RelationshipDefinition
{
    public required string Name { get; init; }
    public RelationshipType Type { get; init; } = RelationshipType.OneToMany;
    public required string From { get; init; }
    public required string To { get; init; }
    public required string ForeignKey { get; init; }
}

public sealed record BusinessObjectMetadataDocument
{
    public required ApplicationMetadata Application { get; init; }
    public AuditMetadata? Audit { get; init; }
    public string? AnalysisGenerationMode { get; init; }
    public List<BusinessObjectDefinition> BusinessObjects { get; init; } = [];
}

public sealed record BusinessObjectDefinition
{
    public required string Name { get; init; }
    public string Category { get; init; } = "Process";
    public string? Description { get; init; }
    public required string Entity { get; init; }
    public required string RootEntity { get; init; }
    public List<string> Entities { get; init; } = [];
    public List<OperationDefinition> Operations { get; init; } = [];
    public ProfilingDefinition? Profiling { get; init; }
    public List<DataQualityRuleDefinition> DataQualityRules { get; init; } = [];
}

public sealed record OperationDefinition
{
    public required string Name { get; init; }
    public OperationType Type { get; init; } = OperationType.Custom;
}

public sealed record ProfilingDefinition
{
    public bool Enabled { get; init; }
    public List<ProfilingSummaryDefinition> Summaries { get; init; } = [];
}

public sealed record ProfilingSummaryDefinition
{
    public required string Code { get; init; }
    public required string Entity { get; init; }
    public required string Field { get; init; }
    public string? Description { get; init; }
}

public sealed record DataQualityRuleDefinition
{
    public required string Code { get; init; }
    public required string Entity { get; init; }
    public required string Field { get; init; }
    public string? Description { get; init; }
}

public sealed record Ambiguity
{
    public required string Code { get; init; }
    public required string Message { get; init; }
    public string Severity { get; init; } = "Information";
}

public sealed record GenerationSummary
{
    public required string ApplicationName { get; init; }
    public required string SourceFile { get; init; }
    public GenerationMode GenerationMode { get; init; }
    public DateTimeOffset GeneratedOn { get; init; } = DateTimeOffset.UtcNow;
    public Dictionary<string, int> Counts { get; init; } = [];
    public Dictionary<string, string> OutputFiles { get; init; } = [];
}

public sealed record MetadataGenerationResult
{
    public required EntityMetadataDocument EntityMetadata { get; init; }
    public required BusinessObjectMetadataDocument BusinessObjectMetadata { get; init; }
    public List<Ambiguity> Ambiguities { get; init; } = [];
    public List<string> Warnings { get; init; } = [];
    public required GenerationSummary GenerationSummary { get; init; }
}

public sealed record ValidationIssue
{
    public required string Code { get; init; }
    public required string Message { get; init; }
}

public sealed record MetadataValidationResult
{
    public List<ValidationIssue> Issues { get; init; } = [];
    public bool IsValid => Issues.Count == 0;
}

public sealed record BusinessSpecificationDocument
{
    public required string FileName { get; init; }
    public required string FullPath { get; init; }
    public required string ContentType { get; init; }
    public required string ExtractedText { get; init; }
    public List<BusinessSpecificationSection> Sections { get; init; } = [];
}

public sealed record BusinessSpecificationSection
{
    public required string Title { get; init; }
    public required string Text { get; init; }
}
