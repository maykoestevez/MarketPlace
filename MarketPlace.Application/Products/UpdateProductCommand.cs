using AutoMapper;
using MarketPlace.Application.Common;
using MarketPlace.Application.Products;
using MediatR;

namespace MarketPlace.Application.Product.Validations;

public class UpdateProductRequest:IRequest<ProductDto>,IMapFrom<Domain.Product>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<Domain.Product, UpdateProductRequest>().ReverseMap();
}