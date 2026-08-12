using System.Text.Json;
using DataModelingTool.Domain;
using Microsoft.Extensions.Logging;

namespace DataModelingTool.Application;

public enum ExitCode
{
    Success = 0,
    UnexpectedApplicationFailure = 1,
    InvalidCommandLineArguments = 2,
    InputFileNotFoundOrUnreadable = 3,
    DocumentExtractionFailure = 4,
    AiGenerationFailure = 5,
    AiResponseDeserializationFailure = 6,
    MetadataValidationFailure = 7,
    OutputWritingFailure = 8
}

public sealed record GenerateMetadataOptions
{
    public required string BusinessSpecificationPath { get; init; }
    public required string OutputDirectory { get; init; }
    public string? AgentInstructionPath { get; init; }
    public GenerationMode GenerationMode { get; init; } = GenerationMode.Create;
    public string? ExistingEntityMetadataPath { get; init; }
    public string? ExistingBusinessObjectMetadataPath { get; init; }
    public string? ApplicationName { get; init; }
    public string? Comments { get; init; }
}

public sealed record MetadataGenerationRequest
{
    public required string ApplicationName { get; init; }
    public required BusinessSpecificationDocument BusinessSpecification { get; init; }
    public required string AgentInstructions { get; init; }
    public GenerationMode GenerationMode { get; init; }
    public EntityMetadataDocument? ExistingEntityMetadata { get; init; }
    public BusinessObjectMetadataDocument? ExistingBusinessObjectMetadata { get; init; }
    public string? UserComments { get; init; }
}

public sealed record GeneratedMetadataFiles
{
    public required string EntityMetadataPath { get; init; }
    public required string BusinessObjectMetadataPath { get; init; }
    public required string GenerationSummaryPath { get; init; }
    public string? AmbiguitiesPath { get; init; }
    public string? WarningsPath { get; init; }
    public string? ErrorsPath { get; init; }
}

public sealed record MetadataGenerationExecutionResult
{
    public ExitCode ExitCode { get; init; }
    public List<string> Messages { get; init; } = [];
    public GeneratedMetadataFiles? Files { get; init; }
}

public interface IBusinessSpecificationReader
{
    bool CanRead(string fileExtension);
    Task<BusinessSpecificationDocument> ReadAsync(string filePath, CancellationToken cancellationToken);
}

public interface IBusinessSpecificationReaderResolver
{
    IBusinessSpecificationReader Resolve(string filePath);
}

public interface IAgentInstructionProvider
{
    Task<string> GetInstructionsAsync(string? instructionFilePath, CancellationToken cancellationToken);
}

public interface IMetadataModelingAgent
{
    Task<MetadataGenerationResult> GenerateMetadataAsync(MetadataGenerationRequest request, CancellationToken cancellationToken);
}

public interface IMetadataFileNameGenerator
{
    string GetBaseName(string applicationName);
    string GetEntityMetadataFileName(string applicationName);
    string GetBusinessObjectMetadataFileName(string applicationName);
    string GetGenerationSummaryFileName(string applicationName);
    string GetAmbiguitiesFileName(string applicationName);
    string GetWarningsFileName(string applicationName);
    string GetErrorsFileName(string applicationName);
}

public interface IMetadataOutputWriter
{
    Task<GeneratedMetadataFiles> WriteAsync(
        string outputDirectory,
        MetadataGenerationResult result,
        CancellationToken cancellationToken);

    Task<GeneratedMetadataFiles> WriteErrorsAsync(
        string outputDirectory,
        string applicationName,
        IReadOnlyCollection<ValidationIssue> issues,
        CancellationToken cancellationToken);
}

public interface IMetadataValidationService
{
    MetadataValidationResult Validate(EntityMetadataDocument entityMetadata, BusinessObjectMetadataDocument businessObjectMetadata);
}

public interface IFileSystemService
{
    bool FileExists(string path);
    bool DirectoryExists(string path);
    void CreateDirectory(string path);
    Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken);
}

public interface IMetadataGenerationOrchestrator
{
    Task<MetadataGenerationExecutionResult> ExecuteAsync(GenerateMetadataOptions options, CancellationToken cancellationToken);
}

public sealed class MetadataFileNameGenerator : IMetadataFileNameGenerator
{
    public string GetBaseName(string applicationName)
    {
        var spaced = System.Text.RegularExpressions.Regex.Replace(applicationName.Trim(), "([a-z0-9])([A-Z])", "$1-$2");
        var chars = spaced.Select(ch =>
            char.IsLetterOrDigit(ch) ? char.ToLowerInvariant(ch) : '-').ToArray();
        var collapsed = new string(chars);
        while (collapsed.Contains("--", StringComparison.Ordinal))
        {
            collapsed = collapsed.Replace("--", "-", StringComparison.Ordinal);
        }

        return collapsed.Trim('-') is { Length: > 0 } value ? value : "metadata";
    }

    public string GetEntityMetadataFileName(string applicationName) => $"{GetBaseName(applicationName)}.entity-metadata.json";
    public string GetBusinessObjectMetadataFileName(string applicationName) => $"{GetBaseName(applicationName)}.business-object-metadata.json";
    public string GetGenerationSummaryFileName(string applicationName) => $"{GetBaseName(applicationName)}.generation-summary.json";
    public string GetAmbiguitiesFileName(string applicationName) => $"{GetBaseName(applicationName)}.ambiguities.json";
    public string GetWarningsFileName(string applicationName) => $"{GetBaseName(applicationName)}.warnings.json";
    public string GetErrorsFileName(string applicationName) => $"{GetBaseName(applicationName)}.generation-errors.json";
}

public sealed class MetadataValidationService : IMetadataValidationService
{
    public MetadataValidationResult Validate(EntityMetadataDocument entityMetadata, BusinessObjectMetadataDocument businessObjectMetadata)
    {
        var issues = new List<ValidationIssue>();
        var entityNames = entityMetadata.Entities.Select(e => e.Name).ToHashSet(StringComparer.OrdinalIgnoreCase);

        AddDuplicateIssues(entityMetadata.Entities.Select(e => e.Name), "DUPLICATE_ENTITY", "Entity names must be unique.", issues);
        AddDuplicateIssues(entityMetadata.Relationships.Select(r => r.Name), "DUPLICATE_RELATIONSHIP", "Relationship names must be unique.", issues);
        AddDuplicateIssues(businessObjectMetadata.BusinessObjects.Select(b => b.Name), "DUPLICATE_BUSINESS_OBJECT", "Business Object names must be unique.", issues);

        foreach (var entity in entityMetadata.Entities)
        {
            AddDuplicateIssues(entity.Properties.Select(p => p.Name), "DUPLICATE_PROPERTY", $"Property names must be unique within entity '{entity.Name}'.", issues);
        }

        foreach (var relationship in entityMetadata.Relationships)
        {
            if (!entityNames.Contains(relationship.From))
            {
                issues.Add(new ValidationIssue { Code = "RELATIONSHIP_FROM_MISSING", Message = $"Relationship '{relationship.Name}' references missing from entity '{relationship.From}'." });
            }

            if (!entityNames.Contains(relationship.To))
            {
                issues.Add(new ValidationIssue { Code = "RELATIONSHIP_TO_MISSING", Message = $"Relationship '{relationship.Name}' references missing to entity '{relationship.To}'." });
            }

            var fromEntity = entityMetadata.Entities.FirstOrDefault(e => e.Name.Equals(relationship.From, StringComparison.OrdinalIgnoreCase));
            if (fromEntity is not null && !fromEntity.Properties.Any(p => p.Name.Equals(relationship.ForeignKey, StringComparison.OrdinalIgnoreCase)))
            {
                issues.Add(new ValidationIssue { Code = "FOREIGN_KEY_MISSING", Message = $"Relationship '{relationship.Name}' foreign key '{relationship.ForeignKey}' does not exist on '{relationship.From}'." });
            }
        }

        var ruleCodes = new List<string>();
        var profilingCodes = new List<string>();
        foreach (var businessObject in businessObjectMetadata.BusinessObjects)
        {
            CheckEntityReference(businessObject.Entity, $"Business Object '{businessObject.Name}' entity", entityNames, issues);
            CheckEntityReference(businessObject.RootEntity, $"Business Object '{businessObject.Name}' rootEntity", entityNames, issues);
            foreach (var entity in businessObject.Entities)
            {
                CheckEntityReference(entity, $"Business Object '{businessObject.Name}' member entity", entityNames, issues);
            }

            foreach (var summary in businessObject.Profiling?.Summaries ?? [])
            {
                profilingCodes.Add(summary.Code);
                CheckFieldReference(summary.Entity, summary.Field, "profiling summary", entityMetadata, issues);
            }

            foreach (var rule in businessObject.DataQualityRules)
            {
                ruleCodes.Add(rule.Code);
                CheckFieldReference(rule.Entity, rule.Field, "data quality rule", entityMetadata, issues);
            }
        }

        AddDuplicateIssues(ruleCodes, "DUPLICATE_DQ_RULE_CODE", "Data quality rule codes must be unique.", issues);
        AddDuplicateIssues(profilingCodes, "DUPLICATE_PROFILING_CODE", "Profiling summary codes must be unique.", issues);

        return new MetadataValidationResult { Issues = issues };
    }

    private static void CheckEntityReference(string entityName, string source, HashSet<string> entityNames, List<ValidationIssue> issues)
    {
        if (!entityNames.Contains(entityName))
        {
            issues.Add(new ValidationIssue { Code = "ENTITY_REFERENCE_MISSING", Message = $"{source} references missing entity '{entityName}'." });
        }
    }

    private static void CheckFieldReference(string entityName, string fieldName, string source, EntityMetadataDocument metadata, List<ValidationIssue> issues)
    {
        var entity = metadata.Entities.FirstOrDefault(e => e.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));
        if (entity is null)
        {
            issues.Add(new ValidationIssue { Code = "FIELD_ENTITY_MISSING", Message = $"{source} references missing entity '{entityName}'." });
            return;
        }

        if (!entity.Properties.Any(p => p.Name.Equals(fieldName, StringComparison.OrdinalIgnoreCase)))
        {
            issues.Add(new ValidationIssue { Code = "FIELD_MISSING", Message = $"{source} references missing field '{entityName}.{fieldName}'." });
        }
    }

    private static void AddDuplicateIssues(IEnumerable<string> values, string code, string message, List<ValidationIssue> issues)
    {
        if (values.GroupBy(v => v, StringComparer.OrdinalIgnoreCase).Any(g => g.Count() > 1))
        {
            issues.Add(new ValidationIssue { Code = code, Message = message });
        }
    }
}

public sealed class MetadataGenerationOrchestrator(
    IBusinessSpecificationReaderResolver readerResolver,
    IAgentInstructionProvider instructionProvider,
    IMetadataModelingAgent agent,
    IMetadataValidationService validationService,
    IMetadataOutputWriter outputWriter,
    IFileSystemService fileSystem,
    ILogger<MetadataGenerationOrchestrator> logger) : IMetadataGenerationOrchestrator
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web) { PropertyNameCaseInsensitive = true };

    public async Task<MetadataGenerationExecutionResult> ExecuteAsync(GenerateMetadataOptions options, CancellationToken cancellationToken)
    {
        var messages = new List<string>();
        if (string.IsNullOrWhiteSpace(options.BusinessSpecificationPath) || string.IsNullOrWhiteSpace(options.OutputDirectory))
        {
            return Failure(ExitCode.InvalidCommandLineArguments, "Both --business-spec and --output are required.");
        }

        if (!fileSystem.FileExists(options.BusinessSpecificationPath))
        {
            return Failure(ExitCode.InputFileNotFoundOrUnreadable, $"Business specification not found: {options.BusinessSpecificationPath}");
        }

        try
        {
            logger.LogInformation("Reading business specification {Path}", options.BusinessSpecificationPath);
            var reader = readerResolver.Resolve(options.BusinessSpecificationPath);
            var specification = await reader.ReadAsync(options.BusinessSpecificationPath, cancellationToken);
            messages.Add($"Loaded business specification: {specification.FileName}");

            var instructions = await instructionProvider.GetInstructionsAsync(options.AgentInstructionPath, cancellationToken);
            messages.Add("Loaded AI agent instructions.");

            var existingEntity = await LoadJsonAsync<EntityMetadataDocument>(options.ExistingEntityMetadataPath, cancellationToken);
            var existingBusinessObject = await LoadJsonAsync<BusinessObjectMetadataDocument>(options.ExistingBusinessObjectMetadataPath, cancellationToken);
            var applicationName = ResolveApplicationName(options.ApplicationName, specification);

            var request = new MetadataGenerationRequest
            {
                ApplicationName = applicationName,
                BusinessSpecification = specification,
                AgentInstructions = instructions,
                GenerationMode = options.GenerationMode,
                ExistingEntityMetadata = existingEntity,
                ExistingBusinessObjectMetadata = existingBusinessObject,
                UserComments = options.Comments
            };

            var result = await agent.GenerateMetadataAsync(request, cancellationToken);
            var validation = validationService.Validate(result.EntityMetadata, result.BusinessObjectMetadata);
            if (!validation.IsValid)
            {
                var files = await outputWriter.WriteErrorsAsync(options.OutputDirectory, applicationName, validation.Issues, cancellationToken);
                messages.Add($"Metadata validation failed with {validation.Issues.Count} issue(s).");
                return new MetadataGenerationExecutionResult { ExitCode = ExitCode.MetadataValidationFailure, Messages = messages, Files = files };
            }

            var writtenFiles = await outputWriter.WriteAsync(options.OutputDirectory, result, cancellationToken);
            messages.Add("Metadata validation successful.");
            messages.Add("Generation completed successfully.");
            return new MetadataGenerationExecutionResult { ExitCode = ExitCode.Success, Messages = messages, Files = writtenFiles };
        }
        catch (NotSupportedException ex)
        {
            logger.LogError(ex, "Unsupported document type");
            return Failure(ExitCode.DocumentExtractionFailure, ex.Message);
        }
        catch (JsonException ex)
        {
            logger.LogError(ex, "Metadata JSON could not be deserialized");
            return Failure(ExitCode.AiResponseDeserializationFailure, ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Generation failed");
            return Failure(ExitCode.UnexpectedApplicationFailure, ex.Message);
        }

        async Task<T?> LoadJsonAsync<T>(string? path, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return default;
            }

            var json = await fileSystem.ReadAllTextAsync(path, token);
            return JsonSerializer.Deserialize<T>(json, JsonOptions);
        }

        MetadataGenerationExecutionResult Failure(ExitCode code, string message) => new() { ExitCode = code, Messages = [message] };
    }

    private static string ResolveApplicationName(string? explicitName, BusinessSpecificationDocument specification)
    {
        if (!string.IsNullOrWhiteSpace(explicitName))
        {
            return explicitName.Trim();
        }

        foreach (var line in specification.ExtractedText.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries).Take(10))
        {
            var trimmed = line.Trim().Trim('#', ':').Trim();
            if (trimmed.Length is > 2 and < 80)
            {
                return ToPascalName(trimmed);
            }
        }

        return ToPascalName(Path.GetFileNameWithoutExtension(specification.FileName));
    }

    private static string ToPascalName(string value)
    {
        var words = value.Split([' ', '-', '_', '.', '/', '\\'], StringSplitOptions.RemoveEmptyEntries);
        return string.Concat(words.Select(word => char.ToUpperInvariant(word[0]) + word[1..]));
    }
}
