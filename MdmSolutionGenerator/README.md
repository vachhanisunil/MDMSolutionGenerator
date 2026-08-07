# SolutionGeneratorService

Console generator that accepts MDM metadata JSON and emits a buildable .NET 9 Clean Architecture solution with API, Application, Core, and Infrastructure projects.

## Run

```powershell
dotnet run --project .\SolutionGeneratorService.csproj -- --metadata entities-metadata.json --output generated-out
```

## Split Metadata Support

`SolutionGeneratorService` accepts metadata in two supported shapes:

- Entity metadata: only `application`, `entities`, and `relationships`.
- Business-object metadata: only `application` and `businessObjects`, where each business object lists its associated entities plus profiling and data quality rules.

The service intentionally rejects full metadata files that contain both `entities` and `businessObjects` in the same JSON.

After generation, the service stores the normalized metadata in:

```text
<output>\<solution-name>\.solution-generator\metadata.json
```

On the next run, the service loads this manifest and merges only the uploaded slice:

- Entity-only upload updates only the entities and relationships included in that file.
- Business-object-only upload updates only the business objects included in that file.
- Existing entities, business objects, profiling rules, and data quality rules that are not part of the uploaded metadata remain untouched.

Run entity metadata first when creating a solution from split files:

```powershell
dotnet run --project .\SolutionGeneratorService.csproj -- --metadata entities-metadata.json --output generated-out
dotnet run --project .\SolutionGeneratorService.csproj -- --metadata business-objects-metadata.json --output generated-out
```

## Verification Path

```powershell
dotnet run --project .\SolutionGeneratorService.csproj -- --metadata entities-metadata.json --output generated-out
dotnet run --project .\SolutionGeneratorService.csproj -- --metadata business-objects-metadata.json --output generated-out
dotnet restore .\generated-out\GeneratedSolution\GeneratedSolution.sln
dotnet build .\generated-out\GeneratedSolution\GeneratedSolution.sln --no-restore
```

The generated solution includes:

- Clean Architecture projects: API, Application, Core, Infrastructure
- CQRS commands, queries, handlers, DTOs, validators, and AutoMapper profiles
- EF Core `AppDbContext`, entity configurations, repository implementation, and starter migration
- MediatR validation pipeline behavior
- ASP.NET Core controllers, Swagger registration, DI extensions, and exception middleware
- Search request support with filtering, sorting, and pagination
