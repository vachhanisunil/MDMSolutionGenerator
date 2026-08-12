using DataModelingTool.AI;
using DataModelingTool.Application;
using DataModelingTool.Domain;
using DataModelingTool.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var parsed = CliParser.Parse(args);
if (!parsed.IsValid)
{
    WriteUsage(parsed.Error);
    return (int)ExitCode.InvalidCommandLineArguments;
}

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddJsonFile("appsettings.json", optional: true);
        builder.AddEnvironmentVariables();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddSimpleConsole(options =>
        {
            options.SingleLine = true;
            options.TimestampFormat = "HH:mm:ss ";
        });
    })
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IMetadataFileNameGenerator, MetadataFileNameGenerator>();
        services.AddSingleton<IMetadataValidationService, MetadataValidationService>();
        services.AddSingleton<IMetadataGenerationOrchestrator, MetadataGenerationOrchestrator>();
        services.AddDataModelingInfrastructure();
        services.AddDataModelingAi(context.Configuration);
    })
    .Build();

var orchestrator = host.Services.GetRequiredService<IMetadataGenerationOrchestrator>();
var result = await orchestrator.ExecuteAsync(parsed.Options!, CancellationToken.None);

foreach (var message in result.Messages)
{
    Console.WriteLine(message);
}

if (result.Files is not null)
{
    WritePath("Entity Metadata", result.Files.EntityMetadataPath);
    WritePath("Business Object Metadata", result.Files.BusinessObjectMetadataPath);
    WritePath("Generation Summary", result.Files.GenerationSummaryPath);
    WritePath("Ambiguities", result.Files.AmbiguitiesPath);
    WritePath("Warnings", result.Files.WarningsPath);
    WritePath("Errors", result.Files.ErrorsPath);
}

return (int)result.ExitCode;

static void WritePath(string label, string? path)
{
    if (!string.IsNullOrWhiteSpace(path))
    {
        Console.WriteLine($"{label}: {path}");
    }
}

static void WriteUsage(string? error = null)
{
    if (!string.IsNullOrWhiteSpace(error))
    {
        Console.Error.WriteLine(error);
        Console.Error.WriteLine();
    }

    Console.Error.WriteLine("Usage:");
    Console.Error.WriteLine("  datamodel generate --business-spec <path> --output <folder> [options]");
    Console.Error.WriteLine();
    Console.Error.WriteLine("Options:");
    Console.Error.WriteLine("  --instructions <path>");
    Console.Error.WriteLine("  --generation-mode <Create|Regenerate|Enhance|Modify>");
    Console.Error.WriteLine("  --existing-entity-metadata <path>");
    Console.Error.WriteLine("  --existing-business-object-metadata <path>");
    Console.Error.WriteLine("  --comments <text>");
    Console.Error.WriteLine("  --application-name <name>");
}

internal sealed record CliParseResult(bool IsValid, GenerateMetadataOptions? Options, string? Error);

internal static class CliParser
{
    public static CliParseResult Parse(string[] args)
    {
        if (args.Length == 0)
        {
            return new CliParseResult(false, null, "No command supplied.");
        }

        var index = 0;
        if (args[index].Equals("metadata", StringComparison.OrdinalIgnoreCase))
        {
            index++;
        }

        if (index >= args.Length || !args[index].Equals("generate", StringComparison.OrdinalIgnoreCase))
        {
            return new CliParseResult(false, null, "Expected command: generate");
        }

        index++;
        var values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        while (index < args.Length)
        {
            var key = args[index];
            if (!key.StartsWith("--", StringComparison.Ordinal))
            {
                return new CliParseResult(false, null, $"Unexpected argument '{key}'.");
            }

            if (index + 1 >= args.Length || args[index + 1].StartsWith("--", StringComparison.Ordinal))
            {
                return new CliParseResult(false, null, $"Missing value for '{key}'.");
            }

            values[key] = args[index + 1];
            index += 2;
        }

        if (!values.TryGetValue("--business-spec", out var businessSpec) || string.IsNullOrWhiteSpace(businessSpec))
        {
            return new CliParseResult(false, null, "--business-spec is required.");
        }

        if (!values.TryGetValue("--output", out var output) || string.IsNullOrWhiteSpace(output))
        {
            return new CliParseResult(false, null, "--output is required.");
        }

        var mode = GenerationMode.Create;
        if (values.TryGetValue("--generation-mode", out var modeValue)
            && !Enum.TryParse(modeValue, ignoreCase: true, out mode))
        {
            return new CliParseResult(false, null, $"Invalid --generation-mode '{modeValue}'.");
        }

        return new CliParseResult(true, new GenerateMetadataOptions
        {
            BusinessSpecificationPath = businessSpec,
            OutputDirectory = output,
            AgentInstructionPath = values.GetValueOrDefault("--instructions"),
            GenerationMode = mode,
            ExistingEntityMetadataPath = values.GetValueOrDefault("--existing-entity-metadata"),
            ExistingBusinessObjectMetadataPath = values.GetValueOrDefault("--existing-business-object-metadata"),
            Comments = values.GetValueOrDefault("--comments"),
            ApplicationName = values.GetValueOrDefault("--application-name")
        }, null);
    }
}
