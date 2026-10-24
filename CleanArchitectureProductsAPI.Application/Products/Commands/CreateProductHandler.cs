using CleanArchitectureProductsAPI.Application.Abstractions;
using CleanArchitectureProductsAPI.Application.DTOs;
using CleanArchitectureProductsAPI.Domain.Entities;
using MediatR;

namespace CleanArchitectureProductsAPI.Application.Products.Commands;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto> Handle(
        CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Validation already ran in the pipeline, so Name is not null here.
        var product = new Product(request.Name!, request.Price);

        await _repository.AddAsync(product, cancellationToken);

        // After saving, EF Core has filled in product.Id.
        return new ProductDto(product.Id, product.Name, product.Price);
    }
}
