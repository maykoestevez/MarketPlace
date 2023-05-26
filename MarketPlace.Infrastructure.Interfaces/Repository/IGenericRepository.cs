using System.Linq.Expressions;

namespace MarketPlace.Infrastructure.Interfaces.Repository;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null);
    public Task<T> GetByIdAsync(object id);
    Task<T> InsertAsync(T obj);
    Task<T> UpdateAsync(T obj);
    Task DeleteAsync(object id);
    Task SaveAsync();
}