using MarketPlace.Domain.Common;

namespace MarketPlace.Domain;

public class Product : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public bool IsActive { get; set; }
}