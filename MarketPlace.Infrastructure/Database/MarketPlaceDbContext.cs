using System.Reflection;
using MarketPlace.Domain;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Database;

public class MarketPlaceDbContext : DbContext
{
    public MarketPlaceDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}