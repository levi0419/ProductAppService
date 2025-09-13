namespace ProductService.Infrastructure.MongoModels;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProductService.Domain.Models;
using System;
using System.Linq;

public class MongoCategory
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    public static MongoCategory FromDomain(Category category)
    {
        return new MongoCategory
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public Category ToDomain()
    {
        return new Category
        {
            Id = this.Id,
            Name = this.Name
        };
    }
}