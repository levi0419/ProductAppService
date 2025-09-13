namespace ProductService.Domain.Models.DTOs;

public class AppSettings
{
    public MangoDbConfig MangoDbConfig { get; set; } = new();
}

public class MangoDbConfig
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string CollectionName { get; set; } = string.Empty;
}