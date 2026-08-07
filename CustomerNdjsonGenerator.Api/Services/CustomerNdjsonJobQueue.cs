using System.Collections.Concurrent;
using System.Threading.Channels;
using CustomerNdjsonGenerator.Api.Models;

namespace CustomerNdjsonGenerator.Api.Services;

public sealed class CustomerNdjsonJobQueue : ICustomerNdjsonJobQueue
{
    private readonly ConcurrentDictionary<Guid, CustomerNdjsonJob> jobs = new();
    private readonly Channel<CustomerNdjsonJob> channel = Channel.CreateUnbounded<CustomerNdjsonJob>();

    public CustomerNdjsonJob Enqueue(CustomerNdjsonGenerationRequest request)
    {
        CustomerNdjsonFileGenerator.Validate(request);

        var job = new CustomerNdjsonJob
        {
            Request = EnsureJobFileName(request)
        };

        jobs[job.JobId] = job;
        channel.Writer.TryWrite(job);

        return job;
    }

    public CustomerNdjsonJob? Get(Guid jobId)
        => jobs.TryGetValue(jobId, out var job) ? job : null;

    public IReadOnlyCollection<CustomerNdjsonJob> GetAll()
        => jobs.Values.OrderByDescending(job => job.CreatedOnUtc).ToArray();

    public ValueTask<CustomerNdjsonJob> DequeueAsync(CancellationToken cancellationToken)
        => channel.Reader.ReadAsync(cancellationToken);

    private static CustomerNdjsonGenerationRequest EnsureJobFileName(CustomerNdjsonGenerationRequest request)
    {
        if (!string.IsNullOrWhiteSpace(request.FileName))
        {
            return request;
        }

        return new CustomerNdjsonGenerationRequest
        {
            RecordCount = request.RecordCount,
            StartCustomerSequence = request.StartCustomerSequence,
            FileName = $"customers-job-{DateTimeOffset.UtcNow:yyyyMMdd-HHmmssfff}.ndjson",
            CountryId = request.CountryId,
            CurrencyId = request.CurrencyId,
            SalesOrganizationId = request.SalesOrganizationId,
            PaymentTermId = request.PaymentTermId
        };
    }
}
