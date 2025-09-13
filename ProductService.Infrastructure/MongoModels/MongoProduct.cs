namespace ProductService.Infrastructure.MongoModels;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System;
using System.Linq;
using ProductService.Domain.Models;
public class MongoProduct
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("price")]
    public decimal Price { get; set; }

    [BsonElement("stock")]
    public int Stock { get; set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonElement("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    [BsonElement("categories")]
    public List<MongoCategory> Categories { get; set; } = new List<MongoCategory>();

    public static MongoProduct FromDomain(Product product)
    {
        return new MongoProduct
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt,
            Categories = product.Categories.Select(MongoCategory.FromDomain).ToList()
        };
    }

    public Product ToDomain()
    {
        return new Product
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description,
            Price = this.Price,
            Stock = this.Stock,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
            Categories = this.Categories.Select(c => c.ToDomain()).ToList()
        };
    }
}