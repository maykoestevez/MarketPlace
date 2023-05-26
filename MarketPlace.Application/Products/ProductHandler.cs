using AutoMapper;
using AutoMapper.QueryableExtensions;
using MarketPlace.Application.Product.Validations;
using MarketPlace.Infrastructure.Interfaces.Repository;
using MediatR;

namespace MarketPlace.Application.Products;

public class ProductHandler : IRequestHandler<CreateProductRequest, ProductDto>,
    IRequestHandler<UpdateProductRequest, ProductDto>,
    IRequestHandler<GetProductListRequest, IEnumerable<ProductDto>>, IRequestHandler<DeleteProductCommand, int>,
    IRequestHandler<GetProductById, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Domain.Product>(request);
        var updatedEntity = await _productRepository.InsertAsync(product);
        await _productRepository.SaveAsync();
        return _mapper.Map<ProductDto>(updatedEntity);
    }

    public async Task<ProductDto> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Domain.Product>(request);
        var updatedEntity = await _productRepository.UpdateAsync(product);
        await _productRepository.SaveAsync();
        return _mapper.Map<ProductDto>(updatedEntity);
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductListRequest request,
        CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAsync();
        return products.AsQueryable().ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToList();
    }

    public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.DeleteAsync(request.Id);
        await _productRepository.SaveAsync();
        return request.Id;
    }

    public async Task<ProductDto> Handle(GetProductById request, CancellationToken cancellationToken)
    {
       var product = await _productRepository.GetByIdAsync(request.Id);
       return _mapper.Map<ProductDto>(product);
    }
}