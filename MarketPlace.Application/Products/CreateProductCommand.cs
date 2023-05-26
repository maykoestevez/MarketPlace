using AutoMapper;
using MarketPlace.Application.Common;
using MediatR;

namespace MarketPlace.Application.Products;

public class CreateProductRequest : IRequest<ProductDto>, IMapFrom<Domain.Product>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<Domain.Product, CreateProductRequest>().ReverseMap();
}