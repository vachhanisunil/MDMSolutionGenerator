using System.Text.Json.Serialization;
using CustomerNdjsonGenerator.Api.Models;
using CustomerNdjsonGenerator.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddSingleton<ICustomerNdjsonFileGenerator, CustomerNdjsonFileGenerator>();
builder.Services.AddSingleton<ICustomerNdjsonJobQueue, CustomerNdjsonJobQueue>();
builder.Services.AddHostedService<CustomerNdjsonJobWorker>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/api/customers/ndjson", async (
    CustomerNdjsonGenerationRequest request,
    ICustomerNdjsonFileGenerator generator,
    CancellationToken cancellationToken) =>
{
    try
    {
        var result = await generator.GenerateAsync(request, progress: null, cancellationToken);
        return Results.Ok(result);
    }
    catch (ArgumentOutOfRangeException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("GenerateCustomerNdjson")
.WithSummary("Generates an NDJSON file containing synthetic customer business objects.")
.WithDescription("Writes one customer JSON object per line. Unique fields are derived from the customer sequence so millions of rows can be generated without duplicates.")
.Produces<CustomerNdjsonGenerationResult>()
.Produces(StatusCodes.Status400BadRequest);

app.MapPost("/api/customers/ndjson/jobs", (
    CustomerNdjsonGenerationRequest request,
    ICustomerNdjsonJobQueue queue) =>
{
    try
    {
        var job = queue.Enqueue(request);
        var jobDto = ToJobDto(job);
        return Results.Accepted(jobDto.StatusUrl, jobDto);
    }
    catch (ArgumentOutOfRangeException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("StartCustomerNdjsonJob")
.WithSummary("Starts a background NDJSON generation job.")
.WithDescription("Use this endpoint for large files such as 1,000,000+ records. It returns immediately with a job id while generation continues in the background.")
.Produces<CustomerNdjsonJobDto>(StatusCodes.Status202Accepted)
.Produces(StatusCodes.Status400BadRequest);

app.MapGet("/api/customers/ndjson/jobs", (ICustomerNdjsonJobQueue queue) =>
    Results.Ok(queue.GetAll().Select(ToJobDto)))
.WithName("GetCustomerNdjsonJobs")
.WithSummary("Lists background NDJSON generation jobs.")
.Produces<IEnumerable<CustomerNdjsonJobDto>>();

app.MapGet("/api/customers/ndjson/jobs/{jobId:guid}", (Guid jobId, ICustomerNdjsonJobQueue queue) =>
{
    var job = queue.Get(jobId);
    return job is null ? Results.NotFound() : Results.Ok(ToJobDto(job));
})
.WithName("GetCustomerNdjsonJob")
.WithSummary("Gets the status and progress for a background NDJSON generation job.")
.Produces<CustomerNdjsonJobDto>()
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/api/customers/ndjson/jobs/{jobId:guid}/download", (Guid jobId, ICustomerNdjsonJobQueue queue) =>
{
    var job = queue.Get(jobId);
    if (job is null)
    {
        return Results.NotFound();
    }

    if (job.Status != CustomerNdjsonJobStatus.Completed || string.IsNullOrWhiteSpace(job.FilePath))
    {
        return Results.BadRequest(new { error = "The NDJSON file is not ready for download yet." });
    }

    if (!File.Exists(job.FilePath))
    {
        return Results.NotFound(new { error = "The generated file could not be found on disk." });
    }

    return Results.File(job.FilePath, "application/x-ndjson", job.FileName ?? Path.GetFileName(job.FilePath));
})
.WithName("DownloadCustomerNdjsonJobFile")
.WithSummary("Downloads the generated NDJSON file for a completed background job.")
.Produces(StatusCodes.Status200OK, contentType: "application/x-ndjson")
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status404NotFound);

app.Run();

static CustomerNdjsonJobDto ToJobDto(CustomerNdjsonJob job)
{
    var progressPercent = job.Request.RecordCount == 0
        ? 0
        : Math.Round(job.GeneratedCount * 100m / job.Request.RecordCount, 2);

    return new CustomerNdjsonJobDto
    {
        JobId = job.JobId,
        Status = job.Status,
        RecordCount = job.Request.RecordCount,
        GeneratedCount = job.GeneratedCount,
        ProgressPercent = progressPercent,
        FileName = job.FileName,
        FilePath = job.FilePath,
        FileSizeBytes = job.FileSizeBytes,
        ErrorMessage = job.ErrorMessage,
        CreatedOnUtc = job.CreatedOnUtc,
        StartedOnUtc = job.StartedOnUtc,
        CompletedOnUtc = job.CompletedOnUtc,
        StatusUrl = $"/api/customers/ndjson/jobs/{job.JobId}",
        DownloadUrl = job.Status == CustomerNdjsonJobStatus.Completed
            ? $"/api/customers/ndjson/jobs/{job.JobId}/download"
            : null
    };
}
