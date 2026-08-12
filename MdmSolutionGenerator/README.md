# SolutionGeneratorService

Console generator that accepts MDM metadata JSON and emits a compact, buildable .NET 9 ASP.NET Core solution.

The default generated solution is intentionally a single project. It avoids CQRS and the four-project Clean Architecture layout so generated artifacts stay small and easier to navigate.

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

- One ASP.NET Core Web API project
- Entity classes
- DTO classes
- Per-entity controllers
- A shared generic CRUD service
- EF Core `AppDbContext` with inline model configuration
- Swagger registration
- Search request support with filtering, sorting, and pagination
- A compact analysis controller/service for business object runs, profiling summaries, and rule results
