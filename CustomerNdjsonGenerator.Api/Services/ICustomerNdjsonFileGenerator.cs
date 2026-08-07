using CustomerNdjsonGenerator.Api.Models;

namespace CustomerNdjsonGenerator.Api.Services;

public interface ICustomerNdjsonFileGenerator
{
    Task<CustomerNdjsonGenerationResult> GenerateAsync(
        CustomerNdjsonGenerationRequest request,
        IProgress<long>? progress,
        CancellationToken cancellationToken);
}
