using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> CreateAsync(TEntity entity);
    Task<TEntity?> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity);
    Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
}

