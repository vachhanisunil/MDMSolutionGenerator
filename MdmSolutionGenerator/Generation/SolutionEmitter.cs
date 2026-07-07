using System.Text;
using MdmSolutionGenerator.Generation.DataQuality;

namespace MdmSolutionGenerator.Generation;

internal sealed record GeneratedFile(string RelativePath, string Content);

internal sealed class SolutionEmitter(MetadataDocument metadata, string solutionName)
{
    private readonly string _rootNamespace = Naming.NamespacePart(metadata.Application.Namespace ?? solutionName);

    public IEnumerable<GeneratedFile> Emit()
    {
        yield return File($"{solutionName}.sln", EmitSolutionFile());
        yield return File($"{solutionName}.Core/{solutionName}.Core.csproj", EmitCoreProject());
        yield return File($"{solutionName}.Application/{solutionName}.Application.csproj", EmitApplicationProject());
        yield return File($"{solutionName}.Infrastructure/{solutionName}.Infrastructure.csproj", EmitInfrastructureProject());
        yield return File($"{solutionName}.API/{solutionName}.API.csproj", EmitApiProject());

        yield return File($"{solutionName}.Core/Entities/BaseEntity.cs", EmitBaseEntity());
        yield return File($"{solutionName}.Core/Interfaces/IRepository.cs", EmitRepositoryInterface());
        foreach (var generatedFile in EmitAnalysisCoreEntities())
        {
            yield return generatedFile;
        }
        foreach (var entity in metadata.Entities)
        {
            yield return File($"{solutionName}.Core/Entities/{entity.Name}.cs", EmitEntity(entity));
        }

        yield return File($"{solutionName}.Core/Common/SearchRequest.cs", EmitSearchRequest());
        yield return File($"{solutionName}.Core/Common/PagedResult.cs", EmitPagedResult());
        yield return File($"{solutionName}.Application/Common/ValidationBehavior.cs", EmitValidationBehavior());
        yield return File($"{solutionName}.Application/Common/IAnalysisDbContext.cs", EmitAnalysisDbContextInterface());
        yield return File($"{solutionName}.Application/DependencyInjection.cs", EmitApplicationDi());
        foreach (var entity in metadata.Entities)
        {
            foreach (var generatedFile in EmitApplicationModule(entity))
            {
                yield return generatedFile;
            }
        }
        foreach (var businessObject in BusinessObjects())
        {
            foreach (var generatedFile in EmitBusinessObjectAnalysisModule(businessObject))
            {
                yield return generatedFile;
            }
        }

        yield return File($"{solutionName}.Infrastructure/Persistence/AppDbContext.cs", EmitDbContext());
        yield return File($"{solutionName}.Infrastructure/Repositories/EfRepository.cs", EmitEfRepository());
        yield return File($"{solutionName}.Infrastructure/DependencyInjection.cs", EmitInfrastructureDi());
        yield return File($"{solutionName}.Infrastructure/Migrations/20260626000000_InitialCreate.cs", EmitInitialMigration());
        yield return File($"{solutionName}.Infrastructure/Persistence/Configurations/BusinessObjectRunConfiguration.cs", EmitAnalysisConfiguration("BusinessObjectRun", "RunId", "BusinessObjectRuns"));
        yield return File($"{solutionName}.Infrastructure/Persistence/Configurations/DataProfilingSummaryConfiguration.cs", EmitAnalysisConfiguration("DataProfilingSummary", "SummaryId", "DataProfilingSummaries"));
        yield return File($"{solutionName}.Infrastructure/Persistence/Configurations/DataProfilingDrilldownConfiguration.cs", EmitAnalysisConfiguration("DataProfilingDrilldown", "DrilldownId", "DataProfilingDrilldowns"));
        yield return File($"{solutionName}.Infrastructure/Persistence/Configurations/DataQualityRuleResultConfiguration.cs", EmitAnalysisConfiguration("DataQualityRuleResult", "ResultId", "DataQualityRuleResults"));
        yield return File($"{solutionName}.Infrastructure/Persistence/Configurations/DataQualityRuleSummaryConfiguration.cs", EmitAnalysisConfiguration("DataQualityRuleSummary", "RuleSummaryId", "DataQualityRuleSummaries"));
        yield return File($"{solutionName}.Infrastructure/Persistence/Configurations/DataQualityDrilldownConfiguration.cs", EmitAnalysisConfiguration("DataQualityDrilldown", "DrilldownId", "DataQualityDrilldowns"));
        foreach (var entity in metadata.Entities)
        {
            yield return File($"{solutionName}.Infrastructure/Persistence/Configurations/{entity.Name}Configuration.cs", EmitEntityConfiguration(entity));
        }

        yield return File($"{solutionName}.API/Program.cs", EmitApiProgram());
        yield return File($"{solutionName}.API/appsettings.json", EmitApiSettings());
        yield return File($"{solutionName}.API/Middleware/ExceptionHandlingMiddleware.cs", EmitExceptionMiddleware());
        foreach (var entity in metadata.Entities)
        {
            yield return File($"{solutionName}.API/Controllers/{Naming.Plural(entity.Name)}Controller.cs", EmitController(entity));
        }
        foreach (var businessObject in BusinessObjects())
        {
            yield return File($"{solutionName}.API/Controllers/{businessObject.Name}AnalysisController.cs", EmitAnalysisController(businessObject));
        }
    }

    private static GeneratedFile File(string relativePath, string content) => new(relativePath.Replace('\\', '/'), content);

    private IEnumerable<EntityDefinition> BusinessEntities()
    {
        if (metadata.BusinessObjects.Count == 0)
        {
            return metadata.Entities;
        }

        var names = metadata.BusinessObjects
            .Select(b => Naming.Pascal(b.Entity ?? b.Name))
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return metadata.Entities.Where(e => names.Contains(e.Name));
    }

    private IEnumerable<BusinessObjectDefinition> BusinessObjects()
        => metadata.BusinessObjects.Count == 0
            ? metadata.Entities.Select(e => new BusinessObjectDefinition { Name = e.Name, Entity = e.Name, RootEntity = e.Name, Entities = [e.Name] })
            : metadata.BusinessObjects;

    private string EmitSolutionFile()
    {
        var apiGuid = Guid.NewGuid().ToString("B").ToUpperInvariant();
        var appGuid = Guid.NewGuid().ToString("B").ToUpperInvariant();
        var coreGuid = Guid.NewGuid().ToString("B").ToUpperInvariant();
        var infraGuid = Guid.NewGuid().ToString("B").ToUpperInvariant();
        const string csharpProjectType = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";

        return $$"""
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.0.31903.59
MinimumVisualStudioVersion = 10.0.40219.1
Project("{{csharpProjectType}}") = "{{solutionName}}.API", "{{solutionName}}.API\{{solutionName}}.API.csproj", "{{apiGuid}}"
EndProject
Project("{{csharpProjectType}}") = "{{solutionName}}.Application", "{{solutionName}}.Application\{{solutionName}}.Application.csproj", "{{appGuid}}"
EndProject
Project("{{csharpProjectType}}") = "{{solutionName}}.Core", "{{solutionName}}.Core\{{solutionName}}.Core.csproj", "{{coreGuid}}"
EndProject
Project("{{csharpProjectType}}") = "{{solutionName}}.Infrastructure", "{{solutionName}}.Infrastructure\{{solutionName}}.Infrastructure.csproj", "{{infraGuid}}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{{apiGuid}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{apiGuid}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{apiGuid}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{apiGuid}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{appGuid}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{appGuid}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{appGuid}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{appGuid}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{coreGuid}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{coreGuid}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{coreGuid}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{coreGuid}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{infraGuid}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{infraGuid}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{infraGuid}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{infraGuid}}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
EndGlobal
""";
    }

    private string EmitCoreProject() => $$"""
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
  </PropertyGroup>
</Project>
""";

    private string EmitApplicationProject() => $$"""
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="..\{{solutionName}}.Core\{{solutionName}}.Core.csproj" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="AutoMapper" Version="16.1.1" />
    <PackageReference Include="FluentValidation" Version="11.11.0" />
    <PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="11.11.0" />
    <PackageReference Include="MediatR" Version="12.4.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.1" />
  </ItemGroup>
</Project>
""";

    private string EmitInfrastructureProject() => $$"""
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="..\{{solutionName}}.Application\{{solutionName}}.Application.csproj" />
    <ProjectReference Include="..\{{solutionName}}.Core\{{solutionName}}.Core.csproj" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.1">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="9.0.4" />
  </ItemGroup>
</Project>
""";

    private string EmitApiProject() => $$"""
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="..\{{solutionName}}.Application\{{solutionName}}.Application.csproj" />
    <ProjectReference Include="..\{{solutionName}}.Infrastructure\{{solutionName}}.Infrastructure.csproj" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="Swashbuckle.AspNetCore" Version="9.0.1" />
  </ItemGroup>
</Project>
""";

    private string EmitBaseEntity() => $$"""
namespace {{_rootNamespace}}.Core.Entities;

public abstract class BaseEntity
{
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreatedOn { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedOn { get; set; }
}
""";

    private string EmitRepositoryInterface() => $$"""
using {{_rootNamespace}}.Core.Common;

namespace {{_rootNamespace}}.Core.Interfaces;

public interface IRepository<TEntity>
    where TEntity : class
{
    Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(object id, IReadOnlyList<string> includes, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TEntity>> ListAsync(CancellationToken cancellationToken = default);
    Task<PagedResult<TEntity>> SearchAsync(SearchRequest request, CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void ReplaceCollection<TChild>(ICollection<TChild> existingItems, IEnumerable<TChild> replacementItems)
        where TChild : class;
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
""";

    private IEnumerable<GeneratedFile> EmitAnalysisCoreEntities()
    {
        yield return File($"{solutionName}.Core/DataQuality/BusinessObjectRun.cs", $$"""
namespace {{_rootNamespace}}.Core.DataQuality;

public sealed class BusinessObjectRun : {{_rootNamespace}}.Core.Entities.BaseEntity
{
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string RootEntityName { get; set; } = string.Empty;
    public string RunType { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset StartedOn { get; set; }
    public DateTimeOffset? CompletedOn { get; set; }
    public string TriggeredBy { get; set; } = string.Empty;
    public int TotalRootRecords { get; set; }
    public decimal? OverallScore { get; set; }
    public string? ErrorMessage { get; set; }
}
""");

        yield return File($"{solutionName}.Core/DataQuality/DataProfilingSummary.cs", $$"""
namespace {{_rootNamespace}}.Core.DataQuality;

public sealed class DataProfilingSummary : {{_rootNamespace}}.Core.Entities.BaseEntity
{
    public Guid SummaryId { get; set; }
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? FieldName { get; set; }
    public string? ColumnName { get; set; }
    public string SummaryCode { get; set; } = string.Empty;
    public string SummaryType { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string? Severity { get; set; }
    public string MetricName { get; set; } = string.Empty;
    public string MetricType { get; set; } = string.Empty;
    public decimal MetricValue { get; set; }
    public int AffectedCount { get; set; }
    public bool HasDrilldown { get; set; }
    public string? DrilldownKey { get; set; }
    public decimal? NumericValue { get; set; }
    public string? TextValue { get; set; }
    public decimal? Score { get; set; }
    public new DateTimeOffset CreatedOn { get; set; }
}
""");

        yield return File($"{solutionName}.Core/DataQuality/DataProfilingDrilldown.cs", $$"""
namespace {{_rootNamespace}}.Core.DataQuality;

public sealed class DataProfilingDrilldown : {{_rootNamespace}}.Core.Entities.BaseEntity
{
    public Guid DrilldownId { get; set; }
    public Guid RunId { get; set; }
    public Guid SummaryId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? RootRecordId { get; set; }
    public string? RecordId { get; set; }
    public string? ColumnName { get; set; }
    public string SummaryCode { get; set; } = string.Empty;
    public string SummaryType { get; set; } = string.Empty;
    public string? FieldValue { get; set; }
    public string Message { get; set; } = string.Empty;
    public string RecordSnapshotJson { get; set; } = string.Empty;
    public string SnapshotJson { get; set; } = string.Empty;
    public new DateTimeOffset CreatedOn { get; set; }
}
""");

        yield return File($"{solutionName}.Core/DataQuality/DataQualityRuleSummary.cs", $$"""
namespace {{_rootNamespace}}.Core.DataQuality;

public sealed class DataQualityRuleSummary : {{_rootNamespace}}.Core.Entities.BaseEntity
{
    public Guid RuleSummaryId { get; set; }
    public Guid RunId { get; set; }
    public string RuleCode { get; set; } = string.Empty;
    public string RuleName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int AffectedCount { get; set; }
    public decimal Score { get; set; }
}
""");

        yield return File($"{solutionName}.Core/DataQuality/DataQualityRuleResult.cs", $$"""
namespace {{_rootNamespace}}.Core.DataQuality;

public sealed class DataQualityRuleResult : {{_rootNamespace}}.Core.Entities.BaseEntity
{
    public Guid ResultId { get; set; }
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string RuleCode { get; set; } = string.Empty;
    public string RuleName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int AffectedCount { get; set; }
    public decimal Score { get; set; }
    public new DateTimeOffset CreatedOn { get; set; }
}
""");

        yield return File($"{solutionName}.Core/DataQuality/DataQualityDrilldown.cs", $$"""
namespace {{_rootNamespace}}.Core.DataQuality;

public sealed class DataQualityDrilldown : {{_rootNamespace}}.Core.Entities.BaseEntity
{
    public Guid DrilldownId { get; set; }
    public Guid RunId { get; set; }
    public Guid RuleSummaryId { get; set; }
    public Guid? ResultId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? RootRecordId { get; set; }
    public string? RecordId { get; set; }
    public string RuleCode { get; set; } = string.Empty;
    public string? FieldName { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? FieldValue { get; set; }
    public string RecordSnapshotJson { get; set; } = string.Empty;
    public string SnapshotJson { get; set; } = string.Empty;
    public new DateTimeOffset CreatedOn { get; set; }
}
""");
    }

    private string EmitEntity(EntityDefinition entity)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"namespace {_rootNamespace}.Core.Entities;");
        builder.AppendLine();
        builder.AppendLine($"public class {entity.Name} : BaseEntity");
        builder.AppendLine("{");

        foreach (var property in entity.Properties)
        {
            builder.AppendLine($"    public {ClrType(property, forEntity: true)} {property.Name} {{ get; set; }}{DefaultValue(property)}");
        }

        foreach (var relationship in metadata.Relationships.Where(r => Matches(r.From, entity.Name) || Matches(r.To, entity.Name)))
        {
            AppendNavigation(builder, entity, relationship);
        }

        builder.AppendLine("}");
        return builder.ToString();
    }

    private string EmitSearchRequest() => $$"""
namespace {{_rootNamespace}}.Core.Common;

public class SearchRequest
{
    public List<SearchFilter> Filters { get; init; } = [];
    public string? SortBy { get; init; }
    public bool SortDescending { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 20;
}

public sealed class SearchFilter
{
    public string Field { get; init; } = "";
    public string Operator { get; init; } = "equals";
    public string? Value { get; init; }
}
""";

    private string EmitPagedResult() => $$"""
namespace {{_rootNamespace}}.Core.Common;

public sealed class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; init; } = [];
    public int TotalCount { get; init; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}
""";

    private string EmitValidationBehavior() => $$"""
using FluentValidation;
using MediatR;

namespace {{_rootNamespace}}.Application.Common;

public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(error => error is not null)
            .ToList();

        if (failures.Count > 0)
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}
""";

    private string EmitAnalysisDbContextInterface()
    {
        var entitySets = metadata.Entities.Select(e => $"    DbSet<{e.Name}> {Naming.Plural(e.Name)} {{ get; }}");
        var sets = string.Join(Environment.NewLine, entitySets.Concat([
            "    DbSet<BusinessObjectRun> BusinessObjectRuns { get; }",
            "    DbSet<DataProfilingSummary> DataProfilingSummaries { get; }",
            "    DbSet<DataProfilingDrilldown> DataProfilingDrilldowns { get; }",
            "    DbSet<DataQualityRuleResult> DataQualityRuleResults { get; }",
            "    DbSet<DataQualityRuleSummary> DataQualityRuleSummaries { get; }",
            "    DbSet<DataQualityDrilldown> DataQualityDrilldowns { get; }"
        ]));

        return $$"""
using Microsoft.EntityFrameworkCore;
using {{_rootNamespace}}.Core.DataQuality;
using {{_rootNamespace}}.Core.Entities;

namespace {{_rootNamespace}}.Application.Common;

public interface IAnalysisDbContext
{
{{sets}}
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
""";
    }

    private string EmitApplicationDi() => $$"""
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using {{_rootNamespace}}.Application.Common;
{{ApplicationRunServiceUsings()}}

namespace {{_rootNamespace}}.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(_ => { }, typeof(DependencyInjection).Assembly);
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
{{ApplicationRunServiceRegistrations()}}
        return services;
    }
}
""";

    private string ApplicationRunServiceUsings()
        => string.Join(Environment.NewLine, BusinessObjects().SelectMany(b => new[]
        {
            $"using {_rootNamespace}.Application.Modules.{b.Name}.Interfaces;",
            $"using {_rootNamespace}.Application.Modules.{b.Name}.Services;"
        }));

    private string ApplicationRunServiceRegistrations()
        => string.Join(Environment.NewLine, BusinessObjects().SelectMany(b => new[]
        {
            $"        services.AddScoped<I{b.Name}RunService, {b.Name}RunService>();",
            $"        services.AddScoped<{_rootNamespace}.Application.Modules.{b.Name}.DataQuality.Services.{b.Name}Profiler>();",
            $"        services.AddScoped<{_rootNamespace}.Application.Modules.{b.Name}.DataQuality.Services.{b.Name}DataQualityRuleExecutor>();"
        }));

    private IEnumerable<GeneratedFile> EmitApplicationModule(EntityDefinition entity)
    {
        var module = $"{solutionName}.Application/Modules/{entity.Name}";
        yield return File($"{module}/DTOs/{entity.Name}Dto.cs", EmitDto(entity));
        yield return File($"{module}/DTOs/Create{entity.Name}Dto.cs", EmitMutateDto(entity, "Create"));
        yield return File($"{module}/DTOs/Update{entity.Name}Dto.cs", EmitMutateDto(entity, "Update"));
        yield return File($"{module}/DTOs/Search{entity.Name}Dto.cs", EmitSearchDto(entity));
        yield return File($"{module}/Mappings/{entity.Name}Profile.cs", EmitProfile(entity));
        yield return File($"{module}/Commands/Create{entity.Name}Command.cs", EmitCreateCommand(entity));
        yield return File($"{module}/Commands/Update{entity.Name}Command.cs", EmitUpdateCommand(entity));
        yield return File($"{module}/Commands/Delete{entity.Name}Command.cs", EmitDeleteCommand(entity));
        yield return File($"{module}/Queries/Get{entity.Name}ByIdQuery.cs", EmitGetByIdQuery(entity));
        yield return File($"{module}/Queries/Search{Naming.Plural(entity.Name)}Query.cs", EmitSearchQuery(entity));
        yield return File($"{module}/Handlers/Create{entity.Name}Handler.cs", EmitCreateHandler(entity));
        yield return File($"{module}/Handlers/Update{entity.Name}Handler.cs", EmitUpdateHandler(entity));
        yield return File($"{module}/Handlers/Delete{entity.Name}Handler.cs", EmitDeleteHandler(entity));
        yield return File($"{module}/Handlers/Get{entity.Name}ByIdHandler.cs", EmitGetByIdHandler(entity));
        yield return File($"{module}/Handlers/Search{Naming.Plural(entity.Name)}Handler.cs", EmitSearchHandler(entity));
        yield return File($"{module}/Validators/Create{entity.Name}CommandValidator.cs", EmitValidator(entity, "Create"));
        yield return File($"{module}/Validators/Update{entity.Name}CommandValidator.cs", EmitValidator(entity, "Update"));
    }

    private IEnumerable<GeneratedFile> EmitBusinessObjectAnalysisModule(BusinessObjectDefinition businessObject)
    {
        var root = RootEntity(businessObject);
        if (root is null)
        {
            yield break;
        }

        var module = $"{solutionName}.Application/Modules/{businessObject.Name}";
        yield return File($"{module}/DTOs/{businessObject.Name}AnalysisDtos.cs", EmitAnalysisDtos(businessObject, root));
        yield return File($"{module}/Commands/Run{businessObject.Name}AnalysisCommand.cs", EmitRunAnalysisCommand(businessObject));
        yield return File($"{module}/Commands/Execute{businessObject.Name}AnalysisRunCommand.cs", EmitExecuteAnalysisRunCommand(businessObject));
        yield return File($"{module}/Queries/Get{businessObject.Name}RunsQuery.cs", EmitGetRunsQuery(businessObject));
        yield return File($"{module}/Queries/Get{businessObject.Name}RunQuery.cs", EmitGetRunQuery(businessObject));
        yield return File($"{module}/Queries/Get{businessObject.Name}ProfilingSummaryQuery.cs", EmitGetProfilingSummaryQuery(businessObject));
        yield return File($"{module}/Queries/Get{businessObject.Name}ProfilingDrilldownQuery.cs", EmitGetProfilingDrilldownQuery(businessObject));
        yield return File($"{module}/Queries/Get{businessObject.Name}RuleSummaryQuery.cs", EmitGetRuleSummaryQuery(businessObject));
        yield return File($"{module}/Queries/Get{businessObject.Name}RuleDrilldownQuery.cs", EmitGetRuleDrilldownQuery(businessObject));
        yield return File($"{module}/Handlers/Run{businessObject.Name}AnalysisCommandHandler.cs", EmitRunAnalysisHandler(businessObject));
        yield return File($"{module}/Handlers/Execute{businessObject.Name}AnalysisRunCommandHandler.cs", EmitExecuteAnalysisRunHandler(businessObject));
        yield return File($"{module}/Handlers/Get{businessObject.Name}RunsQueryHandler.cs", EmitGetRunsHandler(businessObject));
        yield return File($"{module}/Handlers/Get{businessObject.Name}RunQueryHandler.cs", EmitGetRunHandler(businessObject));
        yield return File($"{module}/Handlers/Get{businessObject.Name}ProfilingSummaryQueryHandler.cs", EmitGetProfilingSummaryHandler(businessObject));
        yield return File($"{module}/Handlers/Get{businessObject.Name}ProfilingDrilldownQueryHandler.cs", EmitGetProfilingDrilldownHandler(businessObject));
        yield return File($"{module}/Handlers/Get{businessObject.Name}RuleSummaryQueryHandler.cs", EmitGetRuleSummaryHandler(businessObject));
        yield return File($"{module}/Handlers/Get{businessObject.Name}RuleDrilldownQueryHandler.cs", EmitGetRuleDrilldownHandler(businessObject));
        yield return File($"{module}/Interfaces/I{businessObject.Name}RunService.cs", EmitRunServiceInterface(businessObject));
        yield return File($"{module}/Services/{businessObject.Name}RunService.cs", EmitRunService(businessObject, root));
        foreach (var generatedFile in new BusinessObjectDataQualityArtifactGenerator(metadata, solutionName, _rootNamespace).Emit(businessObject))
        {
            yield return generatedFile;
        }
    }

    private string EmitDto(EntityDefinition entity) => EmitDtoClass(entity, $"{entity.Name}Dto", includeKey: true);
    private string EmitMutateDto(EntityDefinition entity, string prefix) => EmitDtoClass(entity, $"{prefix}{entity.Name}Dto", includeKey: false);

    private string EmitAnalysisDtos(BusinessObjectDefinition businessObject, EntityDefinition root) => $$"""
namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;

public sealed class Run{{businessObject.Name}}AnalysisRequestDto
{
    public string RunType { get; init; } = "Analysis";
    public string TriggeredBy { get; init; } = "system";
}

public sealed class Run{{businessObject.Name}}AnalysisResponseDto
{
    public Guid RunId { get; init; }
    public string Status { get; init; } = string.Empty;
}

public sealed class {{businessObject.Name}}RunDto
{
    public Guid RunId { get; init; }
    public string BusinessObjectName { get; init; } = string.Empty;
    public string RootEntityName { get; init; } = string.Empty;
    public string RunType { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public DateTimeOffset StartedOn { get; init; }
    public DateTimeOffset? CompletedOn { get; init; }
    public string TriggeredBy { get; init; } = string.Empty;
    public int TotalRootRecords { get; init; }
    public decimal? OverallScore { get; init; }
    public string? ErrorMessage { get; init; }
}

public sealed class {{businessObject.Name}}ProfilingSummaryDto
{
    public Guid SummaryId { get; init; }
    public Guid RunId { get; init; }
    public string EntityName { get; init; } = string.Empty;
    public string? FieldName { get; init; }
    public string MetricName { get; init; } = string.Empty;
    public string MetricType { get; init; } = string.Empty;
    public decimal? NumericValue { get; init; }
    public string? TextValue { get; init; }
    public decimal? Score { get; init; }
}

public sealed class {{businessObject.Name}}ProfilingDrilldownDto
{
    public Guid DrilldownId { get; init; }
    public Guid RunId { get; init; }
    public Guid SummaryId { get; init; }
    public string EntityName { get; init; } = string.Empty;
    public string? RootRecordId { get; init; }
    public string? RecordId { get; init; }
    public string SnapshotJson { get; init; } = string.Empty;
}

public sealed class {{businessObject.Name}}RuleSummaryDto
{
    public Guid RuleSummaryId { get; init; }
    public Guid RunId { get; init; }
    public string RuleCode { get; init; } = string.Empty;
    public string RuleName { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public string Severity { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public int AffectedCount { get; init; }
    public decimal Score { get; init; }
}

public sealed class {{businessObject.Name}}RuleDrilldownDto
{
    public Guid DrilldownId { get; init; }
    public Guid RunId { get; init; }
    public Guid RuleSummaryId { get; init; }
    public string EntityName { get; init; } = string.Empty;
    public string? RootRecordId { get; init; }
    public string? RecordId { get; init; }
    public string? FieldName { get; init; }
    public string Message { get; init; } = string.Empty;
    public string Severity { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public string SnapshotJson { get; init; } = string.Empty;
}
""";

    private string EmitRunAnalysisCommand(BusinessObjectDefinition businessObject) => $$"""
using MediatR;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Commands;

public sealed record Run{{businessObject.Name}}AnalysisCommand(string RunType, string TriggeredBy) : IRequest<Guid>;
""";

    private string EmitExecuteAnalysisRunCommand(BusinessObjectDefinition businessObject) => $$"""
using MediatR;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Commands;

public sealed record Execute{{businessObject.Name}}AnalysisRunCommand(Guid RunId) : IRequest;
""";

    private string EmitGetRunsQuery(BusinessObjectDefinition businessObject) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Queries;

public sealed record Get{{businessObject.Name}}RunsQuery : IRequest<IReadOnlyList<{{businessObject.Name}}RunDto>>;
""";

    private string EmitGetRunQuery(BusinessObjectDefinition businessObject) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Queries;

public sealed record Get{{businessObject.Name}}RunQuery(Guid RunId) : IRequest<{{businessObject.Name}}RunDto?>;
""";

    private string EmitGetProfilingSummaryQuery(BusinessObjectDefinition businessObject) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Queries;

public sealed record Get{{businessObject.Name}}ProfilingSummaryQuery(Guid RunId) : IRequest<IReadOnlyList<{{businessObject.Name}}ProfilingSummaryDto>>;
""";

    private string EmitGetProfilingDrilldownQuery(BusinessObjectDefinition businessObject) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Queries;

public sealed record Get{{businessObject.Name}}ProfilingDrilldownQuery(Guid RunId) : IRequest<IReadOnlyList<{{businessObject.Name}}ProfilingDrilldownDto>>;
""";

    private string EmitGetRuleSummaryQuery(BusinessObjectDefinition businessObject) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Queries;

public sealed record Get{{businessObject.Name}}RuleSummaryQuery(Guid RunId) : IRequest<IReadOnlyList<{{businessObject.Name}}RuleSummaryDto>>;
""";

    private string EmitGetRuleDrilldownQuery(BusinessObjectDefinition businessObject) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Queries;

public sealed record Get{{businessObject.Name}}RuleDrilldownQuery(Guid RunId) : IRequest<IReadOnlyList<{{businessObject.Name}}RuleDrilldownDto>>;
""";

    private string EmitRunAnalysisHandler(BusinessObjectDefinition businessObject) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Commands;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Interfaces;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Handlers;

public sealed class Run{{businessObject.Name}}AnalysisCommandHandler(I{{businessObject.Name}}RunService runService)
    : IRequestHandler<Run{{businessObject.Name}}AnalysisCommand, Guid>
{
    public async Task<Guid> Handle(Run{{businessObject.Name}}AnalysisCommand request, CancellationToken cancellationToken)
        => await runService.QueueAnalysisRunAsync(request.RunType, request.TriggeredBy, cancellationToken);
}
""";

    private string EmitExecuteAnalysisRunHandler(BusinessObjectDefinition businessObject) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Commands;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Interfaces;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Handlers;

public sealed class Execute{{businessObject.Name}}AnalysisRunCommandHandler(I{{businessObject.Name}}RunService runService)
    : IRequestHandler<Execute{{businessObject.Name}}AnalysisRunCommand>
{
    public async Task Handle(Execute{{businessObject.Name}}AnalysisRunCommand request, CancellationToken cancellationToken)
        => await runService.ExecuteAnalysisRunAsync(request.RunId, cancellationToken);
}
""";

    private string EmitGetRunsHandler(BusinessObjectDefinition businessObject) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Interfaces;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Queries;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Handlers;

public sealed class Get{{businessObject.Name}}RunsQueryHandler(I{{businessObject.Name}}RunService runService)
    : IRequestHandler<Get{{businessObject.Name}}RunsQuery, IReadOnlyList<{{businessObject.Name}}RunDto>>
{
    public async Task<IReadOnlyList<{{businessObject.Name}}RunDto>> Handle(Get{{businessObject.Name}}RunsQuery request, CancellationToken cancellationToken)
        => await runService.GetRunsAsync(cancellationToken);
}
""";

    private string EmitGetRunHandler(BusinessObjectDefinition businessObject) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Interfaces;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Queries;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Handlers;

public sealed class Get{{businessObject.Name}}RunQueryHandler(I{{businessObject.Name}}RunService runService)
    : IRequestHandler<Get{{businessObject.Name}}RunQuery, {{businessObject.Name}}RunDto?>
{
    public async Task<{{businessObject.Name}}RunDto?> Handle(Get{{businessObject.Name}}RunQuery request, CancellationToken cancellationToken)
        => await runService.GetRunAsync(request.RunId, cancellationToken);
}
""";

    private string EmitGetProfilingSummaryHandler(BusinessObjectDefinition businessObject) => EmitQueryHandler(businessObject, "ProfilingSummary", $"{businessObject.Name}ProfilingSummaryDto", "GetProfilingSummaryAsync");
    private string EmitGetProfilingDrilldownHandler(BusinessObjectDefinition businessObject) => EmitQueryHandler(businessObject, "ProfilingDrilldown", $"{businessObject.Name}ProfilingDrilldownDto", "GetProfilingDrilldownAsync");
    private string EmitGetRuleSummaryHandler(BusinessObjectDefinition businessObject) => EmitQueryHandler(businessObject, "RuleSummary", $"{businessObject.Name}RuleSummaryDto", "GetRuleSummaryAsync");
    private string EmitGetRuleDrilldownHandler(BusinessObjectDefinition businessObject) => EmitQueryHandler(businessObject, "RuleDrilldown", $"{businessObject.Name}RuleDrilldownDto", "GetRuleDrilldownAsync");

    private string EmitQueryHandler(BusinessObjectDefinition businessObject, string querySuffix, string dtoType, string serviceMethod) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Interfaces;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Queries;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Handlers;

public sealed class Get{{businessObject.Name}}{{querySuffix}}QueryHandler(I{{businessObject.Name}}RunService runService)
    : IRequestHandler<Get{{businessObject.Name}}{{querySuffix}}Query, IReadOnlyList<{{dtoType}}>>
{
    public async Task<IReadOnlyList<{{dtoType}}>> Handle(Get{{businessObject.Name}}{{querySuffix}}Query request, CancellationToken cancellationToken)
        => await runService.{{serviceMethod}}(request.RunId, cancellationToken);
}
""";

    private string EmitRunServiceInterface(BusinessObjectDefinition businessObject) => $$"""
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Interfaces;

public interface I{{businessObject.Name}}RunService
{
    Task<Guid> QueueAnalysisRunAsync(string runType, string triggeredBy, CancellationToken cancellationToken = default);
    Task ExecuteAnalysisRunAsync(Guid runId, CancellationToken cancellationToken = default);
    Task ExecuteProfilingAsync(Guid runId, CancellationToken cancellationToken = default);
    Task ExecuteDataQualityAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<{{businessObject.Name}}RunDto>> GetRunsAsync(CancellationToken cancellationToken = default);
    Task<{{businessObject.Name}}RunDto?> GetRunAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<{{businessObject.Name}}ProfilingSummaryDto>> GetProfilingSummaryAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<{{businessObject.Name}}ProfilingDrilldownDto>> GetProfilingDrilldownAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<{{businessObject.Name}}RuleSummaryDto>> GetRuleSummaryAsync(Guid runId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<{{businessObject.Name}}RuleDrilldownDto>> GetRuleDrilldownAsync(Guid runId, CancellationToken cancellationToken = default);
}
""";

    private string EmitRunService(BusinessObjectDefinition businessObject, EntityDefinition root)
    {
        var entities = BusinessObjectEntities(businessObject).ToList();
        var repositoryParameters = string.Join("," + Environment.NewLine, entities.Select(e => $"    IRepository<{_rootNamespace}.Core.Entities.{e.Name}> {Camel(e.Name)}Repository"));
        var repositoryFields = string.Join(Environment.NewLine, entities.Select(e => $"    private readonly IRepository<{_rootNamespace}.Core.Entities.{e.Name}> _{Camel(e.Name)}Repository = {Camel(e.Name)}Repository;"));

        return $$"""
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Interfaces;
using {{_rootNamespace}}.Core.DataQuality;
using {{_rootNamespace}}.Core.Interfaces;

namespace {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Services;

public sealed class {{businessObject.Name}}RunService(
    IRepository<BusinessObjectRun> runRepository,
    IRepository<DataProfilingSummary> profilingSummaryRepository,
    IRepository<DataProfilingDrilldown> profilingDrilldownRepository,
    IRepository<DataQualityRuleSummary> ruleSummaryRepository,
    IRepository<DataQualityDrilldown> ruleDrilldownRepository,
{{repositoryParameters}},
    {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DataQuality.Services.{{businessObject.Name}}Profiler profiler,
    {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DataQuality.Services.{{businessObject.Name}}DataQualityRuleExecutor ruleExecutor)
    : I{{businessObject.Name}}RunService
{
    private readonly IRepository<BusinessObjectRun> _runRepository = runRepository;
    private readonly IRepository<DataProfilingSummary> _profilingSummaryRepository = profilingSummaryRepository;
    private readonly IRepository<DataProfilingDrilldown> _profilingDrilldownRepository = profilingDrilldownRepository;
    private readonly IRepository<DataQualityRuleSummary> _ruleSummaryRepository = ruleSummaryRepository;
    private readonly IRepository<DataQualityDrilldown> _ruleDrilldownRepository = ruleDrilldownRepository;
{{repositoryFields}}
    private readonly {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DataQuality.Services.{{businessObject.Name}}Profiler _profiler = profiler;
    private readonly {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DataQuality.Services.{{businessObject.Name}}DataQualityRuleExecutor _ruleExecutor = ruleExecutor;

    public async Task<Guid> QueueAnalysisRunAsync(string runType, string triggeredBy, CancellationToken cancellationToken = default)
    {
        var run = new BusinessObjectRun
        {
            RunId = Guid.NewGuid(),
            BusinessObjectName = "{{businessObject.Name}}",
            RootEntityName = "{{root.Name}}",
            RunType = string.IsNullOrWhiteSpace(runType) ? "Analysis" : runType,
            Status = "Queued",
            StartedOn = DateTimeOffset.UtcNow,
            TriggeredBy = string.IsNullOrWhiteSpace(triggeredBy) ? "system" : triggeredBy
        };

        await _runRepository.AddAsync(run, cancellationToken);
        await _runRepository.SaveChangesAsync(cancellationToken);
        return run.RunId;
    }

    public async Task ExecuteAnalysisRunAsync(Guid runId, CancellationToken cancellationToken = default)
    {
        var run = await _runRepository.GetByIdAsync(runId, cancellationToken);
        if (run is null)
        {
            return;
        }

        try
        {
            run.Status = "Running";
            _runRepository.Update(run);
            await _runRepository.SaveChangesAsync(cancellationToken);

            await ExecuteProfilingAsync(runId, cancellationToken);
            await ExecuteDataQualityAsync(runId, cancellationToken);

            var rootRecords = await _{{Camel(root.Name)}}Repository.ListAsync(cancellationToken);
            var ruleSummaries = (await _ruleSummaryRepository.ListAsync(cancellationToken)).Where(x => x.RunId == runId && x.RuleCode.StartsWith("{{businessObject.Name}}.", StringComparison.Ordinal)).ToList();
            run.TotalRootRecords = rootRecords.Count;
            run.OverallScore = ruleSummaries.Count == 0 ? 100m : Math.Round(ruleSummaries.Average(x => x.Score), 2);
            run.Status = "Completed";
            run.CompletedOn = DateTimeOffset.UtcNow;
            _runRepository.Update(run);
            await _runRepository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            run.Status = "Failed";
            run.ErrorMessage = exception.Message;
            run.CompletedOn = DateTimeOffset.UtcNow;
            _runRepository.Update(run);
            await _runRepository.SaveChangesAsync(CancellationToken.None);
        }
    }

    public async Task ExecuteProfilingAsync(Guid runId, CancellationToken cancellationToken = default)
        => await _profiler.ExecuteAsync(runId, cancellationToken);

    public async Task ExecuteDataQualityAsync(Guid runId, CancellationToken cancellationToken = default)
        => await _ruleExecutor.ExecuteAsync(runId, cancellationToken);

{{EmitRunServiceQueries(businessObject)}}
}
""";
    }

    private string EmitRunServiceQueries(BusinessObjectDefinition businessObject) => $$"""
    public async Task<IReadOnlyList<{{businessObject.Name}}RunDto>> GetRunsAsync(CancellationToken cancellationToken = default)
        => (await _runRepository.ListAsync(cancellationToken))
            .Where(x => x.BusinessObjectName == "{{businessObject.Name}}")
            .Select(MapRun)
            .ToList();

    public async Task<{{businessObject.Name}}RunDto?> GetRunAsync(Guid runId, CancellationToken cancellationToken = default)
    {
        var run = await _runRepository.GetByIdAsync(runId, cancellationToken);
        return run is null || run.BusinessObjectName != "{{businessObject.Name}}" ? null : MapRun(run);
    }

    public async Task<IReadOnlyList<{{businessObject.Name}}ProfilingSummaryDto>> GetProfilingSummaryAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _profilingSummaryRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "{{businessObject.Name}}")
            .Select(x => new {{businessObject.Name}}ProfilingSummaryDto
            {
                SummaryId = x.SummaryId,
                RunId = x.RunId,
                EntityName = x.EntityName,
                FieldName = x.FieldName,
                MetricName = x.MetricName,
                MetricType = x.MetricType,
                NumericValue = x.NumericValue,
                TextValue = x.TextValue,
                Score = x.Score
            })
            .ToList();

    public async Task<IReadOnlyList<{{businessObject.Name}}ProfilingDrilldownDto>> GetProfilingDrilldownAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _profilingDrilldownRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "{{businessObject.Name}}")
            .Select(x => new {{businessObject.Name}}ProfilingDrilldownDto
            {
                DrilldownId = x.DrilldownId,
                RunId = x.RunId,
                SummaryId = x.SummaryId,
                EntityName = x.EntityName,
                RootRecordId = x.RootRecordId,
                RecordId = x.RecordId,
                SnapshotJson = x.SnapshotJson
            })
            .ToList();

    public async Task<IReadOnlyList<{{businessObject.Name}}RuleSummaryDto>> GetRuleSummaryAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _ruleSummaryRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.RuleCode.StartsWith("{{businessObject.Name}}.", StringComparison.Ordinal))
            .Select(x => new {{businessObject.Name}}RuleSummaryDto
            {
                RuleSummaryId = x.RuleSummaryId,
                RunId = x.RunId,
                RuleCode = x.RuleCode,
                RuleName = x.RuleName,
                Category = x.Category,
                Severity = x.Severity,
                Status = x.Status,
                AffectedCount = x.AffectedCount,
                Score = x.Score
            })
            .ToList();

    public async Task<IReadOnlyList<{{businessObject.Name}}RuleDrilldownDto>> GetRuleDrilldownAsync(Guid runId, CancellationToken cancellationToken = default)
        => (await _ruleDrilldownRepository.ListAsync(cancellationToken))
            .Where(x => x.RunId == runId && x.BusinessObjectName == "{{businessObject.Name}}")
            .Select(x => new {{businessObject.Name}}RuleDrilldownDto
            {
                DrilldownId = x.DrilldownId,
                RunId = x.RunId,
                RuleSummaryId = x.RuleSummaryId,
                EntityName = x.EntityName,
                RootRecordId = x.RootRecordId,
                RecordId = x.RecordId,
                FieldName = x.FieldName,
                Message = x.Message,
                Severity = x.Severity,
                Status = x.Status,
                SnapshotJson = x.SnapshotJson
            })
            .ToList();

    private static {{businessObject.Name}}RunDto MapRun(BusinessObjectRun run)
        => new()
        {
            RunId = run.RunId,
            BusinessObjectName = run.BusinessObjectName,
            RootEntityName = run.RootEntityName,
            RunType = run.RunType,
            Status = run.Status,
            StartedOn = run.StartedOn,
            CompletedOn = run.CompletedOn,
            TriggeredBy = run.TriggeredBy,
            TotalRootRecords = run.TotalRootRecords,
            OverallScore = run.OverallScore,
            ErrorMessage = run.ErrorMessage
        };
""";

    private string EmitEntityProfilingExecution(BusinessObjectDefinition businessObject, EntityDefinition root, EntityDefinition entity)
    {
        var key = KeyProperty(entity);
        var rootId = RootRecordIdExpression(businessObject, root, entity, "record");
        var fieldProfiles = string.Join(Environment.NewLine, entity.Properties.Where(p => !IsKey(entity, p)).Select(p => EmitPropertyProfiling(businessObject, entity, p, key, rootId)));

        return $$"""
var {{Camel(entity.Name)}}Records = await _{{Camel(entity.Name)}}Repository.ListAsync(cancellationToken);
await _profilingSummaryRepository.AddAsync(new DataProfilingSummary
{
    SummaryId = Guid.NewGuid(),
    RunId = runId,
    BusinessObjectName = "{{businessObject.Name}}",
    EntityName = "{{entity.Name}}",
    MetricName = "Total Count",
    MetricType = "TotalCount",
    NumericValue = {{Camel(entity.Name)}}Records.Count,
    Score = 100m
}, cancellationToken);
{{fieldProfiles}}
""";
    }

    private string EmitPropertyProfiling(BusinessObjectDefinition businessObject, EntityDefinition entity, PropertyDefinition property, PropertyDefinition key, string rootId)
    {
        if (IsString(property))
        {
            return $$"""
var {{Camel(entity.Name)}}{{property.Name}}NullRecords = {{Camel(entity.Name)}}Records.Where(record => string.IsNullOrWhiteSpace(record.{{property.Name}})).ToList();
var {{Camel(entity.Name)}}{{property.Name}}NullSummaryId = Guid.NewGuid();
await _profilingSummaryRepository.AddAsync(new DataProfilingSummary { SummaryId = {{Camel(entity.Name)}}{{property.Name}}NullSummaryId, RunId = runId, BusinessObjectName = "{{businessObject.Name}}", EntityName = "{{entity.Name}}", FieldName = "{{property.Name}}", MetricName = "Null Count", MetricType = "NullCount", NumericValue = {{Camel(entity.Name)}}{{property.Name}}NullRecords.Count, Score = {{Camel(entity.Name)}}Records.Count == 0 ? 100m : Math.Round((1m - ((decimal){{Camel(entity.Name)}}{{property.Name}}NullRecords.Count / {{Camel(entity.Name)}}Records.Count)) * 100m, 2) }, cancellationToken);
foreach (var record in {{Camel(entity.Name)}}{{property.Name}}NullRecords)
{
    await _profilingDrilldownRepository.AddAsync(new DataProfilingDrilldown { DrilldownId = Guid.NewGuid(), RunId = runId, SummaryId = {{Camel(entity.Name)}}{{property.Name}}NullSummaryId, BusinessObjectName = "{{businessObject.Name}}", EntityName = "{{entity.Name}}", RootRecordId = {{rootId}}, RecordId = record.{{key.Name}}.ToString(), SnapshotJson = JsonSerializer.Serialize(record) }, cancellationToken);
}
await _profilingSummaryRepository.AddAsync(new DataProfilingSummary { SummaryId = Guid.NewGuid(), RunId = runId, BusinessObjectName = "{{businessObject.Name}}", EntityName = "{{entity.Name}}", FieldName = "{{property.Name}}", MetricName = "Distinct Count", MetricType = "DistinctCount", NumericValue = {{Camel(entity.Name)}}Records.Select(record => record.{{property.Name}}).Distinct().Count(), Score = 100m }, cancellationToken);
""";
        }

        return $$"""
await _profilingSummaryRepository.AddAsync(new DataProfilingSummary { SummaryId = Guid.NewGuid(), RunId = runId, BusinessObjectName = "{{businessObject.Name}}", EntityName = "{{entity.Name}}", FieldName = "{{property.Name}}", MetricName = "Distinct Count", MetricType = "DistinctCount", NumericValue = {{Camel(entity.Name)}}Records.Select(record => record.{{property.Name}}).Distinct().Count(), Score = 100m }, cancellationToken);
""";
    }

    private IEnumerable<DataQualityRuleDefinition> EffectiveRules(BusinessObjectDefinition businessObject)
    {
        if (businessObject.DataQualityRules.Count > 0)
        {
            return businessObject.DataQualityRules;
        }

        return BusinessObjectEntities(businessObject)
            .SelectMany(entity => entity.Properties
                .Where(property => property.Required && !IsKey(entity, property) && IsString(property))
                .Select(property => new DataQualityRuleDefinition
                {
                    RuleCode = $"{entity.Name}.{property.Name}.Required",
                    RuleName = $"{entity.Name} {property.Name} is required",
                    Category = "Field",
                    Severity = "High",
                    Entity = entity.Name,
                    Field = property.Name,
                    Type = "Required"
                }));
    }

    private string EmitRuleExecution(BusinessObjectDefinition businessObject, EntityDefinition root, DataQualityRuleDefinition rule)
    {
        var entity = metadata.Entities.FirstOrDefault(e => Matches(e.Name, rule.Entity));
        if (entity is null || string.IsNullOrWhiteSpace(rule.Field))
        {
            return "";
        }

        var property = entity.Properties.FirstOrDefault(p => Matches(p.Name, rule.Field));
        if (property is null)
        {
            return "";
        }

        if (!IsString(property) && !ClrType(property, forEntity: true).EndsWith("?", StringComparison.Ordinal))
        {
            return "";
        }

        var key = KeyProperty(entity);
        var rootId = RootRecordIdExpression(businessObject, root, entity, "record");
        var repo = $"_{Camel(entity.Name)}Repository";
        var records = $"{Camel(entity.Name)}{property.Name}RuleRecords";
        var failed = $"{Camel(entity.Name)}{property.Name}FailedRecords";
        var condition = IsString(property)
            ? $"string.IsNullOrWhiteSpace(record.{property.Name})"
            : $"record.{property.Name} is null";
        var ruleCode = string.IsNullOrWhiteSpace(rule.RuleCode) ? $"{businessObject.Name}.{entity.Name}.{property.Name}.Required" : $"{businessObject.Name}.{rule.RuleCode}";
        var ruleName = string.IsNullOrWhiteSpace(rule.RuleName) ? $"{entity.Name} {property.Name} is required" : rule.RuleName;

        return $$"""
var {{records}} = await {{repo}}.ListAsync(cancellationToken);
var {{failed}} = {{records}}.Where(record => {{condition}}).ToList();
var {{Camel(entity.Name)}}{{property.Name}}RuleSummaryId = Guid.NewGuid();
await _ruleSummaryRepository.AddAsync(new DataQualityRuleSummary
{
    RuleSummaryId = {{Camel(entity.Name)}}{{property.Name}}RuleSummaryId,
    RunId = runId,
    RuleCode = "{{ruleCode}}",
    RuleName = "{{Escape(ruleName)}}",
    Category = "{{Escape(rule.Category)}}",
    Severity = "{{Escape(rule.Severity)}}",
    Status = {{failed}}.Count == 0 ? "Passed" : "Failed",
    AffectedCount = {{failed}}.Count,
    Score = {{records}}.Count == 0 ? 100m : Math.Round((1m - ((decimal){{failed}}.Count / {{records}}.Count)) * 100m, 2)
}, cancellationToken);
foreach (var record in {{failed}})
{
    await _ruleDrilldownRepository.AddAsync(new DataQualityDrilldown
    {
        DrilldownId = Guid.NewGuid(),
        RunId = runId,
        RuleSummaryId = {{Camel(entity.Name)}}{{property.Name}}RuleSummaryId,
        BusinessObjectName = "{{businessObject.Name}}",
        EntityName = "{{entity.Name}}",
        RootRecordId = {{rootId}},
        RecordId = record.{{key.Name}}.ToString(),
        FieldName = "{{property.Name}}",
        Message = "{{Escape(ruleName)}}",
        Severity = "{{Escape(rule.Severity)}}",
        Status = "Failed",
        SnapshotJson = JsonSerializer.Serialize(record)
    }, cancellationToken);
}
""";
    }

    private string EmitDtoClass(EntityDefinition entity, string className, bool includeKey)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"namespace {_rootNamespace}.Application.Modules.{entity.Name}.DTOs;");
        builder.AppendLine();
        builder.AppendLine($"public sealed class {className}");
        builder.AppendLine("{");
        foreach (var property in entity.Properties.Where(p => includeKey || !IsKey(entity, p)))
        {
            builder.AppendLine($"    public {ClrType(property, forEntity: false)} {property.Name} {{ get; init; }}{DefaultValue(property)}");
        }

        foreach (var child in AggregateChildren(entity))
        {
            var childDto = ChildDtoType(child, className);
            builder.AppendLine($"    public List<{childDto}> {Naming.Plural(child.Name)} {{ get; init; }} = [];");
        }

        builder.AppendLine("}");
        return builder.ToString();
    }

    private string EmitSearchDto(EntityDefinition entity) => $$"""
using {{_rootNamespace}}.Core.Common;

namespace {{_rootNamespace}}.Application.Modules.{{entity.Name}}.DTOs;

public sealed class Search{{entity.Name}}Dto : SearchRequest
{
}
""";

    private string EmitProfile(EntityDefinition entity) => $$"""
using AutoMapper;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.DTOs;
using Entity = {{_rootNamespace}}.Core.Entities.{{entity.Name}};

namespace {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Mappings;

public sealed class {{entity.Name}}Profile : Profile
{
    public {{entity.Name}}Profile()
    {
        CreateMap<Entity, {{entity.Name}}Dto>();
        CreateMap<Create{{entity.Name}}Dto, Entity>();
        CreateMap<Update{{entity.Name}}Dto, Entity>(){{UpdateProfileIgnores(entity)}};
    }
}
""";

    private string EmitCreateCommand(EntityDefinition entity) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.DTOs;

namespace {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Commands;

public sealed record Create{{entity.Name}}Command(Create{{entity.Name}}Dto Input) : IRequest<{{entity.Name}}Dto>;
""";

    private string EmitUpdateCommand(EntityDefinition entity) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.DTOs;

namespace {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Commands;

public sealed record Update{{entity.Name}}Command({{KeyType(entity)}} Id, Update{{entity.Name}}Dto Input) : IRequest<{{entity.Name}}Dto?>;
""";

    private string EmitDeleteCommand(EntityDefinition entity) => $$"""
using MediatR;

namespace {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Commands;

public sealed record Delete{{entity.Name}}Command({{KeyType(entity)}} Id) : IRequest<bool>;
""";

    private string EmitGetByIdQuery(EntityDefinition entity) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.DTOs;

namespace {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Queries;

public sealed record Get{{entity.Name}}ByIdQuery({{KeyType(entity)}} Id) : IRequest<{{entity.Name}}Dto?>;
""";

    private string EmitSearchQuery(EntityDefinition entity) => $$"""
using MediatR;
using {{_rootNamespace}}.Core.Common;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.DTOs;

namespace {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Queries;

public sealed record Search{{Naming.Plural(entity.Name)}}Query(Search{{entity.Name}}Dto Search) : IRequest<PagedResult<{{entity.Name}}Dto>>;
""";

    private string EmitCreateHandler(EntityDefinition entity) => $$"""
using AutoMapper;
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Commands;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.DTOs;
using {{_rootNamespace}}.Core.Interfaces;
using Entity = {{_rootNamespace}}.Core.Entities.{{entity.Name}};

namespace {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Handlers;

public sealed class Create{{entity.Name}}Handler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<Create{{entity.Name}}Command, {{entity.Name}}Dto>
{
    public async Task<{{entity.Name}}Dto> Handle(Create{{entity.Name}}Command request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<{{entity.Name}}Dto>(entity);
    }
}
""";

    private string EmitUpdateHandler(EntityDefinition entity) => $$"""
using AutoMapper;
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Commands;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.DTOs;
using {{_rootNamespace}}.Core.Interfaces;
using Entity = {{_rootNamespace}}.Core.Entities.{{entity.Name}};

namespace {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Handlers;

public sealed class Update{{entity.Name}}Handler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<Update{{entity.Name}}Command, {{entity.Name}}Dto?>
{
    public async Task<{{entity.Name}}Dto?> Handle(Update{{entity.Name}}Command request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, {{AggregateIncludesExpression(entity)}}, cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);
{{AggregateReplaceCollections(entity)}}
        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<{{entity.Name}}Dto>(entity);
    }
}
""";

    private string EmitDeleteHandler(EntityDefinition entity) => $$"""
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Commands;
using {{_rootNamespace}}.Core.Interfaces;
using Entity = {{_rootNamespace}}.Core.Entities.{{entity.Name}};

namespace {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Handlers;

public sealed class Delete{{entity.Name}}Handler(IRepository<Entity> repository)
    : IRequestHandler<Delete{{entity.Name}}Command, bool>
{
    public async Task<bool> Handle(Delete{{entity.Name}}Command request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null)
        {
            return false;
        }

        repository.Delete(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }
}
""";

    private string EmitGetByIdHandler(EntityDefinition entity) => $$"""
using AutoMapper;
using MediatR;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.DTOs;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Queries;
using {{_rootNamespace}}.Core.Interfaces;
using Entity = {{_rootNamespace}}.Core.Entities.{{entity.Name}};

namespace {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Handlers;

public sealed class Get{{entity.Name}}ByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<Get{{entity.Name}}ByIdQuery, {{entity.Name}}Dto?>
{
    public async Task<{{entity.Name}}Dto?> Handle(Get{{entity.Name}}ByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, {{AggregateIncludesExpression(entity)}}, cancellationToken);
        return entity is null ? null : mapper.Map<{{entity.Name}}Dto>(entity);
    }
}
""";

    private string EmitSearchHandler(EntityDefinition entity) => $$"""
using AutoMapper;
using MediatR;
using {{_rootNamespace}}.Core.Common;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.DTOs;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Queries;
using {{_rootNamespace}}.Core.Interfaces;
using Entity = {{_rootNamespace}}.Core.Entities.{{entity.Name}};

namespace {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Handlers;

public sealed class Search{{Naming.Plural(entity.Name)}}Handler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<Search{{Naming.Plural(entity.Name)}}Query, PagedResult<{{entity.Name}}Dto>>
{
    public async Task<PagedResult<{{entity.Name}}Dto>> Handle(Search{{Naming.Plural(entity.Name)}}Query request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<{{entity.Name}}Dto>
        {
            Items = mapper.Map<IReadOnlyList<{{entity.Name}}Dto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}
""";

    private string EmitValidator(EntityDefinition entity, string prefix)
    {
        var dtoType = $"{prefix}{entity.Name}Dto";
        var commandType = $"{prefix}{entity.Name}Command";
        var builder = new StringBuilder();
        builder.AppendLine("using FluentValidation;");
        builder.AppendLine($"using {_rootNamespace}.Application.Modules.{entity.Name}.Commands;");
        builder.AppendLine();
        builder.AppendLine($"namespace {_rootNamespace}.Application.Modules.{entity.Name}.Validators;");
        builder.AppendLine();
        builder.AppendLine($"public sealed class {commandType}Validator : AbstractValidator<{commandType}>");
        builder.AppendLine("{");
        builder.AppendLine($"    public {commandType}Validator()");
        builder.AppendLine("    {");

        foreach (var property in entity.Properties.Where(p => !IsKey(entity, p)))
        {
            var rules = RulesFor(property);
            if (rules.Count == 0)
            {
                continue;
            }

            builder.Append($"        RuleFor(x => x.Input.{property.Name})");
            foreach (var rule in rules)
            {
                builder.AppendLine();
                builder.Append($"            .{rule}");
            }
            builder.AppendLine(";");
            builder.AppendLine();
        }

        builder.AppendLine("    }");
        builder.AppendLine("}");
        return builder.ToString();
    }

    private string EmitDbContext()
    {
        var entitySets = metadata.Entities.Select(e => $"    public DbSet<{e.Name}> {Naming.Plural(e.Name)} => Set<{e.Name}>();");
        var analysisSets = new[]
        {
            "    public DbSet<BusinessObjectRun> BusinessObjectRuns => Set<BusinessObjectRun>();",
            "    public DbSet<DataProfilingSummary> DataProfilingSummaries => Set<DataProfilingSummary>();",
            "    public DbSet<DataProfilingDrilldown> DataProfilingDrilldowns => Set<DataProfilingDrilldown>();",
            "    public DbSet<DataQualityRuleResult> DataQualityRuleResults => Set<DataQualityRuleResult>();",
            "    public DbSet<DataQualityRuleSummary> DataQualityRuleSummaries => Set<DataQualityRuleSummary>();",
            "    public DbSet<DataQualityDrilldown> DataQualityDrilldowns => Set<DataQualityDrilldown>();"
        };
        var sets = string.Join(Environment.NewLine, entitySets.Concat(analysisSets));
        return $$"""
using Microsoft.EntityFrameworkCore;
using {{_rootNamespace}}.Application.Common;
using {{_rootNamespace}}.Core.DataQuality;
using {{_rootNamespace}}.Core.Entities;

namespace {{_rootNamespace}}.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAnalysisDbContext
{
{{sets}}

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditValues();
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    private void ApplyAuditValues()
    {
        var now = DateTimeOffset.UtcNow;
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedOn = now;
                entry.Entity.CreatedBy ??= "system";
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedOn = now;
                entry.Entity.ModifiedBy ??= "system";
            }
        }
    }
}
""";
    }

    private string EmitAnalysisConfiguration(string entityName, string keyName, string tableName) => $$"""
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using {{_rootNamespace}}.Core.DataQuality;

namespace {{_rootNamespace}}.Infrastructure.Persistence.Configurations;

public sealed class {{entityName}}Configuration : IEntityTypeConfiguration<{{entityName}}>
{
    public void Configure(EntityTypeBuilder<{{entityName}}> builder)
    {
        builder.ToTable("{{tableName}}");
        builder.HasKey(x => x.{{keyName}});
        builder.Property(x => x.{{keyName}}).ValueGeneratedNever();
    }
}
""";

    private string EmitEntityConfiguration(EntityDefinition entity)
    {
        var builder = new StringBuilder();
        builder.AppendLine("using Microsoft.EntityFrameworkCore;");
        builder.AppendLine("using Microsoft.EntityFrameworkCore.Metadata.Builders;");
        builder.AppendLine($"using {_rootNamespace}.Core.Entities;");
        builder.AppendLine();
        builder.AppendLine($"namespace {_rootNamespace}.Infrastructure.Persistence.Configurations;");
        builder.AppendLine();
        builder.AppendLine($"public sealed class {entity.Name}Configuration : IEntityTypeConfiguration<{entity.Name}>");
        builder.AppendLine("{");
        builder.AppendLine($"    public void Configure(EntityTypeBuilder<{entity.Name}> builder)");
        builder.AppendLine("    {");
        builder.AppendLine($"        builder.ToTable(\"{entity.TableName ?? Naming.Plural(entity.Name)}\");");
        builder.AppendLine($"        builder.HasKey(x => x.{KeyProperty(entity).Name});");

        foreach (var property in entity.Properties)
        {
            builder.AppendLine();
            builder.AppendLine($"        builder.Property(x => x.{property.Name})");
            builder.Append($"            .HasColumnName(\"{property.Name}\")");
            if (property.Identity)
            {
                builder.AppendLine();
                builder.Append("            .ValueGeneratedOnAdd()");
            }
            if (property.Required && IsString(property))
            {
                builder.AppendLine();
                builder.Append("            .IsRequired()");
            }
            if (property.MaxLength is not null && IsString(property))
            {
                builder.AppendLine();
                builder.Append($"            .HasMaxLength({property.MaxLength.Value})");
            }
            builder.AppendLine(";");

            if (property.Index || property.Unique)
            {
                builder.AppendLine($"        builder.HasIndex(x => x.{property.Name}){(property.Unique ? ".IsUnique()" : "")};");
            }
        }

        foreach (var relationship in metadata.Relationships.Where(r => Matches(r.From, entity.Name)))
        {
            var to = Naming.Pascal(relationship.To);
            var fk = relationship.ForeignKey ?? $"{to}Id";
            if (relationship.Type.Equals("ManyToMany", StringComparison.OrdinalIgnoreCase))
            {
                builder.AppendLine($"        builder.HasMany(x => x.{Naming.Plural(to)}).WithMany(x => x.{Naming.Plural(entity.Name)});");
            }
            else
            {
                var deleteBehavior = IsAggregateChildRelationship(relationship) ? "Cascade" : "Restrict";
                builder.AppendLine($"        builder.HasOne(x => x.{to}).WithMany(x => x.{Naming.Plural(entity.Name)}).HasForeignKey(x => x.{fk}).OnDelete(DeleteBehavior.{deleteBehavior});");
            }
        }

        builder.AppendLine("    }");
        builder.AppendLine("}");
        return builder.ToString();
    }

    private string EmitEfRepository() => $$"""
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using {{_rootNamespace}}.Core.Common;
using {{_rootNamespace}}.Core.Interfaces;
using {{_rootNamespace}}.Infrastructure.Persistence;

namespace {{_rootNamespace}}.Infrastructure.Repositories;

public sealed class EfRepository<TEntity>(AppDbContext dbContext) : IRepository<TEntity>
    where TEntity : class
{
    public async Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        => await dbContext.Set<TEntity>().FindAsync([id], cancellationToken);

    public async Task<TEntity?> GetByIdAsync(object id, IReadOnlyList<string> includes, CancellationToken cancellationToken = default)
    {
        if (includes.Count == 0)
        {
            return await GetByIdAsync(id, cancellationToken);
        }

        IQueryable<TEntity> query = dbContext.Set<TEntity>();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        var keyName = dbContext.Model.FindEntityType(typeof(TEntity))?.FindPrimaryKey()?.Properties.SingleOrDefault()?.Name ?? "Id";
        var keyProperty = typeof(TEntity).GetProperty(keyName)
            ?? throw new InvalidOperationException($"Key property '{keyName}' was not found on {typeof(TEntity).Name}.");
        var typedId = Convert.ChangeType(id, Nullable.GetUnderlyingType(keyProperty.PropertyType) ?? keyProperty.PropertyType);
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var member = Expression.Property(parameter, keyProperty);
        var body = Expression.Equal(member, Expression.Constant(typedId, keyProperty.PropertyType));
        var predicate = Expression.Lambda<Func<TEntity, bool>>(body, parameter);

        return await query.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> ListAsync(CancellationToken cancellationToken = default)
        => await dbContext.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);

    public async Task<PagedResult<TEntity>> SearchAsync(SearchRequest request, CancellationToken cancellationToken = default)
    {
        var pageNumber = Math.Max(1, request.PageNumber);
        var pageSize = Math.Clamp(request.PageSize, 1, 200);
        IQueryable<TEntity> query = dbContext.Set<TEntity>().AsNoTracking();

        foreach (var filter in request.Filters.Where(f => !string.IsNullOrWhiteSpace(f.Field)))
        {
            query = ApplyFilter(query, filter);
        }

        query = ApplySort(query, request.SortBy, request.SortDescending);
        var total = await query.CountAsync(cancellationToken);
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

        return new PagedResult<TEntity>
        {
            Items = items,
            TotalCount = total,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

    public void Update(TEntity entity) => dbContext.Set<TEntity>().Update(entity);

    public void Delete(TEntity entity) => dbContext.Set<TEntity>().Remove(entity);

    public void ReplaceCollection<TChild>(ICollection<TChild> existingItems, IEnumerable<TChild> replacementItems)
        where TChild : class
    {
        dbContext.RemoveRange(existingItems);
        existingItems.Clear();
        foreach (var item in replacementItems)
        {
            existingItems.Add(item);
        }
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        => await dbContext.SaveChangesAsync(cancellationToken);

    private static IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, SearchFilter filter)
    {
        var property = typeof(TEntity).GetProperty(filter.Field);
        if (property is null)
        {
            return source;
        }

        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var member = Expression.Property(parameter, property);
        var typedValue = Convert.ChangeType(filter.Value, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
        var constant = Expression.Constant(typedValue, property.PropertyType);
        Expression body = filter.Operator.ToLowerInvariant() switch
        {
            "contains" when property.PropertyType == typeof(string) => Expression.Call(member, nameof(string.Contains), Type.EmptyTypes, constant),
            "gt" => Expression.GreaterThan(member, constant),
            "gte" => Expression.GreaterThanOrEqual(member, constant),
            "lt" => Expression.LessThan(member, constant),
            "lte" => Expression.LessThanOrEqual(member, constant),
            _ => Expression.Equal(member, constant)
        };

        return source.Where(Expression.Lambda<Func<TEntity, bool>>(body, parameter));
    }

    private static IQueryable<TEntity> ApplySort(IQueryable<TEntity> source, string? sortBy, bool descending)
    {
        if (string.IsNullOrWhiteSpace(sortBy))
        {
            return source;
        }

        var property = typeof(TEntity).GetProperty(sortBy);
        if (property is null)
        {
            return source;
        }

        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var member = Expression.Property(parameter, property);
        var lambda = Expression.Lambda(member, parameter);
        var method = descending ? nameof(Queryable.OrderByDescending) : nameof(Queryable.OrderBy);
        var call = Expression.Call(typeof(Queryable), method, [typeof(TEntity), property.PropertyType], source.Expression, Expression.Quote(lambda));
        return source.Provider.CreateQuery<TEntity>(call);
    }
}
""";

    private string EmitInfrastructureDi() => $$"""
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using {{_rootNamespace}}.Application.Common;
using {{_rootNamespace}}.Core.Interfaces;
using {{_rootNamespace}}.Infrastructure.Persistence;
using {{_rootNamespace}}.Infrastructure.Repositories;

namespace {{_rootNamespace}}.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IAnalysisDbContext>(provider => provider.GetRequiredService<AppDbContext>());
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        return services;
    }
}
""";

    private string EmitInitialMigration() => $$"""
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace {{_rootNamespace}}.Infrastructure.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
    }
}
""";

    private string EmitApiProgram() => $$"""
using {{_rootNamespace}}.API.Middleware;
using {{_rootNamespace}}.Application;
using {{_rootNamespace}}.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
""";

    private string EmitApiSettings() => """
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=srv01;Port=5432;Database=postgres;Username=postgres;Password=REPLACE_WITH_POSTGRES_PASSWORD"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
""";

    private string EmitExceptionMiddleware() => $$"""
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace {{_rootNamespace}}.API.Middleware;

public sealed class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException exception)
        {
            await WriteProblemAsync(context, StatusCodes.Status400BadRequest, "Validation failed", exception.Errors.Select(e => e.ErrorMessage));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unhandled API exception");
            await WriteProblemAsync(context, StatusCodes.Status500InternalServerError, "Unexpected error", ["An unexpected error occurred."]);
        }
    }

    private static async Task WriteProblemAsync(HttpContext context, int status, string title, IEnumerable<string> errors)
    {
        context.Response.StatusCode = status;
        var problem = new ValidationProblemDetails(errors.GroupBy(_ => "Errors").ToDictionary(g => g.Key, g => g.ToArray()))
        {
            Status = status,
            Title = title
        };

        await context.Response.WriteAsJsonAsync(problem);
    }
}
""";

    private string EmitController(EntityDefinition entity)
    {
        var plural = Naming.Plural(entity.Name).ToLowerInvariant();
        return $$"""
using MediatR;
using Microsoft.AspNetCore.Mvc;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Commands;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.DTOs;
using {{_rootNamespace}}.Application.Modules.{{entity.Name}}.Queries;

namespace {{_rootNamespace}}.API.Controllers;

[ApiController]
[Route("api/{{plural}}")]
public sealed class {{Naming.Plural(entity.Name)}}Controller(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<{{entity.Name}}Dto>> GetById({{KeyType(entity)}} id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new Get{{entity.Name}}ByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new Search{{Naming.Plural(entity.Name)}}Query(new Search{{entity.Name}}Dto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(Search{{entity.Name}}Dto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new Search{{Naming.Plural(entity.Name)}}Query(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<{{entity.Name}}Dto>> Create(Create{{entity.Name}}Dto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new Create{{entity.Name}}Command(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.{{KeyProperty(entity).Name}} }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<{{entity.Name}}Dto>> Update({{KeyType(entity)}} id, Update{{entity.Name}}Dto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new Update{{entity.Name}}Command(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete({{KeyType(entity)}} id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new Delete{{entity.Name}}Command(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}
""";
    }

    private string EmitAnalysisController(BusinessObjectDefinition businessObject)
    {
        var route = Naming.Plural(businessObject.Name).ToLowerInvariant();
        return $$"""
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Commands;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.DTOs;
using {{_rootNamespace}}.Application.Modules.{{businessObject.Name}}.Queries;

namespace {{_rootNamespace}}.API.Controllers;

[ApiController]
[Route("api/{{route}}")]
public sealed class {{businessObject.Name}}AnalysisController(IMediator mediator, IServiceScopeFactory serviceScopeFactory) : ControllerBase
{
    [HttpPost("analysis/run")]
    public async Task<ActionResult<Run{{businessObject.Name}}AnalysisResponseDto>> RunAnalysis(Run{{businessObject.Name}}AnalysisRequestDto input, CancellationToken cancellationToken)
    {
        var runId = await mediator.Send(new Run{{businessObject.Name}}AnalysisCommand(input.RunType, input.TriggeredBy), cancellationToken);
        _ = Task.Run(async () =>
        {
            await using var scope = serviceScopeFactory.CreateAsyncScope();
            var scopedMediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            await scopedMediator.Send(new Execute{{businessObject.Name}}AnalysisRunCommand(runId), CancellationToken.None);
        }, CancellationToken.None);

        return Accepted(new Run{{businessObject.Name}}AnalysisResponseDto { RunId = runId, Status = "Queued" });
    }

    [HttpGet("runs")]
    public async Task<ActionResult<IReadOnlyList<{{businessObject.Name}}RunDto>>> GetRuns(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new Get{{businessObject.Name}}RunsQuery(), cancellationToken));

    [HttpGet("runs/{runId:guid}")]
    public async Task<ActionResult<{{businessObject.Name}}RunDto>> GetRun(Guid runId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new Get{{businessObject.Name}}RunQuery(runId), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet("runs/{runId:guid}/profiling-summary")]
    public async Task<ActionResult<IReadOnlyList<{{businessObject.Name}}ProfilingSummaryDto>>> GetProfilingSummary(Guid runId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new Get{{businessObject.Name}}ProfilingSummaryQuery(runId), cancellationToken));

    [HttpGet("runs/{runId:guid}/profiling-drilldown")]
    public async Task<ActionResult<IReadOnlyList<{{businessObject.Name}}ProfilingDrilldownDto>>> GetProfilingDrilldown(Guid runId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new Get{{businessObject.Name}}ProfilingDrilldownQuery(runId), cancellationToken));

    [HttpGet("runs/{runId:guid}/rule-summary")]
    public async Task<ActionResult<IReadOnlyList<{{businessObject.Name}}RuleSummaryDto>>> GetRuleSummary(Guid runId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new Get{{businessObject.Name}}RuleSummaryQuery(runId), cancellationToken));

    [HttpGet("runs/{runId:guid}/rule-drilldown")]
    public async Task<ActionResult<IReadOnlyList<{{businessObject.Name}}RuleDrilldownDto>>> GetRuleDrilldown(Guid runId, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new Get{{businessObject.Name}}RuleDrilldownQuery(runId), cancellationToken));
}
""";
    }

    private static void AppendNavigation(StringBuilder builder, EntityDefinition entity, RelationshipDefinition relationship)
    {
        var from = Naming.Pascal(relationship.From);
        var to = Naming.Pascal(relationship.To);
        if (relationship.Type.Equals("ManyToMany", StringComparison.OrdinalIgnoreCase))
        {
            var other = Matches(from, entity.Name) ? to : from;
            builder.AppendLine($"    public ICollection<{other}> {Naming.Plural(other)} {{ get; set; }} = [];");
            return;
        }

        if (Matches(from, entity.Name))
        {
            var fk = relationship.ForeignKey ?? $"{to}Id";
            if (!builder.ToString().Contains($" {fk} ", StringComparison.Ordinal))
            {
                builder.AppendLine($"    public int {fk} {{ get; set; }}");
            }
            builder.AppendLine($"    public {to}? {to} {{ get; set; }}");
        }
        else
        {
            builder.AppendLine($"    public ICollection<{from}> {Naming.Plural(from)} {{ get; set; }} = [];");
        }
    }

    private static List<string> RulesFor(PropertyDefinition property)
    {
        var rules = new List<string>();
        if (property.Required)
        {
            rules.Add("NotEmpty()");
        }
        if (property.MinLength is not null)
        {
            rules.Add($"MinimumLength({property.MinLength.Value})");
        }
        if (property.MaxLength is not null)
        {
            rules.Add($"MaximumLength({property.MaxLength.Value})");
        }
        if (!string.IsNullOrWhiteSpace(property.Regex))
        {
            rules.Add($"Matches(@\"{property.Regex.Replace("\"", "\"\"", StringComparison.Ordinal)}\")");
        }
        if (property.Email)
        {
            rules.Add("EmailAddress()");
        }
        if (property.MinValue is not null)
        {
            rules.Add($"GreaterThanOrEqualTo({NumericLiteral(property, property.MinValue.Value)})");
        }
        if (property.MaxValue is not null)
        {
            rules.Add($"LessThanOrEqualTo({NumericLiteral(property, property.MaxValue.Value)})");
        }
        if (property.AllowedValues.Count > 0)
        {
            var values = string.Join(", ", property.AllowedValues.Select(v => $"\"{v}\""));
            rules.Add($"Must(value => new[] {{ {values} }}.Contains(value)).WithMessage(\"{property.Name} contains an unsupported value\")");
        }

        return rules;
    }

    private static PropertyDefinition KeyProperty(EntityDefinition entity)
        => entity.Properties.FirstOrDefault(p => IsKey(entity, p))
            ?? entity.Properties.FirstOrDefault(p => p.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
            ?? new PropertyDefinition { Name = "Id", Type = "int", IsKey = true };

    private BusinessObjectDefinition? BusinessObjectForRoot(EntityDefinition entity)
        => metadata.BusinessObjects.FirstOrDefault(b => Matches(b.RootEntity ?? b.Entity ?? b.Name, entity.Name));

    private IReadOnlyList<EntityDefinition> AggregateChildren(EntityDefinition entity)
    {
        var businessObject = BusinessObjectForRoot(entity);
        if (businessObject is null || businessObject.Entities.Count == 0)
        {
            return [];
        }

        var childNames = businessObject.Entities
            .Select(Naming.Pascal)
            .Where(name => !Matches(name, entity.Name))
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return metadata.Entities
            .Where(candidate => childNames.Contains(candidate.Name))
            .ToList();
    }

    private EntityDefinition? RootEntity(BusinessObjectDefinition businessObject)
    {
        var rootName = Naming.Pascal(businessObject.RootEntity ?? businessObject.Entity ?? businessObject.Name);
        return metadata.Entities.FirstOrDefault(e => Matches(e.Name, rootName));
    }

    private IEnumerable<EntityDefinition> BusinessObjectEntities(BusinessObjectDefinition businessObject)
    {
        var names = businessObject.Entities.Count == 0
            ? [Naming.Pascal(businessObject.RootEntity ?? businessObject.Entity ?? businessObject.Name)]
            : businessObject.Entities.Select(Naming.Pascal).ToList();

        return metadata.Entities.Where(e => names.Any(name => Matches(name, e.Name)));
    }

    private string RootRecordIdExpression(BusinessObjectDefinition businessObject, EntityDefinition root, EntityDefinition entity, string variableName)
    {
        if (Matches(entity.Name, root.Name))
        {
            return $"{variableName}.{KeyProperty(root).Name}.ToString()";
        }

        var relationship = metadata.Relationships.FirstOrDefault(r => Matches(r.From, entity.Name) && Matches(r.To, root.Name));
        return relationship is null
            ? "null"
            : $"{variableName}.{relationship.ForeignKey ?? $"{root.Name}Id"}.ToString()";
    }

    private string ChildDtoType(EntityDefinition child, string parentDtoClassName)
    {
        var dtoName = parentDtoClassName.StartsWith("Create", StringComparison.Ordinal)
            ? $"Create{child.Name}Dto"
            : parentDtoClassName.StartsWith("Update", StringComparison.Ordinal)
                ? $"Update{child.Name}Dto"
                : $"{child.Name}Dto";

        return $"{_rootNamespace}.Application.Modules.{child.Name}.DTOs.{dtoName}";
    }

    private string UpdateProfileIgnores(EntityDefinition entity)
    {
        var children = AggregateChildren(entity);
        if (children.Count == 0)
        {
            return "";
        }

        return string.Concat(children.Select(child => $"{Environment.NewLine}            .ForMember(x => x.{Naming.Plural(child.Name)}, options => options.Ignore())"));
    }

    private string AggregateIncludesExpression(EntityDefinition entity)
    {
        var children = AggregateChildren(entity);
        if (children.Count == 0)
        {
            return "Array.Empty<string>()";
        }

        var includes = string.Join(", ", children.Select(child => $"\"{Naming.Plural(child.Name)}\""));
        return $"new[] {{ {includes} }}";
    }

    private string AggregateReplaceCollections(EntityDefinition entity)
    {
        var builder = new StringBuilder();
        foreach (var child in AggregateChildren(entity))
        {
            var collection = Naming.Plural(child.Name);
            builder.AppendLine($"        repository.ReplaceCollection(entity.{collection}, mapper.Map<List<{_rootNamespace}.Core.Entities.{child.Name}>>(request.Input.{collection}));");
        }

        return builder.ToString().TrimEnd();
    }

    private bool IsAggregateChildRelationship(RelationshipDefinition relationship)
    {
        var parent = Naming.Pascal(relationship.To);
        var child = Naming.Pascal(relationship.From);
        var businessObject = metadata.BusinessObjects.FirstOrDefault(b => Matches(b.RootEntity ?? b.Entity ?? b.Name, parent));

        return businessObject is not null
            && businessObject.Entities.Select(Naming.Pascal).Any(name => Matches(name, child));
    }

    private static bool IsKey(EntityDefinition entity, PropertyDefinition property)
        => property.IsKey || property.Name.Equals(entity.PrimaryKey ?? "Id", StringComparison.OrdinalIgnoreCase);

    private static string KeyType(EntityDefinition entity) => ClrType(KeyProperty(entity), forEntity: false).Replace("?", "", StringComparison.Ordinal);

    private static string ClrType(PropertyDefinition property, bool forEntity)
    {
        var type = property.Type.Trim().ToLowerInvariant() switch
        {
            "int" or "integer" => "int",
            "long" => "long",
            "decimal" or "money" or "number" => "decimal",
            "double" => "double",
            "float" => "float",
            "bool" or "boolean" => "bool",
            "datetime" or "date" => "DateTime",
            "datetimeoffset" => "DateTimeOffset",
            "guid" or "uuid" => "Guid",
            _ => "string"
        };

        if (type == "string")
        {
            return property.Required ? "string" : "string?";
        }

        return property.Required || property.IsKey ? type : $"{type}?";
    }

    private static bool IsString(PropertyDefinition property) => ClrType(property, forEntity: true).StartsWith("string", StringComparison.Ordinal);

    private static string DefaultValue(PropertyDefinition property)
        => ClrType(property, forEntity: false) == "string" ? " = string.Empty;" : "";

    private static string NumericLiteral(PropertyDefinition property, decimal value)
    {
        var text = value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        return property.Type.Trim().ToLowerInvariant() switch
        {
            "decimal" or "money" or "number" => $"{text}m",
            "float" => $"{text}f",
            "double" => $"{text}d",
            _ => text
        };
    }

    private static string Camel(string value) => Naming.Camel(value);

    private static string Escape(string value) => value.Replace("\\", "\\\\", StringComparison.Ordinal).Replace("\"", "\\\"", StringComparison.Ordinal);

    private static string Indent(string value, int spaces)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "";
        }

        var prefix = new string(' ', spaces);
        return string.Join(Environment.NewLine, value.Split(Environment.NewLine).Select(line => string.IsNullOrWhiteSpace(line) ? line : prefix + line));
    }

    private static bool Matches(string left, string right) => Naming.Pascal(left).Equals(Naming.Pascal(right), StringComparison.OrdinalIgnoreCase);
}
