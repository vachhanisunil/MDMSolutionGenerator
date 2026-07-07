namespace MdmSolutionGenerator.Generation;

public interface IMdmSolutionGenerator
{
    Task<GenerationResult> GenerateAsync(Stream metadataStream, string? outputFolder, CancellationToken cancellationToken);
}
