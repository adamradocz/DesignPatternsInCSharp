using CommunityToolkit.Diagnostics;
using DesignPatternsInCSharp.Others.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DesignPatternsInCSharp.Others.Repository;

// Based on:
// - https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
// - https://medium.com/codex/generic-repository-unit-of-work-patterns-in-net-b830b7fb5668

/// <summary>
/// Generic repository.
/// </summary>
/// <typeparam name="TEntity">Entity.</typeparam>
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
{
    internal readonly DbSet<TEntity> _dbSet;

    public Repository(TrainingDbContext context)
    {
        Guard.IsNotNull(context, nameof(context));
        _dbSet = context.Set<TEntity>();
    }

    /// <summary>
    /// Get all the entitis.
    /// </summary>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported.
    /// Use <c>await</c> to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <c>System.Collections.Generic.List</c>.</returns>
    public virtual Task<List<TEntity>> GetAllAsync() => _dbSet.ToListAsync();

    public virtual void Add(TEntity entity) => _dbSet.Add(entity);

    public virtual void AddRange(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

    public virtual ValueTask<TEntity> FindByIdAsync(int id) => _dbSet.FindAsync(id);

    /// <summary>
    /// Find a specific entity.
    /// </summary>
    /// <param name="filter">Filter condition. Eg.: <c>partner => partner.Name == "HUN"</c></param>
    /// <param name="includeProperties">Lif of navigation properties.</param>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported.
    /// Use <c>await</c> to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <typeparamref name="TEntity"/>.</returns>
    public virtual Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> filter, string[]? includeProperties = null)
    {
        var queryable = _dbSet.AsQueryable().Where(filter);

        if (includeProperties is not null)
        {
            foreach (var includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
        }

        return queryable.FirstOrDefaultAsync();
    }

    /// <summary>
    /// Find all the specific entities.
    /// </summary>
    /// <param name="filter">Filter condition. Eg.: <c>partner => partner.Name == "HUN"</c></param>
    /// <param name="orderBy">Lamba expression. Eg: <c>q => q.OrderBy(s => s.Name)</c></param>
    /// <param name="includeProperties">Lif of navigation properties.</param>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported.
    /// Use <c>await</c> to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <returns>A task that represents the asynchronous operation. The task result contains a List of <typeparamref name="TEntity"/>.</returns>
    public virtual Task<List<TEntity>> FindAllByAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string[]? includeProperties = null)
    {
        var queryable = _dbSet.AsQueryable().Where(filter);

        if (includeProperties is not null)
        {
            foreach (var includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
        }

        return orderBy == null ? queryable.ToListAsync() : orderBy(queryable).ToListAsync();
    }

    public virtual void Update(TEntity entity) => _dbSet.Update(entity);

    public virtual void UpdateRange(IEnumerable<TEntity> entities) => _dbSet.UpdateRange(entities);

    public virtual void Delete(int id)
    {
        var entityToDelete = _dbSet.Find(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entity) => _dbSet.Remove(entity);

    public virtual void DeleteRange(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);
}