using System.Text.Json;
using System.Text.RegularExpressions;

namespace SolutionGeneratorService.Generation;

public sealed class SolutionGeneratorService(GeneratorOptions options) : ISolutionGeneratorService
{
    private const string MetadataManifestPath = ".solution-generator/metadata.json";

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    public async Task<GenerationResult> GenerateAsync(Stream metadataStream, string? outputFolder, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(metadataStream);
        var metadataJson = await reader.ReadToEndAsync(cancellationToken);
        var inputShape = InspectMetadataInput(metadataJson);

        var incomingMetadata = JsonSerializer.Deserialize<MetadataDocument>(metadataJson, JsonOptions)
            ?? throw new InvalidOperationException("Metadata file is empty or invalid.");
        ValidateInputShape(inputShape);

        var targetRoot = Path.GetFullPath(string.IsNullOrWhiteSpace(outputFolder)
            ? Path.Combine(AppContext.BaseDirectory, options.DefaultOutputFolder)
            : outputFolder);

        var existingMetadata = TryLoadExistingMetadata(targetRoot, incomingMetadata, inputShape);
        var metadata = Normalize(MergeMetadata(existingMetadata, incomingMetadata, inputShape));
        ValidateMetadataCanGenerate(metadata, inputShape, existingMetadata is not null);

        var solutionName = Naming.NamespacePart(metadata.Application.Name);
        var solutionRoot = Path.Combine(targetRoot, solutionName);
        Directory.CreateDirectory(solutionRoot);
        DeleteStaleMultiProjectArtifacts(solutionRoot, solutionName);

        var files = new List<string>();
        var generatedFiles = new CompactSolutionEmitter(metadata, solutionName).Emit();

        foreach (var file in generatedFiles)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var path = Path.Combine(solutionRoot, file.RelativePath);
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            await WriteGeneratedFileAsync(path, file.RelativePath, file.Content, cancellationToken);
            files.Add(path);
        }

        DeleteStaleBulkUpdateArtifacts(solutionRoot);
        await WriteMetadataManifestAsync(solutionRoot, metadata, cancellationToken);
        files.Add(Path.Combine(solutionRoot, MetadataManifestPath));

        return new GenerationResult(
            solutionName,
            solutionRoot,
            [solutionName],
            files);
    }

    private static MetadataInputShape InspectMetadataInput(string metadataJson)
    {
        using var document = JsonDocument.Parse(metadataJson, new JsonDocumentOptions
        {
            AllowTrailingCommas = true,
            CommentHandling = JsonCommentHandling.Skip
        });

        var root = document.RootElement;
        var application = TryGetProperty(root, "application", out var applicationElement) ? applicationElement : default;
        return new MetadataInputShape(
            HasApplication: application.ValueKind == JsonValueKind.Object,
            HasApplicationName: application.ValueKind == JsonValueKind.Object && TryGetProperty(application, "name", out _),
            HasAnalysisGenerationMode: TryGetProperty(root, "analysisGenerationMode", out _),
            HasEntities: TryGetProperty(root, "entities", out _),
            HasBusinessObjects: TryGetProperty(root, "businessObjects", out _),
            HasRelationships: TryGetProperty(root, "relationships", out _),
            HasAudit: TryGetProperty(root, "audit", out _));
    }

    private static bool TryGetProperty(JsonElement element, string propertyName, out JsonElement value)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            foreach (var property in element.EnumerateObject())
            {
                if (property.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase))
                {
                    value = property.Value;
                    return true;
                }
            }
        }

        value = default;
        return false;
    }

    private static void ValidateInputShape(MetadataInputShape inputShape)
    {
        if (inputShape.HasEntities && inputShape.HasBusinessObjects)
        {
            throw new InvalidOperationException(
                "Full metadata files are not supported. Provide either entity metadata with entities/relationships, or business-object metadata with businessObjects, but not both in the same file.");
        }

        if (!inputShape.HasEntities && !inputShape.HasBusinessObjects)
        {
            throw new InvalidOperationException(
                "Metadata must contain either an entities array or a businessObjects array.");
        }
    }

    private static MetadataDocument? TryLoadExistingMetadata(string targetRoot, MetadataDocument incomingMetadata, MetadataInputShape inputShape)
    {
        foreach (var manifestPath in CandidateManifestPaths(targetRoot, incomingMetadata, inputShape).Distinct(StringComparer.OrdinalIgnoreCase))
        {
            if (!File.Exists(manifestPath))
            {
                continue;
            }

            var json = File.ReadAllText(manifestPath);
            return JsonSerializer.Deserialize<MetadataDocument>(json, JsonOptions);
        }

        return null;
    }

    private static IEnumerable<string> CandidateManifestPaths(string targetRoot, MetadataDocument incomingMetadata, MetadataInputShape inputShape)
    {
        if (inputShape.HasApplicationName && !string.IsNullOrWhiteSpace(incomingMetadata.Application.Name))
        {
            yield return Path.Combine(targetRoot, Naming.NamespacePart(incomingMetadata.Application.Name), MetadataManifestPath);
        }

        yield return Path.Combine(targetRoot, MetadataManifestPath);

        if (!Directory.Exists(targetRoot))
        {
            yield break;
        }

        foreach (var directory in Directory.EnumerateDirectories(targetRoot))
        {
            yield return Path.Combine(directory, MetadataManifestPath);
        }
    }

    private static MetadataDocument MergeMetadata(MetadataDocument? existingMetadata, MetadataDocument incomingMetadata, MetadataInputShape inputShape)
    {
        if (existingMetadata is null)
        {
            return incomingMetadata;
        }

        return new MetadataDocument
        {
            Application = inputShape.HasApplication
                ? MergeApplication(existingMetadata.Application, incomingMetadata.Application, inputShape)
                : existingMetadata.Application,
            AnalysisGenerationMode = inputShape.HasAnalysisGenerationMode
                ? incomingMetadata.AnalysisGenerationMode
                : existingMetadata.AnalysisGenerationMode,
            Entities = inputShape.HasEntities
                ? MergeEntities(existingMetadata.Entities, incomingMetadata.Entities)
                : existingMetadata.Entities,
            BusinessObjects = inputShape.HasBusinessObjects
                ? MergeBusinessObjects(existingMetadata.BusinessObjects, incomingMetadata.BusinessObjects)
                : existingMetadata.BusinessObjects,
            Relationships = inputShape.HasRelationships
                ? MergeRelationships(existingMetadata.Relationships, incomingMetadata.Relationships)
                : existingMetadata.Relationships,
            Audit = inputShape.HasAudit ? incomingMetadata.Audit : existingMetadata.Audit,
            ExtensionData = MergeExtensionData(existingMetadata.ExtensionData, incomingMetadata.ExtensionData)
        };
    }

    private static ApplicationInfo MergeApplication(ApplicationInfo existingApplication, ApplicationInfo incomingApplication, MetadataInputShape inputShape)
        => new()
        {
            Name = inputShape.HasApplicationName ? incomingApplication.Name : existingApplication.Name,
            Namespace = string.IsNullOrWhiteSpace(incomingApplication.Namespace) ? existingApplication.Namespace : incomingApplication.Namespace,
            Description = string.IsNullOrWhiteSpace(incomingApplication.Description) ? existingApplication.Description : incomingApplication.Description
        };

    private static List<EntityDefinition> MergeEntities(IReadOnlyList<EntityDefinition> existingEntities, IReadOnlyList<EntityDefinition> incomingEntities)
    {
        var merged = existingEntities.ToDictionary(entity => Naming.Pascal(entity.Name), StringComparer.OrdinalIgnoreCase);
        foreach (var incomingEntity in incomingEntities.Where(entity => !string.IsNullOrWhiteSpace(entity.Name)))
        {
            var key = Naming.Pascal(incomingEntity.Name);
            merged[key] = merged.TryGetValue(key, out var existingEntity)
                ? MergeEntity(existingEntity, incomingEntity)
                : incomingEntity;
        }

        return merged.Values.ToList();
    }

    private static EntityDefinition MergeEntity(EntityDefinition existingEntity, EntityDefinition incomingEntity)
        => new()
        {
            Name = incomingEntity.Name,
            TableName = string.IsNullOrWhiteSpace(incomingEntity.TableName) ? existingEntity.TableName : incomingEntity.TableName,
            PrimaryKey = string.IsNullOrWhiteSpace(incomingEntity.PrimaryKey) ? existingEntity.PrimaryKey : incomingEntity.PrimaryKey,
            Audit = incomingEntity.Audit || existingEntity.Audit,
            Properties = incomingEntity.Properties.Count == 0
                ? existingEntity.Properties
                : MergeProperties(existingEntity.Properties, incomingEntity.Properties),
            Operations = incomingEntity.Operations.Count == 0
                ? existingEntity.Operations
                : MergeOperations(existingEntity.Operations, incomingEntity.Operations)
        };

    private static List<PropertyDefinition> MergeProperties(IReadOnlyList<PropertyDefinition> existingProperties, IReadOnlyList<PropertyDefinition> incomingProperties)
    {
        var merged = existingProperties.ToDictionary(property => Naming.Pascal(property.Name), StringComparer.OrdinalIgnoreCase);
        foreach (var incomingProperty in incomingProperties.Where(property => !string.IsNullOrWhiteSpace(property.Name)))
        {
            merged[Naming.Pascal(incomingProperty.Name)] = incomingProperty;
        }

        return merged.Values.ToList();
    }

    private static List<OperationDefinition> MergeOperations(IReadOnlyList<OperationDefinition> existingOperations, IReadOnlyList<OperationDefinition> incomingOperations)
    {
        var merged = existingOperations.ToDictionary(OperationKey, StringComparer.OrdinalIgnoreCase);
        foreach (var incomingOperation in incomingOperations)
        {
            merged[OperationKey(incomingOperation)] = incomingOperation;
        }

        return merged.Values.ToList();
    }

    private static string OperationKey(OperationDefinition operation)
        => string.IsNullOrWhiteSpace(operation.Name) ? operation.Type : operation.Name;

    private static List<BusinessObjectDefinition> MergeBusinessObjects(IReadOnlyList<BusinessObjectDefinition> existingBusinessObjects, IReadOnlyList<BusinessObjectDefinition> incomingBusinessObjects)
    {
        var merged = existingBusinessObjects.ToDictionary(businessObject => Naming.Pascal(businessObject.Name), StringComparer.OrdinalIgnoreCase);
        foreach (var incomingBusinessObject in incomingBusinessObjects.Where(businessObject => !string.IsNullOrWhiteSpace(businessObject.Name)))
        {
            var key = Naming.Pascal(incomingBusinessObject.Name);
            merged[key] = merged.TryGetValue(key, out var existingBusinessObject)
                ? MergeBusinessObject(existingBusinessObject, incomingBusinessObject)
                : incomingBusinessObject;
        }

        return merged.Values.ToList();
    }

    private static BusinessObjectDefinition MergeBusinessObject(BusinessObjectDefinition existingBusinessObject, BusinessObjectDefinition incomingBusinessObject)
        => new()
        {
            Name = incomingBusinessObject.Name,
            Entity = string.IsNullOrWhiteSpace(incomingBusinessObject.Entity) ? existingBusinessObject.Entity : incomingBusinessObject.Entity,
            RootEntity = string.IsNullOrWhiteSpace(incomingBusinessObject.RootEntity) ? existingBusinessObject.RootEntity : incomingBusinessObject.RootEntity,
            Entities = incomingBusinessObject.Entities.Count == 0 ? existingBusinessObject.Entities : incomingBusinessObject.Entities,
            Operations = incomingBusinessObject.Operations.Count == 0
                ? existingBusinessObject.Operations
                : MergeOperations(existingBusinessObject.Operations, incomingBusinessObject.Operations),
            Profiling = HasProfilingDefinition(incomingBusinessObject.Profiling) ? incomingBusinessObject.Profiling : existingBusinessObject.Profiling,
            DataQualityRules = incomingBusinessObject.DataQualityRules.Count == 0
                ? existingBusinessObject.DataQualityRules
                : MergeDataQualityRules(existingBusinessObject.DataQualityRules, incomingBusinessObject.DataQualityRules)
        };

    private static bool HasProfilingDefinition(ProfilingDefinition profiling)
        => profiling.Enabled
            || profiling.Measurements.Count > 0
            || profiling.Summaries.Count > 0
            || profiling.Observations.Count > 0;

    private static List<DataQualityRuleDefinition> MergeDataQualityRules(IReadOnlyList<DataQualityRuleDefinition> existingRules, IReadOnlyList<DataQualityRuleDefinition> incomingRules)
    {
        var merged = existingRules.ToDictionary(RuleKey, StringComparer.OrdinalIgnoreCase);
        foreach (var incomingRule in incomingRules)
        {
            merged[RuleKey(incomingRule)] = incomingRule;
        }

        return merged.Values.ToList();
    }

    private static string RuleKey(DataQualityRuleDefinition rule)
        => FirstNonEmpty(rule.RuleCode, rule.RuleId, rule.RuleName, $"{rule.Entity}:{rule.Field}:{rule.RuleType}:{rule.Type}");

    private static List<RelationshipDefinition> MergeRelationships(IReadOnlyList<RelationshipDefinition> existingRelationships, IReadOnlyList<RelationshipDefinition> incomingRelationships)
    {
        var merged = existingRelationships.ToDictionary(RelationshipKey, StringComparer.OrdinalIgnoreCase);
        foreach (var incomingRelationship in incomingRelationships.Where(relationship => !string.IsNullOrWhiteSpace(relationship.From) && !string.IsNullOrWhiteSpace(relationship.To)))
        {
            merged[RelationshipKey(incomingRelationship)] = incomingRelationship;
        }

        return merged.Values.ToList();
    }

    private static string RelationshipKey(RelationshipDefinition relationship)
        => FirstNonEmpty(relationship.Name, $"{relationship.From}:{relationship.To}:{relationship.ForeignKey}");

    private static Dictionary<string, JsonElement> MergeExtensionData(IReadOnlyDictionary<string, JsonElement> existingData, IReadOnlyDictionary<string, JsonElement> incomingData)
    {
        var merged = new Dictionary<string, JsonElement>(existingData, StringComparer.OrdinalIgnoreCase);
        foreach (var item in incomingData)
        {
            merged[item.Key] = item.Value;
        }

        return merged;
    }

    private static string FirstNonEmpty(params string?[] values)
        => values.First(value => !string.IsNullOrWhiteSpace(value))!;

    private static void ValidateMetadataCanGenerate(MetadataDocument metadata, MetadataInputShape inputShape, bool hasExistingMetadata)
    {
        if (metadata.BusinessObjects.Count > 0 && metadata.Entities.Count == 0)
        {
            var source = inputShape.HasBusinessObjects && !inputShape.HasEntities && !hasExistingMetadata
                ? "Business-object-only metadata requires an existing generated solution manifest or a matching entity metadata run first."
                : "At least one entity definition is required when business objects are present.";

            throw new InvalidOperationException(source);
        }
    }

    private static async Task WriteMetadataManifestAsync(string solutionRoot, MetadataDocument metadata, CancellationToken cancellationToken)
    {
        var manifestPath = Path.Combine(solutionRoot, MetadataManifestPath);
        Directory.CreateDirectory(Path.GetDirectoryName(manifestPath)!);
        var json = JsonSerializer.Serialize(metadata, new JsonSerializerOptions(JsonOptions)
        {
            WriteIndented = true
        });

        await File.WriteAllTextAsync(manifestPath, json, cancellationToken);
    }

    private static void DeleteStaleBulkUpdateArtifacts(string solutionRoot)
    {
        if (!Directory.Exists(solutionRoot))
        {
            return;
        }

        foreach (var file in Directory.EnumerateFiles(solutionRoot, "BulkUpdate*.cs", SearchOption.AllDirectories))
        {
            var normalizedPath = file.Replace('\\', '/');
            if (!normalizedPath.Contains(".Application/Modules/", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            File.Delete(file);
        }
    }

    private static void DeleteStaleMultiProjectArtifacts(string solutionRoot, string solutionName)
    {
        foreach (var projectSuffix in new[] { "API", "Application", "Core", "Infrastructure" })
        {
            var projectDirectory = Path.Combine(solutionRoot, $"{solutionName}.{projectSuffix}");
            if (Directory.Exists(projectDirectory))
            {
                Directory.Delete(projectDirectory, recursive: true);
            }
        }
    }

    private static async Task WriteGeneratedFileAsync(string path, string relativePath, string content, CancellationToken cancellationToken)
    {
        if (!File.Exists(path))
        {
            await File.WriteAllTextAsync(path, content, cancellationToken);
            return;
        }

        var existingContent = await File.ReadAllTextAsync(path, cancellationToken);
        if (string.Equals(existingContent, content, StringComparison.Ordinal))
        {
            return;
        }

        var mergedContent = TryMergeIncrementalChanges(relativePath, existingContent, content);
        if (!string.Equals(existingContent, mergedContent, StringComparison.Ordinal))
        {
            await File.WriteAllTextAsync(path, mergedContent, cancellationToken);
        }
    }

    private static string TryMergeIncrementalChanges(string relativePath, string existingContent, string generatedContent)
    {
        var normalizedPath = relativePath.Replace('\\', '/');

        if (IsCompactGeneratedFile(normalizedPath))
        {
            return generatedContent;
        }

        if (normalizedPath.EndsWith("/appsettings.json", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.Contains("/Migrations/", StringComparison.OrdinalIgnoreCase))
        {
            return existingContent;
        }

        if (normalizedPath.EndsWith(".Application.csproj", StringComparison.OrdinalIgnoreCase))
        {
            return generatedContent;
        }

        if (normalizedPath.EndsWith(".Application/Common/IAnalysisDbContext.cs", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.Contains(".API/Controllers/", StringComparison.OrdinalIgnoreCase) && normalizedPath.EndsWith("AnalysisController.cs", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.Contains(".Application/Modules/", StringComparison.OrdinalIgnoreCase) && normalizedPath.EndsWith("AnalysisDtos.cs", StringComparison.OrdinalIgnoreCase)
            || IsAnalysisQueryOrHandler(normalizedPath)
            || normalizedPath.Contains(".Application/Modules/", StringComparison.OrdinalIgnoreCase) && normalizedPath.Contains("/Interfaces/", StringComparison.OrdinalIgnoreCase) && normalizedPath.EndsWith("RunService.cs", StringComparison.OrdinalIgnoreCase))
        {
            return generatedContent;
        }

        if (normalizedPath.Contains(".API/Controllers/", StringComparison.OrdinalIgnoreCase)
            && normalizedPath.EndsWith("Controller.cs", StringComparison.OrdinalIgnoreCase))
        {
            return generatedContent;
        }

        if (IsBulkGeneratedFile(normalizedPath))
        {
            return generatedContent;
        }

        if (normalizedPath.Contains(".Application/Modules/", StringComparison.OrdinalIgnoreCase)
            && normalizedPath.Contains("/DataQuality/Services/", StringComparison.OrdinalIgnoreCase))
        {
            return generatedContent;
        }

        if (normalizedPath.Contains(".Application/Modules/", StringComparison.OrdinalIgnoreCase)
            && normalizedPath.Contains("/Services/", StringComparison.OrdinalIgnoreCase)
            && normalizedPath.EndsWith("RunService.cs", StringComparison.OrdinalIgnoreCase))
        {
            return generatedContent;
        }

        if (normalizedPath.Contains(".Application/Modules/", StringComparison.OrdinalIgnoreCase)
            && normalizedPath.Contains("/Mappings/", StringComparison.OrdinalIgnoreCase))
        {
            return generatedContent;
        }

        if (normalizedPath.Contains("/Handlers/Update", StringComparison.OrdinalIgnoreCase)
            && normalizedPath.EndsWith("Handler.cs", StringComparison.OrdinalIgnoreCase))
        {
            return generatedContent;
        }

        if (normalizedPath.Contains(".Core/Entities/", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.Contains(".Core/DataQuality/", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.Contains(".Application/Modules/", StringComparison.OrdinalIgnoreCase) && normalizedPath.Contains("/DTOs/", StringComparison.OrdinalIgnoreCase))
        {
            return MergeClassProperties(existingContent, generatedContent);
        }

        if (normalizedPath.EndsWith(".Infrastructure/Persistence/AppDbContext.cs", StringComparison.OrdinalIgnoreCase))
        {
            return MergeDbContext(existingContent, generatedContent);
        }

        if (normalizedPath.Contains(".Infrastructure/Persistence/Configurations/", StringComparison.OrdinalIgnoreCase))
        {
            return MergeConfiguration(existingContent, generatedContent);
        }

        if (normalizedPath.Contains("/Handlers/Get", StringComparison.OrdinalIgnoreCase)
            && normalizedPath.EndsWith("ByIdHandler.cs", StringComparison.OrdinalIgnoreCase))
        {
            return MergeGetByIdHandler(existingContent, generatedContent);
        }

        if (IsSafeInfrastructureFile(normalizedPath))
        {
            return generatedContent;
        }

        return existingContent;
    }

    private static bool IsAnalysisQueryOrHandler(string normalizedPath)
    {
        if (!normalizedPath.Contains(".Application/Modules/", StringComparison.OrdinalIgnoreCase)
            || (!normalizedPath.Contains("/Queries/", StringComparison.OrdinalIgnoreCase)
                && !normalizedPath.Contains("/Handlers/", StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }

        var fileName = Path.GetFileName(normalizedPath);
        return fileName.Contains("Analysis", StringComparison.OrdinalIgnoreCase)
            || fileName.Contains("Run", StringComparison.OrdinalIgnoreCase)
            || fileName.Contains("Profiling", StringComparison.OrdinalIgnoreCase)
            || fileName.Contains("RuleSummary", StringComparison.OrdinalIgnoreCase)
            || fileName.Contains("RuleDrilldown", StringComparison.OrdinalIgnoreCase)
            || fileName.Contains("DuplicateDrilldown", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsBulkGeneratedFile(string normalizedPath)
    {
        if (!normalizedPath.Contains(".Application/Modules/", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        var fileName = Path.GetFileName(normalizedPath);
        return fileName.StartsWith("Bulk", StringComparison.OrdinalIgnoreCase)
            || fileName.StartsWith("ExecuteBulk", StringComparison.OrdinalIgnoreCase)
            || fileName.StartsWith("GetBulk", StringComparison.OrdinalIgnoreCase)
            || fileName.Contains("/DTOs/Bulk", StringComparison.OrdinalIgnoreCase);
    }

    private static string MergeClassProperties(string existingContent, string generatedContent)
    {
        var missingProperties = ExtractPropertyLines(generatedContent)
            .Where(line => !HasProperty(existingContent, PropertyName(line)))
            .ToList();

        return InsertBeforeFinalClassBrace(existingContent, missingProperties);
    }

    private static string MergeDbContext(string existingContent, string generatedContent)
    {
        var mergedContent = MergeMissingUsings(existingContent, generatedContent);
        mergedContent = MergeClassDeclaration(mergedContent, generatedContent);
        var missingDbSets = Regex.Matches(generatedContent, @"^\s*public DbSet<[^>]+>\s+\w+\s*=>\s*Set<[^>]+>\(\);\s*$", RegexOptions.Multiline)
            .Select(match => match.Value)
            .Where(line => !mergedContent.Contains(line.Trim(), StringComparison.Ordinal))
            .ToList();

        if (missingDbSets.Count == 0)
        {
            return mergedContent;
        }

        var marker = Regex.Match(mergedContent, @"^\s*public\s+override\s+async\s+Task<int>\s+SaveChangesAsync", RegexOptions.Multiline);
        return marker.Success
            ? mergedContent.Insert(marker.Index, string.Join(Environment.NewLine, missingDbSets) + Environment.NewLine + Environment.NewLine)
            : InsertBeforeFinalClassBrace(mergedContent, missingDbSets);
    }

    private static string MergeClassDeclaration(string existingContent, string generatedContent)
    {
        var generatedDeclaration = Regex.Match(generatedContent, @"public\s+sealed\s+class\s+AppDbContext[^\r\n]+");
        if (!generatedDeclaration.Success)
        {
            return existingContent;
        }

        return Regex.Replace(
            existingContent,
            @"public\s+sealed\s+class\s+AppDbContext[^\r\n]+",
            generatedDeclaration.Value,
            RegexOptions.Multiline);
    }

    private static string MergeMissingUsings(string existingContent, string generatedContent)
    {
        var missingUsings = Regex.Matches(generatedContent, @"^using\s+[^;]+;\s*$", RegexOptions.Multiline)
            .Select(match => match.Value.Trim())
            .Where(line => !existingContent.Contains(line, StringComparison.Ordinal))
            .ToList();

        if (missingUsings.Count == 0)
        {
            return existingContent;
        }

        var namespaceMatch = Regex.Match(existingContent, @"^namespace\s+", RegexOptions.Multiline);
        return namespaceMatch.Success
            ? existingContent.Insert(namespaceMatch.Index, string.Join(Environment.NewLine, missingUsings) + Environment.NewLine)
            : string.Join(Environment.NewLine, missingUsings) + Environment.NewLine + existingContent;
    }

    private static string MergeConfiguration(string existingContent, string generatedContent)
    {
        var missingBlocks = ExtractConfigurationBlocks(generatedContent)
            .Where(block => !ConfigurationBlockExists(existingContent, block))
            .ToList();

        if (missingBlocks.Count == 0)
        {
            return existingContent;
        }

        var configureEnd = FindConfigureMethodClosingBrace(existingContent);
        return configureEnd < 0
            ? existingContent
            : existingContent.Insert(configureEnd, Environment.NewLine + string.Join(Environment.NewLine, missingBlocks) + Environment.NewLine);
    }

    private static string MergeUpdateHandler(string existingContent, string generatedContent)
    {
        var merged = ReplaceGeneratedGetByIdLine(existingContent, generatedContent);
        var missingCollectionUpdates = Regex.Matches(generatedContent, @"^\s*repository\.ReplaceCollection\([^\r\n]+;\s*$", RegexOptions.Multiline)
            .Select(match => match.Value)
            .Where(line => !merged.Contains(line.Trim(), StringComparison.Ordinal))
            .ToList();

        if (missingCollectionUpdates.Count == 0)
        {
            return merged;
        }

        var marker = Regex.Match(merged, @"^\s*repository\.Update\(entity\);\s*$", RegexOptions.Multiline);
        return marker.Success
            ? merged.Insert(marker.Index, string.Join(Environment.NewLine, missingCollectionUpdates) + Environment.NewLine)
            : merged;
    }

    private static string MergeGetByIdHandler(string existingContent, string generatedContent)
        => ReplaceGeneratedGetByIdLine(existingContent, generatedContent);

    private static string ReplaceGeneratedGetByIdLine(string existingContent, string generatedContent)
    {
        var generatedLine = Regex.Match(generatedContent, @"^\s*var entity = await repository\.GetByIdAsync\(request\.Id, [^\r\n]+, cancellationToken\);\s*$", RegexOptions.Multiline);
        if (!generatedLine.Success)
        {
            return existingContent;
        }

        return Regex.Replace(
            existingContent,
            @"^\s*var entity = await repository\.GetByIdAsync\(request\.Id, [^\r\n]+, cancellationToken\);\s*$",
            generatedLine.Value,
            RegexOptions.Multiline);
    }

    private static string InsertBeforeFinalClassBrace(string content, IReadOnlyList<string> linesToInsert)
    {
        if (linesToInsert.Count == 0)
        {
            return content;
        }

        var lastBrace = content.LastIndexOf('}');
        return lastBrace < 0
            ? content
            : content.Insert(lastBrace, Environment.NewLine + string.Join(Environment.NewLine, linesToInsert) + Environment.NewLine);
    }

    private static IEnumerable<string> ExtractPropertyLines(string content)
        => Regex.Matches(content, @"^\s*public\s+.+?\s+\w+\s*\{\s*get;\s*(?:set|init);\s*\}\s*(?:=\s*[^;\r\n]+;)?\s*$", RegexOptions.Multiline)
            .Select(match => match.Value);

    private static string PropertyName(string propertyLine)
        => Regex.Match(propertyLine, @"\s(?<name>\w+)\s*\{\s*get;").Groups["name"].Value;

    private static bool HasProperty(string content, string propertyName)
        => !string.IsNullOrWhiteSpace(propertyName)
            && Regex.IsMatch(content, @$"\s{Regex.Escape(propertyName)}\s*\{{\s*get;", RegexOptions.Multiline);

    private static IReadOnlyList<string> ExtractConfigurationBlocks(string content)
    {
        var blocks = new List<string>();
        var lines = content.Split(Environment.NewLine);

        for (var index = 0; index < lines.Length; index++)
        {
            var trimmed = lines[index].TrimStart();
            if (trimmed.StartsWith("builder.Property(", StringComparison.Ordinal)
                || trimmed.StartsWith("builder.HasIndex(", StringComparison.Ordinal)
                || trimmed.StartsWith("builder.HasOne(", StringComparison.Ordinal)
                || trimmed.StartsWith("builder.HasMany(", StringComparison.Ordinal))
            {
                var block = new List<string> { lines[index] };
                while (!lines[index].TrimEnd().EndsWith(';') && index + 1 < lines.Length)
                {
                    index++;
                    block.Add(lines[index]);
                }

                blocks.Add(string.Join(Environment.NewLine, block));
            }
        }

        return blocks;
    }

    private static bool ConfigurationBlockExists(string existingContent, string block)
    {
        var firstLine = block.Split(Environment.NewLine)[0].Trim();
        return existingContent.Contains(firstLine, StringComparison.Ordinal);
    }

    private static int FindConfigureMethodClosingBrace(string content)
    {
        var configureStart = Regex.Match(content, @"public\s+void\s+Configure\(");
        if (!configureStart.Success)
        {
            return -1;
        }

        var firstBrace = content.IndexOf('{', configureStart.Index);
        if (firstBrace < 0)
        {
            return -1;
        }

        var depth = 0;
        for (var index = firstBrace; index < content.Length; index++)
        {
            if (content[index] == '{')
            {
                depth++;
            }
            else if (content[index] == '}')
            {
                depth--;
                if (depth == 0)
                {
                    return index;
                }
            }
        }

        return -1;
    }

    private static bool IsSafeInfrastructureFile(string normalizedPath)
        => normalizedPath.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.EndsWith(".sln", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.EndsWith("/Program.cs", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.EndsWith("/DependencyInjection.cs", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.EndsWith("/IRepository.cs", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.EndsWith("/EfRepository.cs", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.EndsWith("/ValidationBehavior.cs", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.EndsWith("/ExceptionHandlingMiddleware.cs", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.EndsWith("/SearchRequest.cs", StringComparison.OrdinalIgnoreCase)
            || normalizedPath.EndsWith("/PagedResult.cs", StringComparison.OrdinalIgnoreCase);

    private static bool IsCompactGeneratedFile(string normalizedPath)
        => !normalizedPath.Contains(".API/", StringComparison.OrdinalIgnoreCase)
            && !normalizedPath.Contains(".Application/", StringComparison.OrdinalIgnoreCase)
            && !normalizedPath.Contains(".Core/", StringComparison.OrdinalIgnoreCase)
            && !normalizedPath.Contains(".Infrastructure/", StringComparison.OrdinalIgnoreCase);

    private static MetadataDocument Normalize(MetadataDocument metadata)
    {
        var entities = metadata.Entities
            .Where(e => !string.IsNullOrWhiteSpace(e.Name))
            .Select(e => e.WithNormalized())
            .ToList();

        return new MetadataDocument
        {
            Application = metadata.Application,
            AnalysisGenerationMode = metadata.AnalysisGenerationMode,
            Entities = entities,
            BusinessObjects = metadata.BusinessObjects
                .Where(b => !string.IsNullOrWhiteSpace(b.Name))
                .Select(b => new BusinessObjectDefinition
                {
                    Name = Naming.Pascal(b.Name),
                    Entity = string.IsNullOrWhiteSpace(b.Entity) ? null : Naming.Pascal(b.Entity),
                    RootEntity = string.IsNullOrWhiteSpace(b.RootEntity) ? null : Naming.Pascal(b.RootEntity),
                    Entities = b.Entities.Select(Naming.Pascal).ToList(),
                    Operations = b.Operations,
                    Profiling = b.Profiling,
                    DataQualityRules = b.DataQualityRules
                })
                .ToList(),
            Relationships = metadata.Relationships,
            Audit = metadata.Audit,
            ExtensionData = metadata.ExtensionData
        };
    }
}

internal sealed record MetadataInputShape(
    bool HasApplication,
    bool HasApplicationName,
    bool HasAnalysisGenerationMode,
    bool HasEntities,
    bool HasBusinessObjects,
    bool HasRelationships,
    bool HasAudit);

file static class EntityDefinitionExtensions
{
    public static EntityDefinition WithNormalized(this EntityDefinition entity)
    {
        var name = Naming.Pascal(entity.Name);
        var properties = entity.Properties.Count == 0
            ? new List<PropertyDefinition>()
            : entity.Properties;

        if (properties.All(p => !p.IsKey) && !properties.Any(p => string.Equals(p.Name, entity.PrimaryKey ?? "Id", StringComparison.OrdinalIgnoreCase)))
        {
            properties = [new PropertyDefinition { Name = entity.PrimaryKey ?? "Id", Type = "int", IsKey = true, Identity = true }, .. properties];
        }

        return new EntityDefinition
        {
            Name = name,
            TableName = entity.TableName,
            PrimaryKey = entity.PrimaryKey ?? properties.FirstOrDefault(p => p.IsKey)?.Name ?? "Id",
            Audit = entity.Audit,
            Properties = properties.Select(p => new PropertyDefinition
            {
                Name = Naming.Pascal(p.Name),
                Type = p.Type,
                IsKey = p.IsKey,
                Identity = p.Identity,
                Required = p.Required,
                Unique = p.Unique,
                Index = p.Index,
                MinLength = p.MinLength,
                MaxLength = p.MaxLength,
                Regex = p.Regex,
                Email = p.Email,
                MinValue = p.MinValue,
                MaxValue = p.MaxValue,
                AllowedValues = p.AllowedValues
            }).ToList(),
            Operations = entity.Operations
        };
    }
}
