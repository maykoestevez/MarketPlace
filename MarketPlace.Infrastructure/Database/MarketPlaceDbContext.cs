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
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}