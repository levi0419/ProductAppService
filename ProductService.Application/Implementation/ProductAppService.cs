namespace ProductService.Application.Implementation;

using global:: ProductService.Application.Abstraction;
using global:: ProductService.Domain.Models;
using global:: ProductService.Infrastructure.Abstraction;
using ProductService.Domain.Models.APIResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


public class ProductAppService : IProductAppService
{
    private readonly IProductServiceRepo<Product> _repository;

    public ProductAppService(IProductServiceRepo<Product> repository)
    {
        _repository = repository;
    }

    public async Task<ClsResponseMessage<IEnumerable<Product>>> GetAllProductsAsync()
    {
        try
        {
            var products = await _repository.GetAllAsync();
            return  ClsResponseMessage<IEnumerable<Product>>.Success(products, "Products retrieved successfully");
            
        }
        catch (Exception ex)
        {
            return ClsResponseMessage<IEnumerable<Product>>.Failure($"Error retrieving products: {ex.Message}");
        }
    }

    public async Task<ClsResponseMessage<Product?>> GetProductByIdAsync(Guid id)
    {
        try
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                return ClsResponseMessage<Product?>.Failure("Product not found");
            }
            return ClsResponseMessage<Product?>.Success(product, "Product retrieved successfully");
        }
        catch (Exception ex)
        {
            return ClsResponseMessage<Product?>.Failure($"Error retrieving product: {ex.Message}");
        }

    }

    public async Task<ClsResponseMessage1> CreateProductAsync(Product product)
    {
        try
        {
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;

            await _repository.AddAsync(product);
            return ClsResponseMessage1.Success("Product created successfully", "00");
        }
        catch (Exception ex)
        {
            return ClsResponseMessage1.Failure($"Error creating product: {ex.Message}", "500");
        }
    }

    public async Task<ClsResponseMessage1> UpdateProductAsync(Product product)
    {
        try
        {
            var existingProduct = await _repository.GetByIdAsync(product.Id);
            if (existingProduct == null)
            {
                return ClsResponseMessage1.Failure("Product not found", "404");
            }

            await _repository.UpdateAsync(product);
            return ClsResponseMessage1.Success("Product updated successfully", "00");
        }
        catch (Exception ex)
        {
            return ClsResponseMessage1.Failure($"Error updating product: {ex.Message}", "500");
        }
    }

    public async Task<ClsResponseMessage1> DeleteProductAsync(Guid id)
    {
        try
        {
            var existingProduct = await _repository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return ClsResponseMessage1.Failure("Product not found", "404");
            }

            await _repository.DeleteAsync(id);
            return ClsResponseMessage1.Success("Product deleted successfully", "00");
        }
        catch (Exception ex)
        {
            return ClsResponseMessage1.Failure($"Error deleting product: {ex.Message}", "500");
        }
    }
}
