using Business.Interfaces;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public abstract class BaseService<TEntity>(IBaseRepository<TEntity> repository) : IBaseService<TEntity> where TEntity : class
{
    protected readonly IBaseRepository<TEntity> _repository = repository;

    public virtual async Task<TEntity?> CreateAsync(TEntity entity)
    {
        try
        {
            var createdEntity = await _repository.CreateAsync(entity);
            return createdEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating {nameof(TEntity)} entity : {ex.Message}");
            return null;
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null)
    {
        try
        {
            var getAllEntities = await _repository.GetAllAsync(expression);
            return getAllEntities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting all {nameof(TEntity)} entities : {ex.Message}");
            return [];
        }
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var getEntity = await _repository.GetAsync(expression);
            return getEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting {nameof(TEntity)} entity : {ex.Message}");
            return null;
        }
    }

    public virtual async Task<TEntity?> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity)
    {
        try
        {
            var entityUpdate = await _repository.UpdateAsync(expression, updatedEntity);
            return entityUpdate;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating {nameof(TEntity)} entity : {ex.Message}");
            return null;
        }
    }

    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entityDeleted = await _repository.DeleteAsync(expression);
            return entityDeleted;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting {nameof(TEntity)} entity : {ex.Message}");
            return false;
        }
    }
}