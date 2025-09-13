namespace ProductService.Application.Abstraction;


using global::ProductService.Domain.Models;
using ProductService.Domain.Models.APIResponse;
using System;
using System.Threading.Tasks;


public interface IProductAppService
{
    Task<ClsResponseMessage<IEnumerable<Product>>> GetAllProductsAsync();
    Task<ClsResponseMessage<Product?>> GetProductByIdAsync(Guid id);
    Task<ClsResponseMessage1> CreateProductAsync(Product product);
    Task<ClsResponseMessage1> UpdateProductAsync(Product product);
    Task<ClsResponseMessage1> DeleteProductAsync(Guid id);
}