using System.Text;

namespace SolutionGeneratorService.Generation;

internal sealed record GeneratedFile(string RelativePath, string Content);

internal sealed class CompactSolutionEmitter(MetadataDocument metadata, string solutionName)
{
    private readonly string _rootNamespace = Naming.NamespacePart(metadata.Application.Namespace ?? solutionName);

    public IEnumerable<GeneratedFile> Emit()
    {
        yield return File($"{solutionName}.sln", EmitSolutionFile());
        yield return File($"{solutionName}/{solutionName}.csproj", EmitProject());
        yield return File($"{solutionName}/Program.cs", EmitProgram());
        yield return File($"{solutionName}/appsettings.json", EmitAppSettings());
        yield return File($"{solutionName}/Entities/BaseEntity.cs", EmitBaseEntity());
        yield return File($"{solutionName}/Persistence/AppDbContext.cs", EmitDbContext());
        yield return File($"{solutionName}/Services/SearchRequest.cs", EmitSearchRequest());
        yield return File($"{solutionName}/Services/PagedResult.cs", EmitPagedResult());
        yield return File($"{solutionName}/Services/GenericCrudService.cs", EmitGenericCrudService());
        yield return File($"{solutionName}/Analysis/AnalysisModels.cs", EmitAnalysisModels());
        yield return File($"{solutionName}/Analysis/AnalysisDtos.cs", EmitAnalysisDtos());
        yield return File($"{solutionName}/Analysis/AnalysisService.cs", EmitAnalysisService());
        yield return File($"{solutionName}/Controllers/AnalysisController.cs", EmitAnalysisController());

        foreach (var entity in metadata.Entities)
        {
            yield return File($"{solutionName}/Entities/{entity.Name}.cs", EmitEntity(entity));
            yield return File($"{solutionName}/DTOs/{entity.Name}Dtos.cs", EmitDtos(entity));
            yield return File($"{solutionName}/Controllers/{Naming.Plural(entity.Name)}Controller.cs", EmitController(entity));
        }
    }

    private static GeneratedFile File(string relativePath, string content) => new(relativePath.Replace('\\', '/'), content);

    private string EmitSolutionFile()
    {
        var projectGuid = Guid.NewGuid().ToString("B").ToUpperInvariant();
        const string csharpProjectType = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";

        return $$"""
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.0.31903.59
MinimumVisualStudioVersion = 10.0.40219.1
Project("{{csharpProjectType}}") = "{{solutionName}}", "{{solutionName}}\{{solutionName}}.csproj", "{{projectGuid}}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{{projectGuid}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{projectGuid}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{projectGuid}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{projectGuid}}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
EndGlobal
""";
    }

    private string EmitProject() => $$"""
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.1">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="9.0.4" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="9.0.1" />
  </ItemGroup>
</Project>
""";

    private string EmitProgram() => $$"""
using Microsoft.EntityFrameworkCore;
using {{_rootNamespace}}.Analysis;
using {{_rootNamespace}}.Persistence;
using {{_rootNamespace}}.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(GenericCrudService<,,,,>));
builder.Services.AddScoped<AnalysisService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
""";

    private static string EmitAppSettings() => """
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=enterprise_mdm;Username=postgres;Password=YourPassword"
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

    private string EmitBaseEntity() => $$"""
namespace {{_rootNamespace}}.Entities;

public abstract class BaseEntity
{
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreatedOn { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedOn { get; set; }
}
""";

    private string EmitEntity(EntityDefinition entity)
    {
        var builder = new StringBuilder();
        builder.AppendLine("using System.ComponentModel.DataAnnotations;");
        builder.AppendLine();
        builder.AppendLine($"namespace {_rootNamespace}.Entities;");
        builder.AppendLine();
        builder.AppendLine($"public sealed class {entity.Name} : BaseEntity");
        builder.AppendLine("{");

        foreach (var property in entity.Properties)
        {
            if (IsKey(entity, property))
            {
                builder.AppendLine("    [Key]");
            }

            if (property.Required && IsString(property))
            {
                builder.AppendLine("    [Required]");
            }

            if (property.MaxLength is not null && IsString(property))
            {
                builder.AppendLine($"    [MaxLength({property.MaxLength.Value})]");
            }

            builder.AppendLine($"    public {ClrType(property, forEntity: true)} {property.Name} {{ get; set; }}{DefaultValue(property)}");
        }

        foreach (var relationship in metadata.Relationships.Where(r => Matches(r.From, entity.Name)))
        {
            var parent = Naming.Pascal(relationship.To);
            if (metadata.Entities.Any(e => Matches(e.Name, parent)))
            {
                builder.AppendLine($"    public {parent}? {parent} {{ get; set; }}");
            }
        }

        foreach (var relationship in metadata.Relationships.Where(r => Matches(r.To, entity.Name)))
        {
            var child = Naming.Pascal(relationship.From);
            if (metadata.Entities.Any(e => Matches(e.Name, child)))
            {
                builder.AppendLine($"    public ICollection<{child}> {Naming.Plural(child)} {{ get; set; }} = [];");
            }
        }

        builder.AppendLine("}");
        return builder.ToString();
    }

    private string EmitDtos(EntityDefinition entity)
    {
        var key = KeyProperty(entity);
        var dtoProperties = string.Join(Environment.NewLine, entity.Properties.Select(p => $"    public {ClrType(p, forEntity: false)} {p.Name} {{ get; set; }}{DefaultValue(p)}"));
        var createProperties = string.Join(Environment.NewLine, entity.Properties.Where(p => !IsKey(entity, p) || !p.Identity).Select(p => $"    public {ClrType(p, forEntity: false)} {p.Name} {{ get; set; }}{DefaultValue(p)}"));
        var updateProperties = string.Join(Environment.NewLine, entity.Properties.Where(p => !IsKey(entity, p)).Select(p => $"    public {ClrType(p, forEntity: false)} {p.Name} {{ get; set; }}{DefaultValue(p)}"));

        return $$"""
namespace {{_rootNamespace}}.DTOs;

public sealed class {{entity.Name}}Dto
{
{{dtoProperties}}
}

public sealed class Create{{entity.Name}}Dto
{
{{createProperties}}
}

public sealed class Update{{entity.Name}}Dto
{
{{updateProperties}}
}

public sealed class Search{{entity.Name}}Dto : {{_rootNamespace}}.Services.SearchRequest
{
}
""";
    }

    private string EmitDbContext()
    {
        var dbSets = string.Join(Environment.NewLine, metadata.Entities.Select(e => $"    public DbSet<{e.Name}> {Naming.Plural(e.Name)} => Set<{e.Name}>();"));
        var entityConfigurations = string.Join(Environment.NewLine + Environment.NewLine, metadata.Entities.Select(EmitEntityModelConfiguration));
        var relationshipConfigurations = string.Join(Environment.NewLine, metadata.Relationships.Select(EmitRelationshipConfiguration).Where(line => !string.IsNullOrWhiteSpace(line)));

        return $$"""
using Microsoft.EntityFrameworkCore;
using {{_rootNamespace}}.Analysis;
using {{_rootNamespace}}.Entities;

namespace {{_rootNamespace}}.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
{{dbSets}}
    public DbSet<BusinessObjectRun> BusinessObjectRuns => Set<BusinessObjectRun>();
    public DbSet<DataProfilingSummary> DataProfilingSummaries => Set<DataProfilingSummary>();
    public DbSet<DataProfilingDrilldown> DataProfilingDrilldowns => Set<DataProfilingDrilldown>();
    public DbSet<DataQualityRuleResult> DataQualityRuleResults => Set<DataQualityRuleResult>();
    public DbSet<DataQualityDrilldown> DataQualityDrilldowns => Set<DataQualityDrilldown>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditValues();
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
{{entityConfigurations}}

{{relationshipConfigurations}}

        modelBuilder.Entity<BusinessObjectRun>().HasKey(x => x.RunId);
        modelBuilder.Entity<DataProfilingSummary>().HasKey(x => x.SummaryId);
        modelBuilder.Entity<DataProfilingDrilldown>().HasKey(x => x.DrilldownId);
        modelBuilder.Entity<DataQualityRuleResult>().HasKey(x => x.ResultId);
        modelBuilder.Entity<DataQualityDrilldown>().HasKey(x => x.DrilldownId);
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
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedOn = now;
                entry.Entity.ModifiedBy ??= "system";
            }
        }
    }
}
""";
    }

    private string EmitEntityModelConfiguration(EntityDefinition entity)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"        modelBuilder.Entity<{entity.Name}>(entity =>");
        builder.AppendLine("        {");
        builder.AppendLine($"            entity.ToTable(\"{entity.TableName ?? Naming.Plural(entity.Name)}\");");
        builder.AppendLine($"            entity.HasKey(x => x.{KeyProperty(entity).Name});");

        foreach (var property in entity.Properties)
        {
            var chain = new StringBuilder($"            entity.Property(x => x.{property.Name})");
            if (property.Required)
            {
                chain.Append(".IsRequired()");
            }
            if (property.MaxLength is not null && IsString(property))
            {
                chain.Append($".HasMaxLength({property.MaxLength.Value})");
            }
            if (IsDecimal(property))
            {
                chain.Append(".HasPrecision(18, 4)");
            }
            builder.AppendLine(chain.Append(';').ToString());

            if (property.Unique)
            {
                builder.AppendLine($"            entity.HasIndex(x => x.{property.Name}).IsUnique();");
            }
            else if (property.Index)
            {
                builder.AppendLine($"            entity.HasIndex(x => x.{property.Name});");
            }
        }

        builder.AppendLine("        });");
        return builder.ToString().TrimEnd();
    }

    private string EmitRelationshipConfiguration(RelationshipDefinition relationship)
    {
        var child = metadata.Entities.FirstOrDefault(e => Matches(e.Name, relationship.From));
        var parent = metadata.Entities.FirstOrDefault(e => Matches(e.Name, relationship.To));
        if (child is null || parent is null || string.IsNullOrWhiteSpace(relationship.ForeignKey))
        {
            return "";
        }

        var parentName = parent.Name;
        var collection = Naming.Plural(child.Name);
        return $"        modelBuilder.Entity<{child.Name}>().HasOne(x => x.{parentName}).WithMany(x => x.{collection}).HasForeignKey(x => x.{relationship.ForeignKey}).OnDelete(DeleteBehavior.Cascade);";
    }

    private string EmitSearchRequest() => $$"""
namespace {{_rootNamespace}}.Services;

public class SearchRequest
{
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}
""";

    private string EmitPagedResult() => $$"""
namespace {{_rootNamespace}}.Services;

public sealed class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}
""";

    private string EmitGenericCrudService() => $$"""
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using {{_rootNamespace}}.Persistence;

namespace {{_rootNamespace}}.Services;

public sealed class GenericCrudService<TEntity, TDto, TCreateDto, TUpdateDto, TKey>(AppDbContext dbContext)
    where TEntity : class, new()
    where TDto : class, new()
{
    public async Task<TDto?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<TEntity>().FindAsync(new object?[] { id }, cancellationToken);
        return entity is null ? null : Map<TDto>(entity);
    }

    public async Task<PagedResult<TDto>> SearchAsync(SearchRequest request, CancellationToken cancellationToken)
    {
        var records = await dbContext.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
        IEnumerable<TEntity> query = records;

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            query = query.Where(record => typeof(TEntity).GetProperties()
                .Where(property => property.PropertyType == typeof(string))
                .Select(property => property.GetValue(record) as string)
                .Any(value => value?.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) == true));
        }

        if (!string.IsNullOrWhiteSpace(request.SortBy))
        {
            var sortProperty = typeof(TEntity).GetProperty(request.SortBy, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (sortProperty is not null)
            {
                query = request.SortDescending
                    ? query.OrderByDescending(record => sortProperty.GetValue(record))
                    : query.OrderBy(record => sortProperty.GetValue(record));
            }
        }

        var totalCount = query.Count();
        var page = Math.Max(1, request.Page);
        var pageSize = Math.Clamp(request.PageSize, 1, 500);
        var items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(Map<TDto>).ToList();

        return new PagedResult<TDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    public async Task<TDto> CreateAsync(TCreateDto input, CancellationToken cancellationToken)
    {
        var entity = Map<TEntity>(input!);
        dbContext.Set<TEntity>().Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Map<TDto>(entity);
    }

    public async Task<TDto?> UpdateAsync(TKey id, TUpdateDto input, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<TEntity>().FindAsync(new object?[] { id }, cancellationToken);
        if (entity is null)
        {
            return null;
        }

        CopyValues(input!, entity, skipKey: true);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Map<TDto>(entity);
    }

    public async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<TEntity>().FindAsync(new object?[] { id }, cancellationToken);
        if (entity is null)
        {
            return false;
        }

        dbContext.Set<TEntity>().Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    private static TTarget Map<TTarget>(object source) where TTarget : class, new()
    {
        var target = new TTarget();
        CopyValues(source, target, skipKey: false);
        return target;
    }

    private static void CopyValues(object source, object target, bool skipKey)
    {
        var targetProperties = target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(property => property.CanWrite)
            .ToDictionary(property => property.Name, StringComparer.OrdinalIgnoreCase);

        foreach (var sourceProperty in source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(property => property.CanRead))
        {
            if (skipKey && sourceProperty.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (!targetProperties.TryGetValue(sourceProperty.Name, out var targetProperty))
            {
                continue;
            }

            if (!targetProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
            {
                continue;
            }

            targetProperty.SetValue(target, sourceProperty.GetValue(source));
        }
    }
}
""";

    private string EmitController(EntityDefinition entity)
    {
        var keyType = KeyType(entity);
        return $$"""
using Microsoft.AspNetCore.Mvc;
using {{_rootNamespace}}.DTOs;
using {{_rootNamespace}}.Entities;
using {{_rootNamespace}}.Services;

namespace {{_rootNamespace}}.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class {{Naming.Plural(entity.Name)}}Controller(GenericCrudService<{{entity.Name}}, {{entity.Name}}Dto, Create{{entity.Name}}Dto, Update{{entity.Name}}Dto, {{keyType}}> service) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<{{entity.Name}}Dto>> GetById({{keyType}} id, CancellationToken cancellationToken)
    {
        var record = await service.GetByIdAsync(id, cancellationToken);
        return record is null ? NotFound() : Ok(record);
    }

    [HttpPost("search")]
    public async Task<ActionResult<PagedResult<{{entity.Name}}Dto>>> Search(Search{{entity.Name}}Dto search, CancellationToken cancellationToken)
        => Ok(await service.SearchAsync(search, cancellationToken));

    [HttpPost]
    public async Task<ActionResult<{{entity.Name}}Dto>> Create(Create{{entity.Name}}Dto input, CancellationToken cancellationToken)
        => Ok(await service.CreateAsync(input, cancellationToken));

    [HttpPut("{id}")]
    public async Task<ActionResult<{{entity.Name}}Dto>> Update({{keyType}} id, Update{{entity.Name}}Dto input, CancellationToken cancellationToken)
    {
        var record = await service.UpdateAsync(id, input, cancellationToken);
        return record is null ? NotFound() : Ok(record);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete({{keyType}} id, CancellationToken cancellationToken)
        => await service.DeleteAsync(id, cancellationToken) ? NoContent() : NotFound();
}
""";
    }

    private string EmitAnalysisModels() => $$"""
namespace {{_rootNamespace}}.Analysis;

public sealed class BusinessObjectRun
{
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string Status { get; set; } = "Queued";
    public DateTimeOffset StartedOn { get; set; }
    public DateTimeOffset? CompletedOn { get; set; }
}

public sealed class DataProfilingSummary
{
    public Guid SummaryId { get; set; }
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? FieldName { get; set; }
    public string MetricName { get; set; } = string.Empty;
    public string MetricType { get; set; } = string.Empty;
    public decimal NumericValue { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}

public sealed class DataProfilingDrilldown
{
    public Guid DrilldownId { get; set; }
    public Guid RunId { get; set; }
    public Guid SummaryId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? FieldName { get; set; }
    public string RecordId { get; set; } = string.Empty;
    public string? Message { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}

public sealed class DataQualityRuleResult
{
    public Guid ResultId { get; set; }
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string RuleCode { get; set; } = string.Empty;
    public string RuleName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int AffectedCount { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}

public sealed class DataQualityDrilldown
{
    public Guid DrilldownId { get; set; }
    public Guid RunId { get; set; }
    public Guid ResultId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string RuleCode { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string RecordId { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTimeOffset CreatedOn { get; set; }
}
""";

    private string EmitAnalysisDtos() => $$"""
namespace {{_rootNamespace}}.Analysis;

public sealed class BusinessObjectRunDto
{
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset StartedOn { get; set; }
    public DateTimeOffset? CompletedOn { get; set; }
}
""";

    private string EmitAnalysisService()
    {
        var supportedBusinessObjects = metadata.BusinessObjects.Count == 0
            ? "[]"
            : "[" + string.Join(", ", metadata.BusinessObjects.Select(b => $"\"{Escape(b.Name)}\"")) + "]";
        var profilingCases = string.Join(Environment.NewLine, metadata.BusinessObjects.Select(EmitBusinessObjectAnalysisCase));

        return $$"""
using Microsoft.EntityFrameworkCore;
using {{_rootNamespace}}.Persistence;

namespace {{_rootNamespace}}.Analysis;

public sealed class AnalysisService(AppDbContext dbContext)
{
    private static readonly HashSet<string> SupportedBusinessObjects = new({{supportedBusinessObjects}}, StringComparer.OrdinalIgnoreCase);

    public async Task<BusinessObjectRunDto> RunAsync(string businessObjectName, CancellationToken cancellationToken)
    {
        if (!SupportedBusinessObjects.Contains(businessObjectName))
        {
            throw new InvalidOperationException($"Business object '{businessObjectName}' is not configured for analysis.");
        }

        var run = new BusinessObjectRun
        {
            RunId = Guid.NewGuid(),
            BusinessObjectName = businessObjectName,
            Status = "Running",
            StartedOn = DateTimeOffset.UtcNow
        };

        dbContext.BusinessObjectRuns.Add(run);
{{profilingCases}}
        run.Status = "Completed";
        run.CompletedOn = DateTimeOffset.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);
        return MapRun(run);
    }

    public async Task<IReadOnlyList<BusinessObjectRunDto>> GetRunsAsync(string businessObjectName, CancellationToken cancellationToken)
        => await dbContext.BusinessObjectRuns
            .Where(x => x.BusinessObjectName == businessObjectName)
            .OrderByDescending(x => x.StartedOn)
            .Select(x => MapRun(x))
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<DataProfilingSummary>> GetProfilingSummariesAsync(Guid runId, CancellationToken cancellationToken)
        => await dbContext.DataProfilingSummaries.Where(x => x.RunId == runId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<DataProfilingDrilldown>> GetProfilingDrilldownsAsync(Guid runId, Guid summaryId, CancellationToken cancellationToken)
        => await dbContext.DataProfilingDrilldowns.Where(x => x.RunId == runId && x.SummaryId == summaryId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<DataQualityRuleResult>> GetRuleResultsAsync(Guid runId, CancellationToken cancellationToken)
        => await dbContext.DataQualityRuleResults.Where(x => x.RunId == runId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<DataQualityDrilldown>> GetRuleDrilldownsAsync(Guid runId, Guid resultId, CancellationToken cancellationToken)
        => await dbContext.DataQualityDrilldowns.Where(x => x.RunId == runId && x.ResultId == resultId).ToListAsync(cancellationToken);

    private static BusinessObjectRunDto MapRun(BusinessObjectRun run)
        => new()
        {
            RunId = run.RunId,
            BusinessObjectName = run.BusinessObjectName,
            Status = run.Status,
            StartedOn = run.StartedOn,
            CompletedOn = run.CompletedOn
        };
}
""";
    }

    private string EmitBusinessObjectAnalysisCase(BusinessObjectDefinition businessObject)
    {
        var entityCounts = BusinessObjectEntities(businessObject)
            .Select(entity => $$"""
            dbContext.DataProfilingSummaries.Add(new DataProfilingSummary
            {
                SummaryId = Guid.NewGuid(),
                RunId = run.RunId,
                BusinessObjectName = "{{Escape(businessObject.Name)}}",
                EntityName = "{{Escape(entity.Name)}}",
                MetricName = "{{Escape(entity.Name)}} total count",
                MetricType = "TotalCount",
                NumericValue = await dbContext.{{Naming.Plural(entity.Name)}}.CountAsync(cancellationToken),
                CreatedOn = DateTimeOffset.UtcNow
            });
""");

        return $$"""
        if (businessObjectName.Equals("{{Escape(businessObject.Name)}}", StringComparison.OrdinalIgnoreCase))
        {
{{Indent(string.Join(Environment.NewLine, entityCounts), 12)}}
        }
""";
    }

    private string EmitAnalysisController() => $$"""
using Microsoft.AspNetCore.Mvc;

namespace {{_rootNamespace}}.Analysis;

[ApiController]
[Route("api/analysis")]
public sealed class AnalysisController(AnalysisService service) : ControllerBase
{
    [HttpPost("{businessObjectName}/runs")]
    public async Task<ActionResult<BusinessObjectRunDto>> Run(string businessObjectName, CancellationToken cancellationToken)
        => Ok(await service.RunAsync(businessObjectName, cancellationToken));

    [HttpGet("{businessObjectName}/runs")]
    public async Task<ActionResult<IReadOnlyList<BusinessObjectRunDto>>> GetRuns(string businessObjectName, CancellationToken cancellationToken)
        => Ok(await service.GetRunsAsync(businessObjectName, cancellationToken));

    [HttpGet("runs/{runId:guid}/profiling-summary")]
    public async Task<ActionResult<IReadOnlyList<DataProfilingSummary>>> GetProfilingSummaries(Guid runId, CancellationToken cancellationToken)
        => Ok(await service.GetProfilingSummariesAsync(runId, cancellationToken));

    [HttpGet("runs/{runId:guid}/profiling-drilldown/{summaryId:guid}")]
    public async Task<ActionResult<IReadOnlyList<DataProfilingDrilldown>>> GetProfilingDrilldowns(Guid runId, Guid summaryId, CancellationToken cancellationToken)
        => Ok(await service.GetProfilingDrilldownsAsync(runId, summaryId, cancellationToken));

    [HttpGet("runs/{runId:guid}/rule-results")]
    public async Task<ActionResult<IReadOnlyList<DataQualityRuleResult>>> GetRuleResults(Guid runId, CancellationToken cancellationToken)
        => Ok(await service.GetRuleResultsAsync(runId, cancellationToken));

    [HttpGet("runs/{runId:guid}/rule-drilldown/{resultId:guid}")]
    public async Task<ActionResult<IReadOnlyList<DataQualityDrilldown>>> GetRuleDrilldowns(Guid runId, Guid resultId, CancellationToken cancellationToken)
        => Ok(await service.GetRuleDrilldownsAsync(runId, resultId, cancellationToken));
}
""";

    private IEnumerable<EntityDefinition> BusinessObjectEntities(BusinessObjectDefinition businessObject)
    {
        var names = businessObject.Entities.Count == 0
            ? [Naming.Pascal(businessObject.RootEntity ?? businessObject.Entity ?? businessObject.Name)]
            : businessObject.Entities.Select(Naming.Pascal).ToList();

        return metadata.Entities.Where(e => names.Any(name => Matches(name, e.Name)));
    }

    private static PropertyDefinition KeyProperty(EntityDefinition entity)
        => entity.Properties.FirstOrDefault(p => IsKey(entity, p))
            ?? entity.Properties.FirstOrDefault(p => p.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
            ?? new PropertyDefinition { Name = "Id", Type = "int", IsKey = true };

    private static bool IsKey(EntityDefinition entity, PropertyDefinition property)
        => property.IsKey || property.Name.Equals(entity.PrimaryKey ?? "Id", StringComparison.OrdinalIgnoreCase);

    private static string KeyType(EntityDefinition entity)
        => ClrType(KeyProperty(entity), forEntity: false).Replace("?", "", StringComparison.Ordinal);

    private static string ClrType(PropertyDefinition property, bool forEntity)
    {
        var type = property.Type.Trim().ToLowerInvariant() switch
        {
            "int" or "integer" => "int",
            "long" => "long",
            "decimal" or "money" or "currency" => "decimal",
            "double" => "double",
            "float" => "float",
            "bool" or "boolean" => "bool",
            "datetime" or "date" => "DateTime",
            "datetimeoffset" => "DateTimeOffset",
            "guid" => "Guid",
            _ => "string"
        };

        if (type == "string")
        {
            return property.Required || IsKeyName(property) ? "string" : "string?";
        }

        return property.Required || IsKeyName(property) ? type : $"{type}?";
    }

    private static bool IsKeyName(PropertyDefinition property)
        => property.IsKey || property.Name.Equals("Id", StringComparison.OrdinalIgnoreCase);

    private static bool IsString(PropertyDefinition property) => ClrType(property, forEntity: true).StartsWith("string", StringComparison.Ordinal);

    private static bool IsDecimal(PropertyDefinition property) => ClrType(property, forEntity: true).StartsWith("decimal", StringComparison.Ordinal);

    private static string DefaultValue(PropertyDefinition property)
        => ClrType(property, forEntity: false) == "string" ? " = string.Empty;" : "";

    private static bool Matches(string left, string right)
        => Naming.Pascal(left).Equals(Naming.Pascal(right), StringComparison.OrdinalIgnoreCase);

    private static string Escape(string value)
        => value.Replace("\\", "\\\\", StringComparison.Ordinal).Replace("\"", "\\\"", StringComparison.Ordinal);

    private static string Indent(string value, int spaces)
    {
        var padding = new string(' ', spaces);
        return string.Join(Environment.NewLine, value.Split(Environment.NewLine).Select(line => string.IsNullOrWhiteSpace(line) ? line : padding + line));
    }
}
