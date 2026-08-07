using CustomerNdjsonGenerator.Api.Models;

namespace CustomerNdjsonGenerator.Api.Services;

public sealed class CustomerNdjsonJobWorker(
    ICustomerNdjsonJobQueue queue,
    ICustomerNdjsonFileGenerator generator,
    ILogger<CustomerNdjsonJobWorker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var job = await queue.DequeueAsync(stoppingToken);
            await RunJobAsync(job, stoppingToken);
        }
    }

    private async Task RunJobAsync(CustomerNdjsonJob job, CancellationToken stoppingToken)
    {
        try
        {
            job.Status = CustomerNdjsonJobStatus.Running;
            job.StartedOnUtc = DateTimeOffset.UtcNow;

            var progress = new Progress<long>(generatedCount => job.GeneratedCount = generatedCount);
            var result = await generator.GenerateAsync(job.Request, progress, stoppingToken);

            job.GeneratedCount = result.RecordCount;
            job.FileName = result.FileName;
            job.FilePath = result.FilePath;
            job.FileSizeBytes = result.FileSizeBytes;
            job.CompletedOnUtc = result.GeneratedOnUtc;
            job.Status = CustomerNdjsonJobStatus.Completed;
        }
        catch (OperationCanceledException)
        {
            job.Status = CustomerNdjsonJobStatus.Canceled;
            job.CompletedOnUtc = DateTimeOffset.UtcNow;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Customer NDJSON job {JobId} failed.", job.JobId);
            job.Status = CustomerNdjsonJobStatus.Failed;
            job.ErrorMessage = ex.Message;
            job.CompletedOnUtc = DateTimeOffset.UtcNow;
        }
    }
}
