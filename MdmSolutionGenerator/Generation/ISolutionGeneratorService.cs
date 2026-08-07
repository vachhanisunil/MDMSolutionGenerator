namespace SolutionGeneratorService.Generation;

public interface ISolutionGeneratorService
{
    Task<GenerationResult> GenerateAsync(Stream metadataStream, string? outputFolder, CancellationToken cancellationToken);
}
