using System.Text.Json;
using System.Text.RegularExpressions;

namespace MdmSolutionGenerator.Generation;

public sealed class MdmSolutionGeneratorService(GeneratorOptions options) : IMdmSolutionGenerator
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    public async Task<GenerationResult> GenerateAsync(Stream metadataStream, string? outputFolder, CancellationToken cancellationToken)
    {
        var metadata = await JsonSerializer.DeserializeAsync<MetadataDocument>(metadataStream, JsonOptions, cancellationToken)
            ?? throw new InvalidOperationException("Metadata file is empty or invalid.");

        metadata = Normalize(metadata);

        var solutionName = Naming.NamespacePart(metadata.Application.Name);
        var targetRoot = Path.GetFullPath(string.IsNullOrWhiteSpace(outputFolder)
            ? Path.Combine(AppContext.BaseDirectory, options.DefaultOutputFolder)
            : outputFolder);

        var solutionRoot = Path.Combine(targetRoot, solutionName);
        Directory.CreateDirectory(solutionRoot);

        var files = new List<string>();
        var emitter = new SolutionEmitter(metadata, solutionName);
        foreach (var file in emitter.Emit())
        {
            cancellationToken.ThrowIfCancellationRequested();
            var path = Path.Combine(solutionRoot, file.RelativePath);
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            await WriteGeneratedFileAsync(path, file.RelativePath, file.Content, cancellationToken);
            files.Add(path);
        }

        DeleteStaleBulkUpdateArtifacts(solutionRoot);

        return new GenerationResult(
            solutionName,
            solutionRoot,
            [
                $"{solutionName}.API",
                $"{solutionName}.Application",
                $"{solutionName}.Core",
                $"{solutionName}.Infrastructure"
            ],
            files);
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

    private static MetadataDocument Normalize(MetadataDocument metadata)
    {
        var entities = metadata.Entities
            .Where(e => !string.IsNullOrWhiteSpace(e.Name))
            .Select(e => e.WithNormalized())
            .ToList();

        foreach (var businessObject in metadata.BusinessObjects.Where(b => !string.IsNullOrWhiteSpace(b.Name)))
        {
            var entityName = Naming.Pascal(businessObject.Entity ?? businessObject.Name);
            if (entities.All(e => !string.Equals(e.Name, entityName, StringComparison.OrdinalIgnoreCase)))
            {
                entities.Add(new EntityDefinition
                {
                    Name = entityName,
                    PrimaryKey = "Id",
                    Properties =
                    [
                        new PropertyDefinition { Name = "Id", Type = "int", IsKey = true, Identity = true },
                        new PropertyDefinition { Name = $"{entityName}Name", Type = "string", Required = true, MaxLength = 200 }
                    ],
                    Operations = businessObject.Operations
                });
            }
        }

        if (metadata.BusinessObjects.Count == 0)
        {
            metadata = new MetadataDocument
            {
                Application = metadata.Application,
                Entities = entities,
                BusinessObjects = entities.Select(e => new BusinessObjectDefinition { Name = e.Name, Entity = e.Name, RootEntity = e.Name, Entities = [e.Name] }).ToList(),
                Relationships = metadata.Relationships,
                Audit = metadata.Audit,
                ExtensionData = metadata.ExtensionData
            };
        }
        else
        {
            metadata = new MetadataDocument
            {
                Application = metadata.Application,
                Entities = entities,
                BusinessObjects = metadata.BusinessObjects.Select(b => new BusinessObjectDefinition
                {
                    Name = Naming.Pascal(b.Name),
                    Entity = string.IsNullOrWhiteSpace(b.Entity) ? null : Naming.Pascal(b.Entity),
                    RootEntity = string.IsNullOrWhiteSpace(b.RootEntity) ? null : Naming.Pascal(b.RootEntity),
                    Entities = b.Entities.Select(Naming.Pascal).ToList(),
                    Operations = b.Operations,
                    Profiling = b.Profiling,
                    DataQualityRules = b.DataQualityRules
                }).ToList(),
                Relationships = metadata.Relationships,
                Audit = metadata.Audit,
                ExtensionData = metadata.ExtensionData
            };
        }

        return metadata;
    }
}

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
