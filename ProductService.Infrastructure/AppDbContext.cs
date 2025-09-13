namespace ProductService.Infrastructure;

using MongoDB.Driver;
using ProductService.Infrastructure.MongoModels;

public class AppDbContext
{
    private readonly IMongoDatabase _database;

    public AppDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    // Collections for Infra Mongo Models
    public IMongoCollection<MongoProduct> Products =>
        _database.GetCollection<MongoProduct>("Products");

    public IMongoCollection<MongoCategory> Categories =>
        _database.GetCollection<MongoCategory>("Categories");
}
