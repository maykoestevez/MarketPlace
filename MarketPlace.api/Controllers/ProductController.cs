using MarketPlace.Application.Product.Validations;
using MarketPlace.Application.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IEnumerable<ProductDto>> Get()
    {
        return await _mediator.Send(new GetProductListRequest());
    }
    
    [HttpGet("{id:int}")]
    public async Task<ProductDto> GetById(int id)
    {
        return await _mediator.Send(new GetProductById(){Id = id});
    }

    [HttpPost]
    public async Task<ProductDto> Post([FromBody] CreateProductRequest productRequest)
    {
        return await _mediator.Send(productRequest);
    }

    [HttpPut]
    public async Task<ProductDto> Put(UpdateProductRequest updateProductRequest)
    {
        return await _mediator.Send(updateProductRequest);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProductCommand {Id = id});
        return NoContent();
    }
}