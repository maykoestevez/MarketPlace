using MarketPlace.Domain;
using MarketPlace.Infrastructure.Database;
using MarketPlace.Infrastructure.Interfaces.Repository;

namespace MarketPlace.Infrastructure.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(MarketPlaceDbContext dbContext) : base(dbContext)
    {
    }
}