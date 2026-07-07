using EnterpriseMdmSolution.Core.Common;

namespace EnterpriseMdmSolution.Core.Interfaces;

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