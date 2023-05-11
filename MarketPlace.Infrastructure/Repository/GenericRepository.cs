using MarketPlace.Domain.Common;
using MarketPlace.Infrastructure.Database;
using MarketPlace.Infrastructure.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MarketPlace.Infrastructure.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly MarketPlaceDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(MarketPlaceDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetById(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Insert(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task Update(T entity)
    {
        await Task.FromResult(_dbSet.Attach(entity));
        _dbContext.Entry(entity);
    }

    public async Task Delete(object id)
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

    public async Task Save()
    {
        SetTrackingProperties();
        await _dbContext.SaveChangesAsync();
    }
}