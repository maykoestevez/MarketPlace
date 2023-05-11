namespace MarketPlace.Infrastructure.Interfaces.Repository;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    public Task<T> GetById(object id);
    Task Insert(T obj);
    Task Update(T obj);
    Task Delete(object id);
    Task Save();
}