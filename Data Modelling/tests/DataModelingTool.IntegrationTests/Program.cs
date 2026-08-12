using DataModelingTool.AI;
using DataModelingTool.Application;
using DataModelingTool.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var tempRoot = Path.Combine(Path.GetTempPath(), "DataModelingToolTests", Guid.NewGuid().ToString("N"));
Directory.CreateDirectory(tempRoot);

try
{
    var specPath = Path.Combine(tempRoot, "customer-onboarding.md");
    var instructionsPath = Path.Combine(tempRoot, "metadata-generation-generic-data-modeling.md");
    var outputPath = Path.Combine(tempRoot, "output");

    await File.WriteAllTextAsync(specPath, """
    # Customer Onboarding

    Customer Onboarding captures Customer, Account, Address, and Contact details.
    The process must support Create, Update, Search, and data quality checks.
    """);

    await File.WriteAllTextAsync(instructionsPath, "Generate entity metadata and business object metadata.");

    var services = new ServiceCollection();
    var configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>()).Build();
    services.AddLogging(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Warning));
    services.AddSingleton<IConfiguration>(configuration);
    services.AddSingleton<IMetadataFileNameGenerator, MetadataFileNameGenerator>();
    services.AddSingleton<IMetadataValidationService, MetadataValidationService>();
    services.AddSingleton<IMetadataGenerationOrchestrator, MetadataGenerationOrchestrator>();
    services.AddDataModelingInfrastructure();
    services.AddDataModelingAi(configuration);

    var provider = services.BuildServiceProvider();
    var orchestrator = provider.GetRequiredService<IMetadataGenerationOrchestrator>();
    var result = await orchestrator.ExecuteAsync(new GenerateMetadataOptions
    {
        BusinessSpecificationPath = specPath,
        AgentInstructionPath = instructionsPath,
        OutputDirectory = outputPath,
        GenerationMode = DataModelingTool.Domain.GenerationMode.Create
    }, CancellationToken.None);

    AssertTrue(result.ExitCode == ExitCode.Success, $"Expected success, got {result.ExitCode}.");
    AssertTrue(File.Exists(Path.Combine(outputPath, "customer-onboarding.entity-metadata.json")), "Missing entity metadata.");
    AssertTrue(File.Exists(Path.Combine(outputPath, "customer-onboarding.business-object-metadata.json")), "Missing business object metadata.");
    AssertTrue(File.Exists(Path.Combine(outputPath, "customer-onboarding.generation-summary.json")), "Missing generation summary.");

    Console.WriteLine("PASS End-to-end Business Spec -> Agent -> JSON files");
    return 0;
}
catch (Exception ex)
{
    Console.WriteLine($"FAIL Integration test: {ex}");
    return 1;
}
finally
{
    if (Directory.Exists(tempRoot))
    {
        Directory.Delete(tempRoot, recursive: true);
    }
}

static void AssertTrue(bool value, string message)
{
    if (!value)
    {
        throw new InvalidOperationException(message);
    }
}
