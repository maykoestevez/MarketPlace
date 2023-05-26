using MediatR;

namespace MarketPlace.Application.Products;

public class DeleteProductCommand : IRequest<int>
{
    public int Id { get; set; }
}