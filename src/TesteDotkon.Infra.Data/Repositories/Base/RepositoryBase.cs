using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TesteDotkon.Core.Domain.Interfaces.Base;

namespace TesteDotkon.Infra.Data.Repositories.Base;

public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    protected readonly TContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public RepositoryBase(TContext context)
    {
        Context = context;
        DbSet = Context.Set<TEntity>();
    }

    #region GetBy
    public async Task<TEntity?> GetByAsync(bool tracking, Expression<Func<TEntity, bool>> where,
      CancellationToken cancellationToken = default)
    {
        return tracking
            ? await DbSet.FirstOrDefaultAsync(where, cancellationToken)
            : await DbSet.AsNoTracking().FirstOrDefaultAsync(where, cancellationToken);
    }
    #endregion

    #region Add
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
    }

    #endregion

    #region Update
    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    #endregion

    #region Delete
    public void DeleteAsync(TEntity entity)
    {
        DbSet.Remove(entity);
    }
    #endregion

    #region Listar
    public async Task<IEnumerable<TEntity>> ListAsync(bool tracking)
    {
        return tracking
            ? await DbSet.ToListAsync()
            : await DbSet.AsNoTracking().ToListAsync();
    }

    #endregion
}
