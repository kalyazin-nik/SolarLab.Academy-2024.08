using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SolarLab.Academy.Infrastructure.Repository;

/// <inheridoc />
public class Repository<TEntity, TContext> : IRepository<TEntity, TContext>
    where TEntity : class
    where TContext : DbContext
{
    protected TContext DbContext;
    protected DbSet<TEntity> DbSet;

    public Repository(TContext dBContext)
    {
        DbContext = dBContext;
        DbSet = DbContext.Set<TEntity>();
    }

    #region Add

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await DbSet.AddAsync(entity, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Get

    public IQueryable<TEntity> GetAll()
    {
        return DbSet;
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbSet.FindAsync(id, cancellationToken);
    }

    public IQueryable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate)
    {
        return DbSet.Where(predicate);
    }

    #endregion

    #region Remove

    public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity is not null)
        {
            DbSet.Remove(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        return false;
    }

    public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken)
    {
        DbSet.Remove(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Update

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        DbSet.Update(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    #endregion
}
