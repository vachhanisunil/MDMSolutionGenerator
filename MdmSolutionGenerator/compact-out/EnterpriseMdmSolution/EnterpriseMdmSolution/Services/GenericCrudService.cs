using System.Reflection;
using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Persistence;

namespace EnterpriseMdmSolution.Services;

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