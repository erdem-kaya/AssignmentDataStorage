using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IBaseService<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity?> CreateAsync(TEntity entity);
    Task<TEntity?> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity);
    Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
}
