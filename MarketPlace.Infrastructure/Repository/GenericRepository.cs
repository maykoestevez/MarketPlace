using System.Linq.Expressions;
using MarketPlace.Domain.Common;
using MarketPlace.Infrastructure.Database;
using MarketPlace.Infrastructure.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MarketPlace.Infrastructure.Repository;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly MarketPlaceDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(MarketPlaceDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null)
    {
        if (filter != null)
        {
            return await _dbSet.Where(filter).AsNoTracking().ToListAsync();
        }

        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<T> InsertAsync(T entity)
    {
        return (await _dbSet.AddAsync(entity)).Entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        return await Task.FromResult(entity);
    }
    
    public virtual async Task DeleteAsync(object id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (_dbContext.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }

        _dbSet.Remove(entity);
    }

    private void SetTrackingProperties()
    {
        foreach (var entry in _dbContext.ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }
    }

    public async Task SaveAsync()
    {
        SetTrackingProperties();
        await _dbContext.SaveChangesAsync();
    }
}