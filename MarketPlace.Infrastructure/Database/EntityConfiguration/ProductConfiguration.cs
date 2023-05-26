using MarketPlace.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infrastructure.Database.EntityConfiguration;

public class ProductConfiguration:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.HasData(new List<Product>()
        {
            new Product()
            {
                Id = -1,
                Name = "Laptop Lenovo",
                Category = "Tech",
                Description = "Brand new Lenovo PC Brand #12",
                CreatedDate = DateTime.Now,
                Price = 1200,
                IsActive = true
                
            },
            new Product()
            {
                Id = -2,
                Name = "Laptop Dell",
                Category = "Tech",
                Description = "Brand new Lenovo PC Brand #12",
                CreatedDate = DateTime.Now,
                Price = 1200,
                IsActive = true
                
            }
        });
    }
}