using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Core.Interfaces;
using EnterpriseMdmSolution.Infrastructure.Persistence;

namespace EnterpriseMdmSolution.Infrastructure.Repositories;

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