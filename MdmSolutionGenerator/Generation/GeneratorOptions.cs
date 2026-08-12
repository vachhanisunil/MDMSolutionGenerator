namespace SolutionGeneratorService.Generation;

public sealed class GeneratorOptions
{
    public string DefaultOutputFolder { get; set; } = "generated";
    public bool GenerateSingleProjectSolution { get; set; } = true;
}
