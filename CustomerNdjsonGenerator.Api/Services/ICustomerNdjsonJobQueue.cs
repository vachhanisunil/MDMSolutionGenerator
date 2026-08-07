using CustomerNdjsonGenerator.Api.Models;

namespace CustomerNdjsonGenerator.Api.Services;

public interface ICustomerNdjsonJobQueue
{
    CustomerNdjsonJob Enqueue(CustomerNdjsonGenerationRequest request);
    CustomerNdjsonJob? Get(Guid jobId);
    IReadOnlyCollection<CustomerNdjsonJob> GetAll();
    ValueTask<CustomerNdjsonJob> DequeueAsync(CancellationToken cancellationToken);
}
