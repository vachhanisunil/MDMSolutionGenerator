using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using DataModelingTool.Application;
using DataModelingTool.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace DataModelingTool.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddDataModelingInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IFileSystemService, FileSystemService>();
        services.AddSingleton<IBusinessSpecificationReader, PlainTextBusinessSpecificationReader>();
        services.AddSingleton<IBusinessSpecificationReader, MarkdownBusinessSpecificationReader>();
        services.AddSingleton<IBusinessSpecificationReader, DocxBusinessSpecificationReader>();
        services.AddSingleton<IBusinessSpecificationReader, PdfBusinessSpecificationReader>();
        services.AddSingleton<IBusinessSpecificationReaderResolver, BusinessSpecificationReaderResolver>();
        services.AddSingleton<IAgentInstructionProvider, AgentInstructionProvider>();
        services.AddSingleton<IMetadataOutputWriter, MetadataOutputWriter>();
        return services;
    }
}

public sealed class FileSystemService : IFileSystemService
{
    public bool FileExists(string path) => File.Exists(path);
    public bool DirectoryExists(string path) => Directory.Exists(path);
    public void CreateDirectory(string path) => Directory.CreateDirectory(path);
    public Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken) => File.ReadAllTextAsync(path, cancellationToken);
}

public sealed class BusinessSpecificationReaderResolver(IEnumerable<IBusinessSpecificationReader> readers) : IBusinessSpecificationReaderResolver
{
    public IBusinessSpecificationReader Resolve(string filePath)
    {
        var extension = Path.GetExtension(filePath);
        return readers.FirstOrDefault(r => r.CanRead(extension))
            ?? throw new NotSupportedException($"No business specification reader is registered for '{extension}'.");
    }
}

public abstract class TextBusinessSpecificationReaderBase : IBusinessSpecificationReader
{
    public abstract bool CanRead(string fileExtension);
    protected abstract string ContentType { get; }

    public virtual async Task<BusinessSpecificationDocument> ReadAsync(string filePath, CancellationToken cancellationToken)
    {
        var text = await File.ReadAllTextAsync(filePath, cancellationToken);
        return CreateDocument(filePath, ContentType, text);
    }

    protected static BusinessSpecificationDocument CreateDocument(string filePath, string contentType, string text)
    {
        return new BusinessSpecificationDocument
        {
            FileName = Path.GetFileName(filePath),
            FullPath = Path.GetFullPath(filePath),
            ContentType = contentType,
            ExtractedText = text,
            Sections = ExtractSections(text)
        };
    }

    private static List<BusinessSpecificationSection> ExtractSections(string text)
    {
        var sections = new List<BusinessSpecificationSection>();
        string? title = null;
        var buffer = new StringBuilder();

        foreach (var line in text.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries))
        {
            var trimmed = line.Trim();
            if (trimmed.StartsWith('#') || Regex.IsMatch(trimmed, @"^[A-Z][A-Za-z0-9 /_-]{2,}:$"))
            {
                if (title is not null)
                {
                    sections.Add(new BusinessSpecificationSection { Title = title, Text = buffer.ToString().Trim() });
                    buffer.Clear();
                }

                title = trimmed.Trim('#', ':', ' ');
            }
            else
            {
                buffer.AppendLine(line);
            }
        }

        if (title is not null)
        {
            sections.Add(new BusinessSpecificationSection { Title = title, Text = buffer.ToString().Trim() });
        }

        return sections;
    }
}

public sealed class PlainTextBusinessSpecificationReader : TextBusinessSpecificationReaderBase
{
    protected override string ContentType => "text/plain";
    public override bool CanRead(string fileExtension) => fileExtension.Equals(".txt", StringComparison.OrdinalIgnoreCase);
}

public sealed class MarkdownBusinessSpecificationReader : TextBusinessSpecificationReaderBase
{
    protected override string ContentType => "text/markdown";
    public override bool CanRead(string fileExtension) => fileExtension.Equals(".md", StringComparison.OrdinalIgnoreCase);
}

public sealed class DocxBusinessSpecificationReader : TextBusinessSpecificationReaderBase
{
    protected override string ContentType => "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
    public override bool CanRead(string fileExtension) => fileExtension.Equals(".docx", StringComparison.OrdinalIgnoreCase);

    public override Task<BusinessSpecificationDocument> ReadAsync(string filePath, CancellationToken cancellationToken)
    {
        using var archive = ZipFile.OpenRead(filePath);
        var entry = archive.GetEntry("word/document.xml")
            ?? throw new InvalidOperationException("DOCX file does not contain word/document.xml.");
        using var stream = entry.Open();
        var document = XDocument.Load(stream);
        var text = string.Join(Environment.NewLine, document.Descendants().Where(e => e.Name.LocalName == "t").Select(e => e.Value));
        return Task.FromResult(CreateDocument(filePath, ContentType, text));
    }
}

public sealed class PdfBusinessSpecificationReader : TextBusinessSpecificationReaderBase
{
    protected override string ContentType => "application/pdf";
    public override bool CanRead(string fileExtension) => fileExtension.Equals(".pdf", StringComparison.OrdinalIgnoreCase);

    public override async Task<BusinessSpecificationDocument> ReadAsync(string filePath, CancellationToken cancellationToken)
    {
        var bytes = await File.ReadAllBytesAsync(filePath, cancellationToken);
        var text = Encoding.UTF8.GetString(bytes);
        text = Regex.Replace(text, @"[^\u0009\u000A\u000D\u0020-\u007E]+", " ");
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new InvalidOperationException("Unable to extract readable text from PDF with built-in extractor. Install a PDF text extraction adapter for scanned or compressed PDFs.");
        }

        return CreateDocument(filePath, ContentType, text);
    }
}

public sealed class AgentInstructionProvider(IFileSystemService fileSystem) : IAgentInstructionProvider
{
    public async Task<string> GetInstructionsAsync(string? instructionFilePath, CancellationToken cancellationToken)
    {
        var path = string.IsNullOrWhiteSpace(instructionFilePath)
            ? Path.Combine(AppContext.BaseDirectory, "AIInstructions", "metadata-generation-generic-data-modeling.md")
            : instructionFilePath;

        if (!fileSystem.FileExists(path))
        {
            var cwdFallback = Path.Combine(Environment.CurrentDirectory, "AIInstructions", "metadata-generation-generic-data-modeling.md");
            path = fileSystem.FileExists(cwdFallback) ? cwdFallback : path;
        }

        if (!fileSystem.FileExists(path))
        {
            throw new FileNotFoundException($"AI instruction document not found: {path}", path);
        }

        return await fileSystem.ReadAllTextAsync(path, cancellationToken);
    }
}

public sealed class MetadataOutputWriter(IMetadataFileNameGenerator fileNameGenerator) : IMetadataOutputWriter
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    public async Task<GeneratedMetadataFiles> WriteAsync(string outputDirectory, MetadataGenerationResult result, CancellationToken cancellationToken)
    {
        Directory.CreateDirectory(outputDirectory);
        var app = result.GenerationSummary.ApplicationName;
        var entityPath = Path.Combine(outputDirectory, fileNameGenerator.GetEntityMetadataFileName(app));
        var businessObjectPath = Path.Combine(outputDirectory, fileNameGenerator.GetBusinessObjectMetadataFileName(app));
        var summaryPath = Path.Combine(outputDirectory, fileNameGenerator.GetGenerationSummaryFileName(app));
        var ambiguityPath = result.Ambiguities.Count > 0 ? Path.Combine(outputDirectory, fileNameGenerator.GetAmbiguitiesFileName(app)) : null;
        var warningPath = result.Warnings.Count > 0 ? Path.Combine(outputDirectory, fileNameGenerator.GetWarningsFileName(app)) : null;

        var summary = result.GenerationSummary with
        {
            OutputFiles = new Dictionary<string, string>
            {
                ["entityMetadata"] = Path.GetFileName(entityPath),
                ["businessObjectMetadata"] = Path.GetFileName(businessObjectPath),
                ["generationSummary"] = Path.GetFileName(summaryPath)
            }
        };

        await WriteJsonAtomicallyAsync(entityPath, result.EntityMetadata, cancellationToken);
        await WriteJsonAtomicallyAsync(businessObjectPath, result.BusinessObjectMetadata, cancellationToken);
        await WriteJsonAtomicallyAsync(summaryPath, summary, cancellationToken);

        if (ambiguityPath is not null)
        {
            await WriteJsonAtomicallyAsync(ambiguityPath, result.Ambiguities, cancellationToken);
        }

        if (warningPath is not null)
        {
            await WriteJsonAtomicallyAsync(warningPath, result.Warnings, cancellationToken);
        }

        return new GeneratedMetadataFiles
        {
            EntityMetadataPath = entityPath,
            BusinessObjectMetadataPath = businessObjectPath,
            GenerationSummaryPath = summaryPath,
            AmbiguitiesPath = ambiguityPath,
            WarningsPath = warningPath
        };
    }

    public async Task<GeneratedMetadataFiles> WriteErrorsAsync(string outputDirectory, string applicationName, IReadOnlyCollection<ValidationIssue> issues, CancellationToken cancellationToken)
    {
        Directory.CreateDirectory(outputDirectory);
        var errorPath = Path.Combine(outputDirectory, fileNameGenerator.GetErrorsFileName(applicationName));
        await WriteJsonAtomicallyAsync(errorPath, new { applicationName, generatedOn = DateTimeOffset.UtcNow, issues }, cancellationToken);
        return new GeneratedMetadataFiles
        {
            EntityMetadataPath = string.Empty,
            BusinessObjectMetadataPath = string.Empty,
            GenerationSummaryPath = string.Empty,
            ErrorsPath = errorPath
        };
    }

    private static async Task WriteJsonAtomicallyAsync<T>(string path, T value, CancellationToken cancellationToken)
    {
        var tempPath = $"{path}.{Guid.NewGuid():N}.tmp";
        await using (var stream = File.Create(tempPath))
        {
            await JsonSerializer.SerializeAsync(stream, value, JsonOptions, cancellationToken);
            await stream.FlushAsync(cancellationToken);
        }

        File.Move(tempPath, path, overwrite: true);
    }
}
