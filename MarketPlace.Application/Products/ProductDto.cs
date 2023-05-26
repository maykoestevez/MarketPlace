using AutoMapper;
using MarketPlace.Application.Common;

namespace MarketPlace.Application.Products;

public class ProductDto :IMapFrom<Domain.Product>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<Domain.Product, ProductDto>().ReverseMap();
}