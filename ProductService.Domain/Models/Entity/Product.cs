using System.Text.Json.Serialization;

namespace ProductService.Domain.Models;

public class Product
{
    [JsonIgnore]
    public Guid Id { get; set; }   
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    [JsonIgnore]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [JsonIgnore]
    public DateTime? UpdatedAt { get; set; }

    public ICollection<Category> Categories { get; set; } = new List<Category>();
}

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
