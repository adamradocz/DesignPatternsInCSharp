using System.Linq.Expressions;

namespace DesignPatternsInCSharp.Others.Repository.Interfaces;

public interface IRepository<TEntity> where TEntity : class, new()
{
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Delete(int id);
    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);
    Task<List<TEntity>> FindAllByAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string[]? includeProperties = null);
    Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> filter, string[]? includeProperties = null);
    ValueTask<TEntity> FindByIdAsync(int id);
    Task<List<TEntity>> GetAllAsync();
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
}