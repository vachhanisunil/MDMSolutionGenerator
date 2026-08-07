using System.Text.Encodings.Web;
using System.Text.Json;
using CustomerNdjsonGenerator.Api.Models;

namespace CustomerNdjsonGenerator.Api.Services;

public sealed class CustomerNdjsonFileGenerator(IWebHostEnvironment environment) : ICustomerNdjsonFileGenerator
{
    private static readonly byte[] NewLine = [(byte)'\n'];

    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = false
    };

    public async Task<CustomerNdjsonGenerationResult> GenerateAsync(
        CustomerNdjsonGenerationRequest request,
        IProgress<long>? progress,
        CancellationToken cancellationToken)
    {
        Validate(request);

        var exportsDirectory = Path.Combine(environment.ContentRootPath, "DataExports");
        Directory.CreateDirectory(exportsDirectory);

        var fileName = GetSafeFileName(request.FileName);
        var filePath = Path.Combine(exportsDirectory, fileName);

        await using var stream = new FileStream(
            filePath,
            FileMode.Create,
            FileAccess.Write,
            FileShare.Read,
            bufferSize: 1024 * 1024,
            useAsync: true);

        for (var offset = 0L; offset < request.RecordCount; offset++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var sequence = checked(request.StartCustomerSequence + offset);
            var customer = CustomerBusinessObjectFactory.Create(sequence, request);

            await JsonSerializer.SerializeAsync(stream, customer, SerializerOptions, cancellationToken);
            await stream.WriteAsync(NewLine, cancellationToken);

            var generatedCount = offset + 1;
            if (generatedCount % 1_000 == 0 || generatedCount == request.RecordCount)
            {
                progress?.Report(generatedCount);
            }
        }

        await stream.FlushAsync(cancellationToken);

        var fileInfo = new FileInfo(filePath);
        return new CustomerNdjsonGenerationResult
        {
            RecordCount = request.RecordCount,
            FileName = fileInfo.Name,
            FilePath = fileInfo.FullName,
            FileSizeBytes = fileInfo.Length,
            GeneratedOnUtc = DateTimeOffset.UtcNow
        };
    }

    public static void Validate(CustomerNdjsonGenerationRequest request)
    {
        if (request.RecordCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(request.RecordCount), "RecordCount must be greater than zero.");
        }

        if (request.StartCustomerSequence <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(request.StartCustomerSequence), "StartCustomerSequence must be greater than zero.");
        }

        if (request.RecordCount > long.MaxValue - request.StartCustomerSequence)
        {
            throw new ArgumentOutOfRangeException(nameof(request.RecordCount), "RecordCount and StartCustomerSequence exceed the supported sequence range.");
        }
    }

    private static string GetSafeFileName(string? requestedFileName)
    {
        var fileName = string.IsNullOrWhiteSpace(requestedFileName)
            ? $"customers-{DateTimeOffset.UtcNow:yyyyMMdd-HHmmss}.ndjson"
            : requestedFileName.Trim();

        if (!fileName.EndsWith(".ndjson", StringComparison.OrdinalIgnoreCase))
        {
            fileName += ".ndjson";
        }

        foreach (var invalidCharacter in Path.GetInvalidFileNameChars())
        {
            fileName = fileName.Replace(invalidCharacter, '-');
        }

        return fileName;
    }
}
