using MediatR;

namespace MarketPlace.Application.Products;

public class GetProductById:IRequest<ProductDto>
{
    public int Id { get; set; }
}
public class GetProductListRequest: IRequest<IEnumerable<ProductDto>>
{

}