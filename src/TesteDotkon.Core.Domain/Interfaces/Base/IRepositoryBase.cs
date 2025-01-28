using System.Linq.Expressions;

namespace TesteDotkon.Core.Domain.Interfaces.Base;

public interface IRepositoryBase<TEntity>
    where TEntity : class
{
    #region GetBy
    Task<TEntity?> GetByAsync(bool tracking, Expression<Func<TEntity, bool>> where,
       CancellationToken cancellationToken = default);
    #endregion

    #region Add
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    #endregion

    #region Update
    void Update(TEntity entity);
    #endregion

    #region Delete
    void DeleteAsync(TEntity entity);
    #endregion

    #region Listar
    Task<IEnumerable<TEntity>> ListAsync(bool tracking);
    #endregion
}
