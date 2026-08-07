# Customer NDJSON Generator

Standalone ASP.NET Core API for generating large NDJSON files containing synthetic customer business objects.

## Run

```powershell
dotnet run --project CustomerNdjsonGenerator.Api.csproj
```

Then open `http://localhost:5221/swagger`.

If the build fails because `CustomerNdjsonGenerator.Api.exe` is being used by another process, stop the previous API instance and run again:

```powershell
Get-Process -Name CustomerNdjsonGenerator.Api -ErrorAction SilentlyContinue | Stop-Process
dotnet run --project CustomerNdjsonGenerator.Api.csproj
```

## Generate A Small File From Swagger

1. Open `http://localhost:5221/swagger`.
2. Expand `POST /api/customers/ndjson`.
3. Click `Try it out`.
4. Use this request body.

```json
{
  "recordCount": 1000000,
  "startCustomerSequence": 10001,
  "fileName": "customers-1m.ndjson",
  "countryId": 1,
  "currencyId": 1,
  "salesOrganizationId": 1,
  "paymentTermId": 1
}
```

5. Click `Execute`.

This endpoint keeps the HTTP request open until the file is finished, so use it for small test files.

## Generate A Large File In The Background

Use the background job endpoint for large files such as 1,000,000+ records.

1. Open `http://localhost:5221/swagger`.
2. Expand `POST /api/customers/ndjson/jobs`.
3. Click `Try it out`.
4. Use this request body.

```json
{
  "recordCount": 1000000,
  "startCustomerSequence": 10001,
  "fileName": "customers-1m.ndjson",
  "countryId": 1,
  "currencyId": 1,
  "salesOrganizationId": 1,
  "paymentTermId": 1
}
```

5. Click `Execute`.
6. Copy the returned `jobId`.
7. Expand `GET /api/customers/ndjson/jobs/{jobId}` and execute it with that `jobId` to check progress.
8. When the status is `Completed`, use `GET /api/customers/ndjson/jobs/{jobId}/download` to download the file.

You can also use `GET /api/customers/ndjson/jobs` to see all jobs from the current API process.

## Generate A File From PowerShell

```powershell
Invoke-RestMethod `
  -Method Post `
  -Uri http://localhost:5221/api/customers/ndjson `
  -ContentType 'application/json' `
  -Body '{
    "recordCount": 1000000,
    "startCustomerSequence": 10001,
    "fileName": "customers-1m.ndjson",
    "countryId": 1,
    "currencyId": 1,
    "salesOrganizationId": 1,
    "paymentTermId": 1
  }'
```

Files are written to `DataExports` under the API project directory.

The generator streams one customer object at a time, so it can produce millions of records without keeping the full dataset in memory. Unique values such as `customerNumber`, `customerName`, `email`, `registrationNumber`, bank account number, tax number, and attachment path are derived from the sequence number. Lookup values such as `countryId` and `currencyId` can intentionally repeat across all records.
