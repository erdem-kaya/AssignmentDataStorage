﻿using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public virtual async Task<TEntity?> CreateAsync(TEntity entity)
    {
        if (entity == null)
            return null;

        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
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
            //Chat GPT hjälpte mig att skapa denna kod
            IQueryable<TEntity> entities = _dbSet;
            // If expression is not null, filter entities
            if (expression != null)
                // Filter entities
                entities = entities.Where(expression);
            // Return entities
            return await entities.ToListAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting all {nameof(TEntity)} entities : {ex.Message}");
            // Return empty list if error. Chat gpt hjälpte mig att skapa denna kod
            var emptyList = Enumerable.Empty<TEntity>();
            return emptyList;
        }
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null)
            return null;
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting {nameof(TEntity)} entity : {ex.Message}");
            return null;
        }
    }

    public virtual async Task<TEntity?> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity)
    {
        if (expression == null || updatedEntity == null)
            return null;

        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            if (entity == null)
                return null;

            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating {nameof(TEntity)} entity : {ex.Message}");
            return null;
        }
    }

    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null)
            return false;

        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting {nameof(TEntity)} entity : {ex.Message}");
            return false;
        }
    }
}
