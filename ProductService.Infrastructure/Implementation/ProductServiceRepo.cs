using ProductService.Domain.Models;
using ProductService.Infrastructure.MongoModels;
using ProductService.Infrastructure.Abstraction;
using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Infrastructure;

public class ProductRepository : IProductServiceRepo<Product>
{
    private readonly IMongoCollection<MongoProduct> _collection;

    public ProductRepository(AppDbContext context)
    {
        _collection = context.Products;
    }

    // Get all products (with categories) as Domain models
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var mongoProducts = await _collection.Find(_ => true).ToListAsync();
        return mongoProducts.Select(mp => mp.ToDomain());
    }

    // Get single product by Id
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var mongoProduct = await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        return mongoProduct?.ToDomain();
    }

    // Create a new product
    public async Task AddAsync(Product product)
    {
        var mongoProduct = MongoProduct.FromDomain(product);
        await _collection.InsertOneAsync(mongoProduct);
    }

    // Update existing product
    public async Task UpdateAsync(Product product)
    {
        var mongoProduct = MongoProduct.FromDomain(product);
        await _collection.ReplaceOneAsync(p => p.Id == product.Id, mongoProduct);
    }

    // Delete product
    public async Task DeleteAsync(Guid id)
    {
        await _collection.DeleteOneAsync(p => p.Id == id);
    }
}
