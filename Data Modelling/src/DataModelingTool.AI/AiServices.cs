using System.Text.RegularExpressions;
using System.Text.Json;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using DataModelingTool.Application;
using DataModelingTool.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenAI.Chat;

namespace DataModelingTool.AI;

public sealed record OpenAiOptions
{
    public string? ApiKey { get; init; }
    public string? Model { get; init; }
}

public static class AiServiceCollectionExtensions
{
    public static IServiceCollection AddDataModelingAi(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OpenAiOptions>(configuration.GetSection("OpenAI"));
        services.AddSingleton<IMetadataModelingAgent, MicrosoftAgentFrameworkMetadataModelingAgent>();
        return services;
    }
}

public sealed class MicrosoftAgentFrameworkMetadataModelingAgent(
    IConfiguration configuration,
    ILogger<MicrosoftAgentFrameworkMetadataModelingAgent> logger) : IMetadataModelingAgent
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    public async Task<MetadataGenerationResult> GenerateMetadataAsync(MetadataGenerationRequest request, CancellationToken cancellationToken)
    {
        var apiKey = configuration["OpenAI:ApiKey"];
        apiKey = string.IsNullOrWhiteSpace(apiKey) ? Environment.GetEnvironmentVariable("OPENAI_API_KEY") : apiKey;
        var model = configuration["OpenAI:Model"];
        model = string.IsNullOrWhiteSpace(model) ? "gpt-4o-mini" : model;

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            logger.LogWarning("OPENAI_API_KEY is not configured. Using deterministic local generation instead of Microsoft Agent Framework live model execution.");
            return GenerateDeterministicMetadata(request);
        }

        var chatClient = new ChatClient(model, apiKey).AsIChatClient();
        AIAgent agent = chatClient.AsAIAgent(
            instructions: BuildAgentInstructions(request),
            name: "MetadataModelingAgent");

        var response = await agent.RunAsync(BuildUserPrompt(request), cancellationToken: cancellationToken);
        var responseText = response.ToString();
        var json = ExtractJson(responseText);

        var result = JsonSerializer.Deserialize<MetadataGenerationResult>(json, JsonOptions);
        if (result is null)
        {
            throw new JsonException("Microsoft Agent Framework returned an empty metadata generation result.");
        }

        return result;
    }

    private static string BuildAgentInstructions(MetadataGenerationRequest request) =>
        $"""
        {request.AgentInstructions}

        You are an AI Metadata Modeling Agent running inside Microsoft Agent Framework.
        Return only valid JSON that deserializes to the .NET MetadataGenerationResult contract.
        Do not wrap JSON in Markdown fences.
        The EntityMetadata document must contain application, audit, entities, and relationships only.
        The BusinessObjectMetadata document must contain application, audit, analysisGenerationMode, and businessObjects only.
        Do not silently invent undefined business semantics. Put unresolved questions in ambiguities.
        Use stable names from existing metadata when supplied unless the business meaning changed.
        """;

    private static string BuildUserPrompt(MetadataGenerationRequest request)
    {
        var existingEntity = request.ExistingEntityMetadata is null
            ? "Not supplied."
            : JsonSerializer.Serialize(request.ExistingEntityMetadata, JsonOptions);
        var existingBusinessObject = request.ExistingBusinessObjectMetadata is null
            ? "Not supplied."
            : JsonSerializer.Serialize(request.ExistingBusinessObjectMetadata, JsonOptions);

        return $$"""
        Business Specification:
        {{request.BusinessSpecification.ExtractedText}}

        Application Name:
        {{request.ApplicationName}}

        Generation Mode:
        {{request.GenerationMode}}

        Existing Entity Metadata:
        {{existingEntity}}

        Existing Business Object Metadata:
        {{existingBusinessObject}}

        Additional User Comments:
        {{request.UserComments ?? "None."}}

        TASK:
        Analyze the supplied Business Specification and generate one JSON object with:
        - entityMetadata
        - businessObjectMetadata
        - ambiguities
        - warnings
        - generationSummary

        generationSummary must include applicationName, sourceFile, generationMode, generatedOn, counts, and outputFiles.
        """;
    }

    private static string ExtractJson(string value)
    {
        var trimmed = value.Trim();
        if (trimmed.StartsWith("```", StringComparison.Ordinal))
        {
            var firstNewLine = trimmed.IndexOf('\n');
            var lastFence = trimmed.LastIndexOf("```", StringComparison.Ordinal);
            if (firstNewLine >= 0 && lastFence > firstNewLine)
            {
                trimmed = trimmed[(firstNewLine + 1)..lastFence].Trim();
            }
        }

        var firstBrace = trimmed.IndexOf('{');
        var lastBrace = trimmed.LastIndexOf('}');
        return firstBrace >= 0 && lastBrace > firstBrace
            ? trimmed[firstBrace..(lastBrace + 1)]
            : trimmed;
    }

    private static MetadataGenerationResult GenerateDeterministicMetadata(MetadataGenerationRequest request)
    {
        var applicationName = request.ApplicationName;
        var candidateNames = ExtractCandidateEntityNames(request.BusinessSpecification.ExtractedText).Take(12).ToList();
        if (candidateNames.Count == 0)
        {
            candidateNames.Add(applicationName);
        }

        var entities = candidateNames.Select(name => new EntityDefinition
        {
            Name = name,
            Description = $"Represents {SplitWords(name).ToLowerInvariant()} information described by the business specification.",
            Properties =
            [
                new PropertyDefinition { Name = "Id", Type = "int", IsKey = true, Identity = true, Required = true },
                new PropertyDefinition { Name = $"{name}Code", Type = "string", Required = true },
                new PropertyDefinition { Name = "Name", Type = "string", Required = false }
            ]
        }).ToList();

        var rootEntity = entities[0].Name;
        var relationships = new List<RelationshipDefinition>();
        foreach (var child in entities.Skip(1))
        {
            var foreignKey = $"{rootEntity}Id";
            child.Properties.Add(new PropertyDefinition { Name = foreignKey, Type = "int", Required = true });
            relationships.Add(new RelationshipDefinition
            {
                Name = $"{rootEntity}_{child.Name}",
                Type = RelationshipType.OneToMany,
                From = child.Name,
                To = rootEntity,
                ForeignKey = foreignKey
            });
        }

        var entityMetadata = new EntityMetadataDocument
        {
            Application = new ApplicationMetadata { Name = applicationName },
            Audit = new AuditMetadata { GeneratedBy = "DataModelingTool" },
            Entities = entities,
            Relationships = relationships
        };

        var businessObjects = entities.Select(entity => new BusinessObjectDefinition
        {
            Name = entity.Name,
            Category = entity.Name.Equals(rootEntity, StringComparison.OrdinalIgnoreCase) ? "Transaction" : "Reference",
            Description = $"Business object for {SplitWords(entity.Name).ToLowerInvariant()}.",
            Entity = entity.Name,
            RootEntity = entity.Name,
            Entities = [entity.Name],
            Operations =
            [
                new OperationDefinition { Name = "Create", Type = OperationType.Create },
                new OperationDefinition { Name = "Update", Type = OperationType.Update },
                new OperationDefinition { Name = "Search", Type = OperationType.Search }
            ],
            Profiling = new ProfilingDefinition
            {
                Enabled = true,
                Summaries =
                [
                    new ProfilingSummaryDefinition
                    {
                        Code = $"PROFILE_{ToSnake(entity.Name)}_NAME",
                        Entity = entity.Name,
                        Field = "Name",
                        Description = $"Summarize name completeness for {entity.Name}."
                    }
                ]
            },
            DataQualityRules =
            [
                new DataQualityRuleDefinition
                {
                    Code = $"DQ_{ToSnake(entity.Name)}_CODE_REQUIRED",
                    Entity = entity.Name,
                    Field = $"{entity.Name}Code",
                    Description = $"{entity.Name} code is required."
                }
            ]
        }).ToList();

        var businessObjectMetadata = new BusinessObjectMetadataDocument
        {
            Application = new ApplicationMetadata { Name = applicationName },
            Audit = new AuditMetadata { GeneratedBy = "DataModelingTool" },
            AnalysisGenerationMode = request.GenerationMode.ToString(),
            BusinessObjects = businessObjects
        };

        var ambiguity = new Ambiguity
        {
            Code = "AI_OFFLINE_GENERATION",
            Message = "Metadata was generated by the deterministic offline agent. Review business semantics before production use."
        };

        return new MetadataGenerationResult
        {
            EntityMetadata = entityMetadata,
            BusinessObjectMetadata = businessObjectMetadata,
            Ambiguities = [ambiguity],
            Warnings = ["Live OpenAI generation was not executed in this build."],
            GenerationSummary = new GenerationSummary
            {
                ApplicationName = applicationName,
                SourceFile = request.BusinessSpecification.FileName,
                GenerationMode = request.GenerationMode,
                Counts = new Dictionary<string, int>
                {
                    ["businessObjects"] = businessObjects.Count,
                    ["entities"] = entities.Count,
                    ["relationships"] = relationships.Count,
                    ["dataQualityRules"] = businessObjects.Sum(b => b.DataQualityRules.Count),
                    ["ambiguities"] = 1
                }
            }
        };
    }

    private static IEnumerable<string> ExtractCandidateEntityNames(string text)
    {
        var common = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Business", "Specification", "Process", "Overview", "Requirements", "Data", "System", "User", "The", "This"
        };

        foreach (Match match in Regex.Matches(text, @"\b[A-Z][a-zA-Z0-9]+(?:\s+[A-Z][a-zA-Z0-9]+){0,2}\b"))
        {
            var name = ToPascal(match.Value);
            if (name.Length > 2 && !common.Contains(name))
            {
                yield return name;
            }
        }
    }

    private static string ToPascal(string value) =>
        string.Concat(value.Split([' ', '-', '_'], StringSplitOptions.RemoveEmptyEntries)
            .Select(word => char.ToUpperInvariant(word[0]) + word[1..]));

    private static string ToSnake(string value) =>
        Regex.Replace(SplitWords(value), @"\s+", "_").ToUpperInvariant();

    private static string SplitWords(string value) =>
        Regex.Replace(value, "([a-z])([A-Z])", "$1 $2");
}
