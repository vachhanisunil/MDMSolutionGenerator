# MDM Solution Generator

Console generator that accepts MDM metadata JSON and emits a buildable .NET 9 Clean Architecture solution with API, Application, Core, and Infrastructure projects.

## Run

```powershell
dotnet run --project .\MdmSolutionGenerator.csproj -- --metadata sample-metadata.json --output generated-out
```

## Verification Path

```powershell
dotnet run -- --metadata sample-metadata.json --output generated-out
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
