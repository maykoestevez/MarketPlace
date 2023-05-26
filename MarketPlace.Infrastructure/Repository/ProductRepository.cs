using MarketPlace.Domain;
using MarketPlace.Infrastructure.Database;
using MarketPlace.Infrastructure.Interfaces.Repository;

namespace MarketPlace.Infrastructure.Repository;

public class ProductRepository:GenericRepository<Product>,IProductRepository
{
    public ProductRepository(MarketPlaceDbContext dbContext) : base(dbContext)
    {
        
    }
}