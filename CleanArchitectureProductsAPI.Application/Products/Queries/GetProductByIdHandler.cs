using CleanArchitectureProductsAPI.Application.Abstractions;
using CleanArchitectureProductsAPI.Application.DTOs;
using MediatR;

namespace CleanArchitectureProductsAPI.Application.Products.Queries;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _repository;

    public GetProductByIdHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto?> Handle(
        GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id, cancellationToken);

        return product is null
            ? null
            : new ProductDto(product.Id, product.Name, product.Price);
    }
}
