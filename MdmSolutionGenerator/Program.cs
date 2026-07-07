using MdmSolutionGenerator.Generation;

var metadataPath = ReadArgument(args, "--metadata");
if (string.IsNullOrWhiteSpace(metadataPath))
{
    WriteUsage();
    return;
}

var outputFolder = ReadArgument(args, "--output");
await using var stream = File.OpenRead(metadataPath);

var generator = new MdmSolutionGeneratorService(new GeneratorOptions());
var result = await generator.GenerateAsync(stream, outputFolder, CancellationToken.None);

Console.WriteLine($"Generated {result.SolutionName}");
Console.WriteLine($"Output: {result.OutputFolder}");
Console.WriteLine($"Projects: {string.Join(", ", result.Projects)}");
Console.WriteLine($"Files: {result.Files.Count}");

static string? ReadArgument(string[] args, string name)
{
    var index = Array.FindIndex(args, value => value.Equals(name, StringComparison.OrdinalIgnoreCase));
    return index >= 0 && index + 1 < args.Length ? args[index + 1] : null;
}

static void WriteUsage()
{
    Console.WriteLine("MDM Solution Generator");
    Console.WriteLine();
    Console.WriteLine("Usage:");
    Console.WriteLine("  dotnet run -- --metadata <metadata-json-path> [--output <output-folder>]");
    Console.WriteLine();
    Console.WriteLine("Example:");
    Console.WriteLine("  dotnet run -- --metadata sample-metadata.json --output generated-out");
}
